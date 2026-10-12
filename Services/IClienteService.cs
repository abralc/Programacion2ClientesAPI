using Programacion2ClientesAPI.DTOs;

namespace Programacion2ClientesAPI.Services;

public interface IClienteService
{
    Task<List<ClienteDto>> ObtenerTodosAsync();
    Task<ClienteDto?> ObtenerPorIdAsync(int id);

    Task<(bool Exito, string? Error, ClienteDto? Cliente)>
        CrearAsync(CrearClienteDto dto);

    Task<(bool Exito, string? Error)>
        ActualizarAsync(int id, ActualizarClienteDto dto);

    Task<bool> EliminarAsync(int id);
}
