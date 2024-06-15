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
- [SQL Server Management Studio 19](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15) (2019 o superior)

## Instalación

1. **Clona el repositorio**

   ```sh
   git clone https://github.com/tu-usuario/tu-repositorio.git

2. **Clona el Query del la BD**
     ```sh
   https://github.com/Kenneth19920/BD-Crud-Test.git
     
4. **Abre SQL Server**
   
   Ejecutar scripts llamado BDCrudTest.sql

5. **Abre el proyecto en Visual Studio**

   Navega hasta la carpeta donde clonaste el repositorio y abre el archivo .sln.

   
6. **Configura la cadena de conexión**
   
    ```sh
    <connectionStrings>
		<add name="DefaultConnection" connectionString="Data Source= SERVER-NAME ;initial catalog=BDCrudTest;integrated security=True;MultipleActiveResultSets=True" providerName="System.Data.SqlClient" />
	</connectionStrings>

7.  Restaurar paquetes NuGet
 En Visual Studio, ve a Tools > NuGet Package Manager > Manage NuGet Packages for Solution y asegúrate de restaurar todos los paquetes NuGet necesarios.

## Uso

Una vez configurado el entorno y la base de datos, puedes ejecutar el proyecto presionando F5 en Visual Studio o usando la opción Start Debugging. La aplicación debería abrirse en tu navegador predeterminado
  

    
