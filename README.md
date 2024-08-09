# Proyecto de Gestión de Vuelos

Este proyecto es una aplicación web para la gestión de vuelos, donde se pueden realizar las operaciones básicas de CRUD (Crear, Leer, Actualizar y Eliminar) en un listado de vuelos.

## Características

- **Crear Vuelos**: Permite agregar un nuevo vuelo con detalles como el número de vuelo, hora de llegada, aerolínea y estado de demora.
- **Leer Vuelos**: Lista todos los vuelos registrados, ordenados por la hora de llegada más próxima.
- **Modificar Vuelos**: Modifica la información de un vuelo existente.
- **Eliminar Vuelos**: Elimina un vuelo específico de la base de datos.

## Tecnologías Utilizadas

- **Backend**: ASP.NET Core con C#.
- **Base de Datos**: Entity Framework Core con SQL Server.

## Prerrequisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Bun](https://bun.sh/) instalado globalmente.
- SQL Server o cualquier otro motor de base de datos compatible con Entity Framework Core.

## Instalación

1. Clona el repositorio:

    ```bash
    git clone https://github.com/usuario/proyecto-vuelos.git
    cd proyecto-vuelos
    ```

2. Configura la cadena de conexión en `appsettings.json`:

    ```json
    {
      "ConnectionStrings": {
        "FlightContext": "Server=(localdb)\\mssqllocaldb;Database=FlightDB;Trusted_Connection=True;"
      }
    }
    ```

3. Restaura las dependencias del proyecto backend:

    ```bash
    dotnet restore
    ```

## Construcción y Ejecución

1. Ejecuta el proyecto backend:

    ```bash
    dotnet build
    dotnet run
    ```

2. Abre tu navegador web y navega a `https://localhost:7002` para acceder a la aplicación.

## Licencia

Este proyecto está licenciado bajo la Licencia MIT - ver el archivo [LICENSE](LICENSE) para más detalles.
