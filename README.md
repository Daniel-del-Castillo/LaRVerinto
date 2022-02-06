# LaRVerinto
Proyecto desarrollado para la asignatura Interfaces Inteligentes en la Universidad de La Laguna. Curso 2021-2022.
## Autores
* Daniel del Castillo de la Rosa
* Javier Correa Marichal
* Alejandro Peraza González
* Nerea Rodríguez Hernández
## Cuestiones importantes para el uso.
Una vez iniciada la aplicación el usuario se encontrará en la escena inicial del juego. Esta escena le servirá para identificar los controles del juego:

![texto_alternativo](./img/controles.png)

Así mismo, y haciendo uso de la retícula, el usuario tiene dos opciones: *Jugar* o *Salir*. Una vez accionado el botón de *Jugar*, el usuario se teletransporta a la escena principal de juego.

## Hitos de programación
## Aspectos a destacar de la aplicación
Especificar si se han incluido sensores de los que se han trabajado en interfaces multimodales.
## Gif animado de ejecución
## Organización del proyecto
## Experiencia en Realidad Virtual
A continuación se listan los distintos aspectos que se han tenido en cuenta en la *APK* y como se han solventado en la misma:
* Papel del suelo. Para evitar que el usuario se mareé debido a la pérdida de percepción de la realidad con la relación cielo-suelo, ambos escenarios se encuentran abiertos y el usuario podrá mirar el cielo mientras se desplaza.
  
* Atmósfera. El usuario podrá determinar la profundidad y la distancia a la que se encuentra un objeto ya que se ha añadido un desvanecimiento gradual al entorno. Con esto se consigue crear un entorno virtual escalado y una experiencia más natural.
  
* Caracterísitcas del terreno. Aunque no se cuenta con un entorno abierto, el camino del laberinto permite el movimiento peatonal de un lugar a otro. El usuario sabrá que esta en el centro del laberinto cuando encuentre un *pozo* (permite colisión) y las paredes del laberinto jugaran el papel de barrera, un tipo específico de obstáculo, que bloquea la visión y el movimiento del mismo.
  
* Introducción del usuario mediante paisajes sonoros. Cada vez que se realice un cambio de escenario, se genera una suave introducción al nuevo escenario haciendo aparecer primero el sonido contextual del lugar y luego la imagen.
  
* Guiar al usuario con objetos. El laberito puede ser un escenario donde el usuario se desoriente con facilidad, por lo que se ha permitido que coloque unas marcas rojas en la pared para identificar los caminos por los que ha pasado. Además, puede colocar en el suelo una brújula que señaliza el norte y el sur, con esto el usuario puede determinar su dirección.
  
* Retícula contextual:
* Objetos interactivos:

