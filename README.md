HoverB Simulator

HoverB Simulator es un juego de simulación inspirado en el dispositivo de la aerotabla(hoverboard) basado en una metáfora del mismo nombre. Mostramos un método convincente e intuitivo para la locomoción constante y estable que se corresponde bien con la propiocepción física de los usuarios mientras navegan en el entorno virtual. 

A.Diseño de hardware

La configuración del hoverboard consiste en una tabla de madera unida a unas semiesfera en la parte inferior, lo que permite la rotación alrededor del eje horizontal o vertical. Se conectó un teléfono inteligente a la parte superior del tablero como un dispositivo sensor integrado fácilmente disponible con conectividad de red inalámbrica. Aunque esto podría reemplazarse fácilmente por un dispositivo integrado dedicado para desarrollos posteriores, esta configuración permitió una iteración rápida, beneficiándose del acelerómetro integrado para una detección de inclinación con una precisión aceptable. 

B.Diseño de software

Una pequeña aplicación de Android emplea los sensores de aceleración y transfiere los datos de orientación a través de Wi-Fi. Para un enfoque simple, de bajo costo y replicable, el motor del juego Unity fue elegido para conducir una aplicación de prueba. El diseño del entorno virtual se mantuvo deliberadamente simple (Figura 2). Contiene una representación virtual del jugador que se mueve sobre un corredor o pista para referencia de profundidad a una velocidad constante que se estableció en aproximadamente 20 m / s. El nivel contiene una serie de cruces y obstáculos que se colocan a lo largo de la pista virtual y que el usuario debe esquivar para inducir movimientos de dirección y medir la precisión. Los valores de rotación entrantes se interpolan para evitar fluctuaciones en los movimientos y se asignan a la rotación alrededor del eje vertical u horizontal del tablero virtual de acuerdo con la manipulación física del tablero de madera real. La aplicación permite una orientación hacia adelante, así como una orientación lateral.

TECNOLOGÍAS USADAS

A.Unity

El Editor de Unity presenta herramientas múltiples que permiten una edición e iteración rápidas en tus ciclos de desarrollo, lo que incluye el modo Play para tener vistas previas rápidas de tu trabajo en tiempo real.

B.Sensores acelerómetros

El acelerómetro detecta la detección de movimiento basada en ejes. Detecta los cambios en la orientación de los teléfonos inteligentes con respecto a los ejes x, y y z.

Video:

[![Demo](http://img.youtube.com/vi/bF6bJuyzbiw/0.jpg)](http://www.youtube.com/watch?v=bF6bJuyzbiw "HoverB Sim Demo")
