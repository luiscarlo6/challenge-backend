# WAYNI CHALLENGE SOLUTION

### ¡Hola, bienvenido!

Esta es mi solución para el proceso de selección de Wayni. Acá encontraras la refactorización, implementación de requerimientos y una propuesta para utilizar este código para disponibilizar algunas funcionalidades en una API.

### ¿Cual es el problema?

La versión original de este repositorio junto al enunciado del problema la puedes encontrar en el siguiente [Link](https://github.com/waynimovil/challenge-backend)

### Requerimientos

A partir del método que genera el reporte de figuras geometricas, vemos dos tipos de lógicas que deben separarse:

1. Distintas figuras geometricas que calculan Area y Perímetro. Con la posibilidad de agregar más figuras con distintas formulas cada una.
2. Impresión en diferentes idiomas resultados de Area y Perímetro de las distintas figuras. Con la posibilidad de agregar más idiomas al reporte.

### Solución

Utilizar patrones de diseño, principios SOLID y funciones modernas de .NET para refactorizar el código de la siguiente manera:

- A través de Interfaces, implementamos distintas figuras geometricas que necesitaban cumplir dos métodos especificos al momento de su implementación.

  ```csharp
      public interface IFormaGeometrica
      {
          TipoForma Tipo { get; }
          decimal CalcularArea();
          decimal CalcularPerimetro();
      }
  ```

- Para la clase Forma Geometrica, utilizamos el patrón de diseño **Factory Method**, con un método para la creación de figuras geometricas que va a retornar elementos del tipo **IFormaGeometrica**

- Para la impresión se crea una nueva clase reporte en la cual se refactoriza la lógica de la impresion para usar LinQ donde sea posible.
- Se hace uso de los siguientes patrones de diseño para refactorizar la impresion en la clase **Reporte**
  1. **Strategy**: para la creación de distintos traductores a través de la interfaz IReporte.
  2. **Factory Method** y **Singleton**: para la utilización de un método que cree los traductores a ser utilizados según el idioma y singletón para garantizar que se van a crear una única vez.

Completada la refactorización se agregaron dos nuevas funcionalidades:

- Se implementaron dos nuevas figuras geometricas **Trapecio** y **Rectangulo**.
- Se agrego un nuevo idioma **Portugues**

Nota: Las pruebas de NUnit se actualizaron según el funcionamiento, todas se ejecutan correctamente.

### Requemiento API.

Se deben exponer los métodos **CalcularPerimetro** y **CalcularArea** en un endpoint público. Para ello se propone hacer uso de una API Rest utilizando .NET Core 8. Siguiendo la siguiente especificación:

| API                            | Descripción                                   | Request Body                                           | Response Body                    |
| ------------------------------ | --------------------------------------------- | ------------------------------------------------------ | -------------------------------- |
| `POST /api/calcular/perimetro` | Calcula el perímetro de una figura geometrica | `json {"figura":"Cuadrado", medida1: 3}`               | Int con el cálculo del perimetro |
| `POST /api/calcular/area`      | Calcula el Area de una figura geometrica      | `json {"figura":"Rectangulo", medida1: 3, medida2: 5}` | Int con el cálculo del perimetro |

### Cómo funciona

En el repositorio está la .sln como una librería con las nuevas clases implementadas, el proyecto con los test unitarios mofidicados según las nuevas especificaciones y una Console App de prueba donde se pueden agregar elementos a una lista para imprimir en cualquiera de los tres idiomas.

Para usar la console App se debe setear como startup project desde Visual Studio.
