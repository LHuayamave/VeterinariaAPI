using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Entidades;
using VeterinariaAPI.Negocio;

namespace VeterinariaAPI.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class GesClientesController : ControllerBase
    {
        private readonly veterinariaContext _context;
        private readonly ClienteService _clienteService;

        public GesClientesController(veterinariaContext context, ClienteService clienteService)
        {
            _context = context;
            _clienteService = clienteService;
        }

        [HttpGet]
        [Route("listado")]
        public async Task<ActionResult<List<GesCliente>>> Get()
        {
            try
            {
                return await _context.GesClientes
                    .Include(x => x.GesPacientes)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }
        }

        [HttpGet]
        [Route("obtener/{id:int}")]
        public async Task<ActionResult<GesCliente>> Get(int id)
        {
            try
            {
                var cliente = await _context.GesClientes
                    .Include(x => x.GesPacientes)
                    .FirstOrDefaultAsync(x => x.idCliente == id);

                if (cliente == null)
                {
                    return NotFound();
                }
                return cliente;

            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }
        }

        [HttpPost]
        [Route("insertar")]
        public async Task<ActionResult> Post(GesCliente cliente)
        {
            try
            {
                bool existeCliente = await _clienteService.ExisteClienteDuplicado(cliente);
                if (existeCliente)
                {
                    return BadRequest("Los datos del cliente ya existen en la base de datos");
                }
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }
        }

        [HttpPut]
        [Route("actualizar/{id:int}")]
        public async Task<ActionResult> Put(GesCliente cliente, int id)
        {
            try
            {
                var clienteDB = await _context.GesClientes.AnyAsync(x => x.idCliente == id);
                if (!clienteDB)
                {
                    return NotFound();
                }

                bool existeCliente = await _clienteService.ExisteClienteDuplicado(cliente);
                if (existeCliente)
                {
                    return BadRequest("Los datos del cliente ya existen en la base de datos");
                }

                _context.Update(cliente);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error: " + ex.Message);
            }
        }


        [HttpDelete]
        [Route("eliminar/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var cliente = await _context.GesClientes.FirstOrDefaultAsync(x => x.idCliente == id);

                if (cliente == null)
                {
                    return NotFound();
                }

                _context.GesClientes.Remove(cliente);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrió un error" + ex.Message);
            }
        }
    }
}
