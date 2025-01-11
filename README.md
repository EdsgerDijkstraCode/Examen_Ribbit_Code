Introducción
API REST con .NET core 8

Descripcion
API REST con tecnologias .NET core 8 , patron Solid y base de datos SQL Lite

Requisitos
-[.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) 
-[Visual Studio 2022](https://visualstudio.microsoft.com/) o otro entorno de desarrollo compatible.
-[SQLite](https://www.sqlite.org/index.html)

Instalación
1. Clonar repositorio: bash git clone https://github.com/EdsgerDijkstraCode/Examen_Ribbit_Code.git

 Configuración de SQLite.

 
Comandos para ejecutar las migraciones:

Aplicar los siguientes comandos en caso de modificar el modelo de datos:

dotnet ef migrations add InitialCreate

dotnet ef database update

 Ejemplos de peticiones API:

 http://localhost:5153/api/Productos?PrecioInferior=0&PrecioSuperior=0
 
 http://localhost:5153/api/Productos/1
