# API REST para Administración de Clientes

Proyecto desarrollado para el curso de Programación II.

La aplicación consiste en una API REST desarrollada con ASP.NET Core .NET 10 para realizar operaciones CRUD sobre clientes utilizando MySQL y Entity Framework Core.

## Tecnologías utilizadas

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- Pomelo.EntityFrameworkCore.MySql
- MySQL
- Visual Studio Code
- Postman

## Base de datos

Nombre de la base de datos:

db_programacion2_clientes

Tabla principal:

clientes

## Modelo Cliente

El modelo contiene los siguientes campos:

- Id_cliente
- CUI
- NIT
- Nombres
- Apellidos
- Direccion
- Telefono
- Fecha_Nacimiento

## Operaciones CRUD

La API permite realizar las siguientes operaciones:

| Método HTTP | Endpoint           | Descripción                |
| ----------- | ------------------ | -------------------------- |
| GET         | /api/clientes      | Obtener todos los clientes |
| GET         | /api/clientes/{id} | Obtener un cliente por ID  |
| POST        | /api/clientes      | Registrar un nuevo cliente |
| PUT         | /api/clientes/{id} | Actualizar un cliente      |
| DELETE      | /api/clientes/{id} | Eliminar un cliente        |

## Configuración

Modificar la cadena de conexión según la instalación local de MySQL:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=db_programacion2_clientes;user=root;password=TU_PASSWORD;"
  }
}
```
