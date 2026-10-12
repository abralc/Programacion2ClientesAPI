# Programacion2ClientesAPI

API REST desarrollada con **ASP.NET Core sobre .NET 10** para la administración de clientes.

El proyecto utiliza **Entity Framework Core**, **Pomelo.EntityFrameworkCore.MySql** y **MySQL**, e incorpora DTOs para separar el modelo de persistencia de los datos que entran y salen de la API.

## Arquitectura

```text
Cliente / Blazor
      ↓ HTTP / JSON
ClientesController
      ↓
IClienteService
      ↓
ClienteService
      ↓
AppDbContext
      ↓
Entity Framework Core
      ↓
MySQL
```

## Estructura

```text
Programacion2ClientesAPI/
├── Controllers/
│   └── ClientesController.cs
├── Data/
│   └── AppDbContext.cs
├── DTOs/
│   ├── ClienteDto.cs
│   ├── CrearClienteDto.cs
│   └── ActualizarClienteDto.cs
├── Models/
│   └── Cliente.cs
├── Services/
│   ├── IClienteService.cs
│   └── ClienteService.cs
├── Migrations/
├── Program.cs
├── appsettings.json
└── Programacion2ClientesAPI.csproj
```

## Responsabilidades

- `Cliente`: entidad utilizada por Entity Framework Core para la persistencia.
- `ClienteDto`: define los datos que devuelve la API.
- `CrearClienteDto`: define y valida los datos permitidos en `POST`.
- `ActualizarClienteDto`: define y valida los datos permitidos en `PUT`.
- `ClienteService`: contiene la lógica de negocio y acceso a datos.
- `ClientesController`: expone los endpoints HTTP sin exponer directamente la entidad de base de datos.

## Funcionalidades

- Listar clientes.
- Consultar un cliente por ID.
- Registrar clientes.
- Actualizar clientes.
- Eliminar clientes.
- Validar CUI de 13 dígitos.
- Validar teléfono de 8 dígitos.
- Rechazar fechas de nacimiento futuras.
- Rechazar CUI o NIT duplicados.
- Documentar y probar la API mediante Swagger.

## Endpoints

| Método | Endpoint | Descripción |
|---|---|---|
| GET | `/api/clientes` | Lista todos los clientes |
| GET | `/api/clientes/{id}` | Consulta un cliente |
| POST | `/api/clientes` | Registra un cliente |
| PUT | `/api/clientes/{id}` | Actualiza un cliente |
| DELETE | `/api/clientes/{id}` | Elimina un cliente |

## Códigos HTTP principales

- `200 OK`
- `201 Created`
- `204 No Content`
- `400 Bad Request`
- `404 Not Found`
- `409 Conflict`

## Base de datos

Base de datos utilizada:

```text
db_programacion2_clientes
```

Para aplicar migraciones:

```bash
dotnet ef database update
```

Si todavía no existe la migración de índices únicos para CUI y NIT:

```bash
dotnet ef migrations add AgregarIndicesUnicosClientes
dotnet ef database update
```

## Ejecutar

```bash
dotnet restore
dotnet build
dotnet run
```

En el entorno utilizado durante el desarrollo:

```text
http://localhost:5169
```

Swagger:

```text
http://localhost:5169/swagger
```

## CORS

Durante el desarrollo, la API permite solicitudes desde:

```text
http://localhost:5122
```

correspondiente a la aplicación Blazor.

## Repositorio

```text
https://github.com/abralc/Programacion2ClientesAPI
```

## Autor

**Abraham López**

Proyecto académico de **Programación II**.


## Validaciones de datos

La API utiliza DTOs para controlar los datos de entrada y salida. Además valida:

- CUI: exactamente 13 dígitos.
- NIT: únicamente dígitos, entre 8 y 15 caracteres.
- Teléfono: exactamente 8 dígitos.
- Fecha de nacimiento: no puede ser futura.
- CUI y NIT no pueden repetirse.

Las respuestas de validación utilizan códigos HTTP como `400 Bad Request` y `409 Conflict`.
