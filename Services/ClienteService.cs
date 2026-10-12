using Microsoft.EntityFrameworkCore;
using Programacion2ClientesAPI.Data;
using Programacion2ClientesAPI.DTOs;
using Programacion2ClientesAPI.Models;

namespace Programacion2ClientesAPI.Services;

public class ClienteService : IClienteService
{
    private readonly AppDbContext _context;

    public ClienteService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ClienteDto>> ObtenerTodosAsync()
    {
        return await _context.Clientes
            .AsNoTracking()
            .OrderBy(c => c.Id_cliente)
            .Select(c => new ClienteDto
            {
                Id_cliente = c.Id_cliente,
                CUI = c.CUI,
                NIT = c.NIT,
                Nombres = c.Nombres,
                Apellidos = c.Apellidos,
                Direccion = c.Direccion,
                Telefono = c.Telefono,
                Fecha_Nacimiento = c.Fecha_Nacimiento
            })
            .ToListAsync();
    }

    public async Task<ClienteDto?> ObtenerPorIdAsync(int id)
    {
        return await _context.Clientes
            .AsNoTracking()
            .Where(c => c.Id_cliente == id)
            .Select(c => new ClienteDto
            {
                Id_cliente = c.Id_cliente,
                CUI = c.CUI,
                NIT = c.NIT,
                Nombres = c.Nombres,
                Apellidos = c.Apellidos,
                Direccion = c.Direccion,
                Telefono = c.Telefono,
                Fecha_Nacimiento = c.Fecha_Nacimiento
            })
            .FirstOrDefaultAsync();
    }

    public async Task<(bool Exito, string? Error, ClienteDto? Cliente)>
        CrearAsync(CrearClienteDto dto)
    {
        var cui = dto.CUI.Trim();
        var nit = dto.NIT.Trim();

        var errorFecha = ValidarFechaNacimiento(dto.Fecha_Nacimiento);
        if (errorFecha is not null)
        {
            return (false, errorFecha, null);
        }

        if (await _context.Clientes.AnyAsync(c => c.CUI == cui))
        {
            return (false, "Ya existe un cliente con ese CUI.", null);
        }

        if (await _context.Clientes.AnyAsync(c => c.NIT == nit))
        {
            return (false, "Ya existe un cliente con ese NIT.", null);
        }

        var cliente = new Cliente
        {
            CUI = cui,
            NIT = nit,
            Nombres = dto.Nombres.Trim(),
            Apellidos = dto.Apellidos.Trim(),
            Direccion = LimpiarOpcional(dto.Direccion),
            Telefono = LimpiarOpcional(dto.Telefono),
            Fecha_Nacimiento = dto.Fecha_Nacimiento.Date
        };

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        return (true, null, MapearDto(cliente));
    }

    public async Task<(bool Exito, string? Error)>
        ActualizarAsync(int id, ActualizarClienteDto dto)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente is null)
        {
            return (false, "Cliente no encontrado.");
        }

        var cui = dto.CUI.Trim();
        var nit = dto.NIT.Trim();

        var errorFecha = ValidarFechaNacimiento(dto.Fecha_Nacimiento);
        if (errorFecha is not null)
        {
            return (false, errorFecha);
        }

        var cuiDuplicado = await _context.Clientes
            .AnyAsync(c => c.CUI == cui && c.Id_cliente != id);

        if (cuiDuplicado)
        {
            return (false, "Ya existe otro cliente con ese CUI.");
        }

        var nitDuplicado = await _context.Clientes
            .AnyAsync(c => c.NIT == nit && c.Id_cliente != id);

        if (nitDuplicado)
        {
            return (false, "Ya existe otro cliente con ese NIT.");
        }

        cliente.CUI = cui;
        cliente.NIT = nit;
        cliente.Nombres = dto.Nombres.Trim();
        cliente.Apellidos = dto.Apellidos.Trim();
        cliente.Direccion = LimpiarOpcional(dto.Direccion);
        cliente.Telefono = LimpiarOpcional(dto.Telefono);
        cliente.Fecha_Nacimiento = dto.Fecha_Nacimiento.Date;

        await _context.SaveChangesAsync();

        return (true, null);
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente is null)
        {
            return false;
        }

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();

        return true;
    }

    private static ClienteDto MapearDto(Cliente cliente)
    {
        return new ClienteDto
        {
            Id_cliente = cliente.Id_cliente,
            CUI = cliente.CUI,
            NIT = cliente.NIT,
            Nombres = cliente.Nombres,
            Apellidos = cliente.Apellidos,
            Direccion = cliente.Direccion,
            Telefono = cliente.Telefono,
            Fecha_Nacimiento = cliente.Fecha_Nacimiento
        };
    }

    private static string? ValidarFechaNacimiento(DateTime fecha)
    {
        var fechaNormalizada = fecha.Date;

        if (fechaNormalizada > DateTime.Today)
        {
            return "La fecha de nacimiento no puede ser futura.";
        }

        if (fechaNormalizada < DateTime.Today.AddYears(-120))
        {
            return "La fecha de nacimiento no es válida.";
        }

        return null;
    }

    private static string? LimpiarOpcional(string? valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
        {
            return null;
        }

        return valor.Trim();
    }
}
