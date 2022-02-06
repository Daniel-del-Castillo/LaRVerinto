# **LaRVerinto**
Proyecto desarrollado para la asignatura Interfaces Inteligentes en la Universidad de La Laguna. Curso 2021-2022.
## Autores
* Daniel del Castillo de la Rosa
* Javier Correa Marichal
* Alejandro Peraza González
* Nerea Rodríguez Hernández
## **Cuestiones importantes para el uso.**
Una vez iniciada la aplicación el usuario se encontrará en la escena inicial del juego. Esta escena le servirá para identificar los controles del juego:

![texto_alternativo](./img/controles.png)

Así mismo, y haciendo uso de la retícula, el usuario tiene dos opciones: *Jugar* o *Salir*. 

Una vez accionado el botón de *Jugar*, el usuario se teletransporta a la escena principal de juego. En esta escena el usuario se encuentra en un laberinto autogenerado, se desplazará haciendo uno de los controles de un mando PS4. Cuando el usuario consiga llegar a la salida, colocandose debidamente, se teletrasportará hasta la escena final.

En esta escena final se despliega una pequeño menú para que le usuario pueda volver a la escena inicial del juego y pueda probar en distintos laberintos.

## **Hitos de programación.**
A continuación se muestra en la tabla los hitos de programación que se han seguido y conseguido en el presente proyecto:
|  Hito                                         |                  Descripción                                                                                          |
|-----------------------------------------------|-----------------------------------------------------------------------------------------------------------------------|
| Funcionamiento en Realidad virtual            | Implementación de un entorno en realidad virtual para Android (.apk)                                                  |
| Generación de laberinto pseudoaleatorio       | Implementación de un camino y paredes, que simulen un laberinto, de manera pseudoaleatoria                            |
| Movimiento de usuario mediante teletransporte | Implementación de un objeto que simulue e interactue con el usuario y le permita teletransportarse de un lugar a otro |
| Marcas orientativas                           | Implementación de marcas orientativas en las paredes (cruz roja) y en el suelo (brújula que indica sur y norte)       |
| Escenario inicial                             | Implementación de un escenario inicial en el que el usuario elige cuando comenzar el juego y se le da a conocer los controles del mismo                             |
| Concideraciones de experiencia usuario        | En la implementación del diseño se deben tener en cuenta las distintas consideraciones UX explicadas en la asignatura |
| Escenario final                               | Implementación de un escenario final donde el usuario se encuentre ganador y un menú le permita volver al escenario inicial                                         |

## **Aspectos a destacar de la aplicación.**
Especificar si se han incluido sensores de los que se han trabajado en interfaces multimodales.

## **Ejecución de la aplicación.**
Video demostrativo de la aplicación desarrollada en el presente proyecto:

## **Organización del proyecto.**
A lo largo del proyecto se han desarrollado distintas reuniones a través de la plataforma de *Discord*, donde nos hemos reunido todos los componentes del equipo de trabajo. 

## **Experiencia en Realidad Virtual**
A continuación se listan los distintos aspectos que se han tenido en cuenta en la *APK* y como se han solventado en la misma:
* Papel del suelo. Para evitar que el usuario se mareé debido a la pérdida de percepción de la realidad con la relación cielo-suelo, ambos escenarios se encuentran abiertos y el usuario podrá mirar el cielo mientras se desplaza.
  
* Atmósfera. El usuario podrá determinar la profundidad y la distancia a la que se encuentra un objeto ya que se ha añadido un desvanecimiento gradual al entorno. Con esto se consigue crear un entorno virtual escalado y una experiencia más natural.
  
* Caracterísitcas del terreno. Aunque no se cuenta con un entorno abierto, el camino del laberinto permite el movimiento peatonal de un lugar a otro. El usuario sabrá que esta en el centro del laberinto cuando encuentre un *pozo* (permite colisión) y las paredes del laberinto jugaran el papel de barrera, un tipo específico de obstáculo, que bloquea la visión y el movimiento del mismo.
  
* Introducción del usuario mediante paisajes sonoros. Cada vez que se realice un cambio de escenario, se genera una suave introducción al nuevo escenario haciendo aparecer primero el sonido contextual del lugar y luego la imagen.
  
* Guiar al usuario con objetos. El laberito puede ser un escenario donde el usuario se desoriente con facilidad, por lo que se ha permitido que coloque unas marcas rojas en la pared para identificar los caminos por los que ha pasado. Además, puede colocar en el suelo una brújula que señaliza el norte y el sur, con esto el usuario puede determinar su dirección.
  
* Retícula contextual. El usuario sabe con que objetos puede interactuar gracias a la retícula. Una retícula de radio mínimo significa un estado inactivo. Para interactuar con un objeto la retícula dirige su atención al mismo y la retícula aumenta su tamaño.

* Objetos interactivos. No todos los objetos que aparecen en la escena son objetos interactivos, por lo que el usuario los identifica utilizando la retícula contextual anteriormente nombrada.
