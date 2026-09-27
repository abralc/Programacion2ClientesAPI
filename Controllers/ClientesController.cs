using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programacion2ClientesAPI.Data;
using Programacion2ClientesAPI.Models;

namespace Programacion2ClientesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/clientes/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound(new
                {
                    mensaje = "Cliente no encontrado"
                });
            }

            return cliente;
        }

        // POST: api/clientes
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetCliente),
                new { id = cliente.Id_cliente },
                cliente
            );
        }

        // PUT: api/clientes/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(
            int id,
            Cliente cliente
        )
        {
            if (id != cliente.Id_cliente)
            {
                return BadRequest(new
                {
                    mensaje = "El ID no coincide con el cliente"
                });
            }

            _context.Entry(cliente).State =
                EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound(new
                    {
                        mensaje = "Cliente no encontrado"
                    });
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/clientes/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound(new
                {
                    mensaje = "Cliente no encontrado"
                });
            }

            _context.Clientes.Remove(cliente);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(
                e => e.Id_cliente == id
            );
        }
    }
}