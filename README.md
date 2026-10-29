# MultimediaCatalog

El objetivo de este ejercicio es construir una aplicación de consola en C# para administrar un catálogo de películas y series.

## Requisitos del Sistema

### 1. Interfaces
Crea una interfaz llamada `IEvaluable` que obligue a implementar:
* Un método `void AsignarPuntuacion(double nota)`.
* Una propiedad de solo lectura `double PuntuacionMedia { get; }`.

### 2. Clase Abstracta Base
Crea una clase abstracta `ContenidoMultimedia` que implemente `IEvaluable`.
* **Propiedades:** `Id` (Guid o string), `Titulo` (string), `FechaEstreno` (DateTime), y una lista interna (protegida o privada) de puntuaciones (`List<double>`).
* **Implementación de Interfaz:** Lógica para añadir una nota a la lista y calcular la media. Si no hay notas, la media debe ser 0.
* **Método Abstracto:** `public abstract void MostrarDetalles();`

### 3. Clases Derivadas (Herencia y Polimorfismo)
Crea dos clases que hereden de `ContenidoMultimedia`:

* **`Pelicula`:**
  * Propiedades extra: `Director` (string) y `DuracionMinutos` (int).
  * Sobrescribe `MostrarDetalles()` para imprimir la información específica de la película (incluyendo el director, la duración y la puntuación media).

* **`Serie`:**
  * Propiedades extra: `NumeroTemporadas` (int) y `EnEmision` (bool).
  * Sobrescribe `MostrarDetalles()` para imprimir la información adaptada a las series.

### 4. Utilidades (Utils y Fechas)
Crea una clase estática `DateUtils`.
* **Método `FormatearFechaPublicacion(DateTime fecha)`:** Debe devolver un string con un formato amigable. Por ejemplo: *"Estrenado el 15 de Octubre de 2023"*.
* **Método `ParsearFecha(string fechaTexto)`:** Debe intentar convertir (con `TryParse` o `TryParseExact`) un string introducido por el usuario en consola a un objeto `DateTime`. Si falla, debe devolver una fecha por defecto o solicitarla de nuevo de forma controlada.

### 5. Persistencia (Archivos y JSON)
Crea una clase `GestorDatos`.
* **`GuardarCatalogo(List<ContenidoMultimedia> catalogo, string ruta)`:** Serializa la lista a un archivo JSON. *(Pista: Al serializar una lista de una clase abstracta, revisa cómo configurar el serializador o usar atributos como `[JsonDerivedType]` para conservar el tipo derivado).*
* **`CartgarCatalogo(string ruta)`:** Deserializa el archivo JSON y devuelve la lista recuperada. Si el archivo no existe, debe manejar la excepción y devolver una lista vacía.

### 6. Interfaz de Consola (Menú Principal)
Implementa un menú interactivo en tu `Program.cs` mediante un bucle `do-while` y un `switch` con las siguientes opciones:

1. **Añadir Película:** Pide los datos por consola, instancia una `Pelicula` y la añade a la lista.
2. **Añadir Serie:** Igual, pero pidiendo los datos específicos de `Serie`.
3. **Mostrar Catálogo:** Recorre la lista invocando el método polimórfico `MostrarDetalles()`. Utiliza `DateUtils` aquí para mostrar las fechas formateadas.
4. **Buscar por Título:** Pide un término de búsqueda y muestra los contenidos cuyo título contenga esa cadena (ignorando mayúsculas y minúsculas).
5. **Valorar un Contenido:** Pide el título exacto, busca el objeto en la lista y llama a `AsignarPuntuacion(...)`.
6. **Guardar Datos:** Llama a `GestorDatos` para escribir el archivo (por ejemplo, `catalogo.json`).
7. **Cargar Datos:** Llama a `GestorDatos` para sobreescribir la lista en memoria con lo que haya en el archivo JSON.
0. **Salir.**