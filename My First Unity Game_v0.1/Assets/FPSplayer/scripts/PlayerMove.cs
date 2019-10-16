using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;

    private CharacterController charController;

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;

    [SerializeField] private float gravity;
    private float forwardVel;
    private float verticalVel;
	[SerializeField] private Transform playerCamera;
	[SerializeField] private KeyCode resetKey;
	[SerializeField] private float acceleration;
	private Vector3 prevLocation=Vector3.zero;
	private float VertMomentum;


    private bool isJumping;

    private void Awake()
    {
    	forwardVel=0.0f;
    	verticalVel=0.0f;
    	VertMomentum=0.0f;
        charController = GetComponent<CharacterController>();
        isJumping=true;
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
    	//get key imputs
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;
		
		//if player is in air, aply gravity
		if(!charController.isGrounded)
		{
			if (isJumping == false){
				verticalVel = VertMomentum;
				isJumping = true;
			}
			verticalVel+=gravity*Time.deltaTime;
		}
		else
		{
			isJumping = false;
			VertMomentum = (transform.position.y - prevLocation.y)/Time.deltaTime;
			RaycastHit hit;
			if (Physics.Raycast(transform.position, Vector3.down, out hit, charController.height/2 *1.3f))
			{
	            float angle=Vector3.Angle(new Vector3(transform.right.x,0,transform.right.z),new Vector3(hit.normal.x,0,hit.normal.z));
	            //Debug.Log("angle "+angle+" "+horizInput);

	            //if(angle-90f*horizInput>0f)
	            
	            if((angle<90f && horizInput<0)||(angle>90f && horizInput>0))
	            {
	            	verticalVel=-100f;
	            }
	            else
	            {
	            	verticalVel= -0.1f;
	            }
			}
			
			if(prevLocation.y > transform.position.y){
				forwardVel+=acceleration*Time.deltaTime;
			}
			else if(prevLocation.y < transform.position.y){
				forwardVel-=acceleration*Time.deltaTime;
			}
		}
		//if player brakes
		if(vertInput < 0f){
			if(forwardVel < 2f){
				forwardVel=0;
			}
			forwardVel-=forwardVel*Time.deltaTime;
		}
		//if player moves forward, just accel till 20
		else if( forwardVel < 20f){
        	forwardVel += vertInput;
		}
		//Debug.Log("velo: "+forwardVel);

        Vector3 upMovement = transform.up * verticalVel;
        //Vector3 forwardMovement = playerCamera.forward * forwardVel;
        Vector3 forwardMovement = transform.forward * forwardVel;
        //forwardMovement+=upMovement;
        Vector3 rightMovement = Vector3.zero;//transform.right * horizInput;
        prevLocation=transform.localPosition;
        charController.Move((forwardMovement + upMovement)*Time.deltaTime);

        Debug.Log("Vel: "+forwardVel+"---"+verticalVel);
        //Debug.Log("Pos: "+transform.position.x+","+transform.position.y+","+transform.position.z);

        if(Input.GetKeyDown(resetKey)){
        	transform.position=new Vector3(21.6f,25f,6.83f);
        	prevLocation=transform.position;
        	forwardVel=0f;
        }
//        JumpInput();

    }

    private void JumpInput()
    {
        if(Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }

}
