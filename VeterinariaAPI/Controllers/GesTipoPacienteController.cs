using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Entidades;
using VeterinariaAPI.Negocio;

namespace VeterinariaAPI.Controllers
{
    [ApiController]
    [Route("api/tipoPaciente")]
    public class GesTipoPacienteController : ControllerBase
    {
        private readonly veterinariaContext _context;
        private readonly TipoPacienteService _service;

        public GesTipoPacienteController(veterinariaContext context, TipoPacienteService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        [Route("listado")]
        public async Task<ActionResult<List<GesTipoPaciente>>> Get()
        {
            try
            {
                return await _context.GesTipoPacientes
                    .Include(x => x.GesPacientes)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }
        }

        [HttpGet]
        [Route("obtener/{id}")]
        public async Task<ActionResult<GesTipoPaciente>> Get(string id)
        {
            try
            {
                var tipoPaciente = await _context.GesTipoPacientes
                    .Include(x => x.GesPacientes)
                    .FirstOrDefaultAsync(x => x.idTipoPaciente == id);

                if (tipoPaciente == null)
                {
                    return NotFound();
                }
                return tipoPaciente;

            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }
        }

        [HttpPost]
        [Route("insertar")]
        public async Task<ActionResult> Post(GesTipoPaciente tipoPaciente)
        {
            try
            {
                bool existeTipoPaciente = await _service.ExisteTipoPacienteDuplicado(tipoPaciente);

                if (existeTipoPaciente)
                {
                    return Content("Ya existe el tipo de paciente ingresado");
                }

                _context.GesTipoPacientes.Add(tipoPaciente);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }
        }

        [HttpPut]
        [Route("actualizar/{id}")]
        public async Task<ActionResult> Put(string id, GesTipoPaciente tipoPaciente)
        {
            try
            {
                var tipoPacienteBD = await _context.GesTipoPacientes.AnyAsync(x => x.idTipoPaciente == id);

                if (!tipoPacienteBD)
                {
                    return NotFound();
                }

                bool existeTipoPaciente = await _service.ExisteTipoPacienteDuplicado(tipoPaciente);

                if (existeTipoPaciente)
                {
                    return Content("Ya existe el tipo de paciente ingresado");
                }

                _context.Update(tipoPaciente);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var tipoPaciente = await _context.GesTipoPacientes.FirstOrDefaultAsync(x => x.idTipoPaciente == id);

                if (tipoPaciente == null)
                {
                    return NotFound();
                }

                _context.GesTipoPacientes.Remove(tipoPaciente);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }
        }
    }
}
