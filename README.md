# Trabajo Práctico Final - Aplicación de Gestión de Artículos

Este es un proyecto de gestión de artículos utilizando **ASP.NET Core**, **Entity Framework Core**, **AutoMapper** y el patrón de repositorio. La aplicación permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre artículos, utilizando un **DTO** para separar los datos enviados desde y hacia la interfaz de usuario.

## Descripción

La aplicación permite gestionar artículos en una base de datos SQLite. Los usuarios pueden:
- **Ver una lista de artículos**.
- **Agregar nuevos artículos**.
- **Editar artículos existentes**.
- **Eliminar artículos**.

La arquitectura del proyecto sigue buenas prácticas de diseño, como el uso del patrón **Repositorio** para la manipulación de datos y **DTOs** (Data Transfer Objects) para separar la lógica del modelo de la vista.

## Requisitos

- **.NET 8.0** o superior.
- **SQLite** para la base de datos.

## Estructura del Proyecto

El proyecto está estructurado de la siguiente manera:


### **Explicación de la Estructura**

- **Controllers**: Contiene el controlador **`ArticuloController`**, que maneja las operaciones CRUD de los artículos.
- **Models**: Contiene el modelo **`Articulo`** (representa los datos de los artículos en la base de datos) y **`ArticuloDto`** (el DTO utilizado para transferir los datos).
- **Repositories**: Aquí se encuentra la interfaz **`IArticuloRepository`** y su implementación **`ArticuloRepository`**. El repositorio maneja la lógica de acceso a datos utilizando **Entity Framework**.
- **Mapping**: El archivo **`AutoMapperProfile.cs`** configura AutoMapper para mapear entre **`Articulo`** y **`ArticuloDto`**.
- **Views**: Contiene las vistas **`Create.cshtml`**, **`Edit.cshtml`**, **`Delete.cshtml`**, y **`Index.cshtml`**. Estas vistas están construidas para trabajar con **`ArticuloDto`**.
- **Data**: Configuración de Entity Framework para manejar la conexión y las operaciones con la base de datos SQLite.
- **wwwroot**: Archivos estáticos como imágenes, hojas de estilo y scripts de JavaScript.

## Cómo Funciona la Aplicación

La aplicación está diseñada para manejar artículos con los siguientes pasos:

1. **Crear artículo**: Los usuarios pueden ingresar nuevos artículos a través de la vista **Create**. Los datos son enviados al controlador, donde se validan y se guardan en la base de datos.
2. **Ver artículos**: En la vista **Index**, se muestran todos los artículos almacenados en la base de datos.
3. **Editar artículo**: Desde la vista **Index**, se puede hacer clic en "Editar" para modificar un artículo. Los cambios se reflejan en la base de datos.
4. **Eliminar artículo**: En la vista **Delete**, se solicita confirmación antes de eliminar un artículo. Al confirmar, el artículo es eliminado de la base de datos.

### **Uso de AutoMapper**:

- **AutoMapper** se utiliza para mapear entre el modelo de base de datos **`Articulo`** y el **`ArticuloDto`**, asegurando que los datos transferidos entre la base de datos y la vista estén separados.
- **`AutoMapperProfile.cs`** contiene la configuración para mapear entre estos dos modelos. El mapeo de **`Articulo`** a **`ArticuloDto`** se realiza en las acciones del controlador.

### **Repositorio**:

- El repositorio **`ArticuloRepository`** es responsable de realizar las operaciones de CRUD (Crear, Leer, Actualizar, Eliminar) en la base de datos utilizando **Entity Framework**.
- **`IArticuloRepository`** es la interfaz que define los métodos que deben ser implementados en **`ArticuloRepository`**.

### **Data Transfer Object (DTO)**:

- El uso de **`ArticuloDto`** como Data Transfer Object permite separar la lógica interna de la base de datos de lo que se muestra en la vista.
- **`ArticuloDto`** solo contiene los campos necesarios para la vista, mientras que **`Articulo`** contiene la estructura completa que se guarda en la base de datos.




