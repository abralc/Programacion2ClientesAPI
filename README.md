# Programacion2ClientesAPI

API REST desarrollada en **.NET 10** para la administración de clientes, utilizando **ASP.NET Core**, **Entity Framework Core** y **MySQL**.

El proyecto permite realizar operaciones CRUD completas sobre la información de clientes y cuenta con documentación interactiva mediante **Swagger**.

---

## Tecnologías utilizadas

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- Pomelo.EntityFrameworkCore.MySql
- MySQL
- Swagger / Swashbuckle
- Visual Studio Code
- Postman
- Git
- GitHub

---

## Objetivo del proyecto

Desarrollar una API REST para administrar clientes mediante operaciones CRUD.

La API permite:

- Consultar todos los clientes.
- Consultar un cliente específico por ID.
- Registrar nuevos clientes.
- Actualizar clientes existentes.
- Eliminar clientes.

---

## Modelo Cliente

El modelo `Cliente` contiene los siguientes campos:

| Campo            | Tipo     | Descripción                         |
| ---------------- | -------- | ----------------------------------- |
| Id_cliente       | int      | Identificador único del cliente     |
| CUI              | string   | Código Único de Identificación      |
| NIT              | string   | Número de Identificación Tributaria |
| Nombres          | string   | Nombres del cliente                 |
| Apellidos        | string   | Apellidos del cliente               |
| Direccion        | string   | Dirección del cliente               |
| Telefono         | string   | Número de teléfono                  |
| Fecha_Nacimiento | DateTime | Fecha de nacimiento                 |

---

## Estructura del proyecto

```text
Programacion2ClientesAPI/
│
├── Controllers/
│   └── ClientesController.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Models/
│   └── Cliente.cs
│
├── Migrations/
│
├── Properties/
│   └── launchSettings.json
│
├── Program.cs
├── appsettings.json
├── Programacion2ClientesAPI.csproj
├── Programacion2ClientesAPI.http
├── README.md
└── .gitignore
```
