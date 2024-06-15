# Crud Test – Kenneth Alvarado

## Descripción de la Aplicación

La aplicación es un sistema CRUD (Crear, Leer, Actualizar, Eliminar) para la gestión de productos y categorías. Los usuarios pueden realizar las siguientes acciones:

- Listar productos por categorías.
- Listar todas las categorías.
- Agregar, editar y eliminar categorías.

## Requisitos

Para ejecutar y desarrollar este proyecto, necesitarás las siguientes herramientas:

- [Visual Studio](https://visualstudio.microsoft.com/) (2019 o superior) con soporte para ASP.NET y desarrollo web.
- [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472)
- [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) (cualquier versión compatible)
- [SQL Server Management Studio 19](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)

## Instalación

1. **Clona el repositorio**

   ```sh
   git clone https://github.com/tu-usuario/tu-repositorio.git

2. **Abre el proyecto en Visual Studio**

   Navega hasta la carpeta donde clonaste el repositorio y abre el archivo .sln.

3. **Configura la cadena de conexión**
   
    ```sh
    <connectionStrings>
      <add name="DefaultConnection" connectionString="Server=tu-servidor;Database=tu-base-de-datos;User Id=tu- usuario;Password=tu-contraseña;" providerName="System.Data.SqlClient" />
    </connectionStrings>

4.  Restaurar paquetes NuGet
 En Visual Studio, ve a Tools > NuGet Package Manager > Manage NuGet Packages for Solution y asegúrate de restaurar todos los paquetes NuGet necesarios.
  

    
