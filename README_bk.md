# Programacion2ClientesAPI

API REST desarrollada en .NET 10 para la administración de clientes.

## Tecnologías utilizadas

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- Pomelo Entity Framework Core MySQL
- MySQL
- Visual Studio Code
- Postman

## Base de datos

Base de datos:

db_programacion2_clientes

Tabla:

clientes

## Campos

- Id_cliente
- CUI
- NIT
- Nombres
- Apellidos
- Direccion
- Telefono
- Fecha_Nacimiento

## Endpoints

### Obtener todos los clientes

GET /api/clientes

### Obtener cliente por ID

GET /api/clientes/{id}

### Crear cliente

POST /api/clientes

### Actualizar cliente

PUT /api/clientes/{id}

### Eliminar cliente

DELETE /api/clientes/{id}

## Ejecutar el proyecto

```bash
dotnet restore
dotnet run
```
