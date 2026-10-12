using Microsoft.AspNetCore.Mvc;
using Programacion2ClientesAPI.DTOs;
using Programacion2ClientesAPI.Services;

namespace Programacion2ClientesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClientesController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    [ProducesResponseType(
        typeof(IEnumerable<ClienteDto>),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> GetClientes()
    {
        var clientes = await _clienteService.ObtenerTodosAsync();
        return Ok(clientes);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClienteDto>> GetCliente(int id)
    {
        var cliente = await _clienteService.ObtenerPorIdAsync(id);

        if (cliente is null)
        {
            return NotFound(new { mensaje = "Cliente no encontrado." });
        }

        return Ok(cliente);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<ClienteDto>> PostCliente(CrearClienteDto dto)
    {
        var resultado = await _clienteService.CrearAsync(dto);

        if (!resultado.Exito)
        {
            if (EsConflicto(resultado.Error))
            {
                return Conflict(new { mensaje = resultado.Error });
            }

            return BadRequest(new { mensaje = resultado.Error });
        }

        return CreatedAtAction(
            nameof(GetCliente),
            new { id = resultado.Cliente!.Id_cliente },
            resultado.Cliente
        );
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> PutCliente(
        int id,
        ActualizarClienteDto dto)
    {
        var resultado = await _clienteService.ActualizarAsync(id, dto);

        if (!resultado.Exito)
        {
            if (resultado.Error == "Cliente no encontrado.")
            {
                return NotFound(new { mensaje = resultado.Error });
            }

            if (EsConflicto(resultado.Error))
            {
                return Conflict(new { mensaje = resultado.Error });
            }

            return BadRequest(new { mensaje = resultado.Error });
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        var eliminado = await _clienteService.EliminarAsync(id);

        if (!eliminado)
        {
            return NotFound(new { mensaje = "Cliente no encontrado." });
        }

        return NoContent();
    }

    private static bool EsConflicto(string? error)
    {
        if (string.IsNullOrWhiteSpace(error))
        {
            return false;
        }

        return error.Contains("CUI", StringComparison.OrdinalIgnoreCase)
            || error.Contains("NIT", StringComparison.OrdinalIgnoreCase);
    }
}
