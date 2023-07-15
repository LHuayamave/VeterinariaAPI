using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Entidades;
using VeterinariaAPI.Negocio;

namespace VeterinariaAPI.Controllers
{
    [ApiController]
    [Route("api/pacientes")]
    public class GesPacientesController : ControllerBase
    {
        private readonly veterinariaContext _context;
        private readonly PacientesServices _pacientesServices;

        public GesPacientesController(veterinariaContext context, PacientesServices pacientesServices)
        {
            _context = context;
            _pacientesServices = pacientesServices;
        }

        [HttpGet]
        [Route("listado")]
        public async Task<ActionResult<List<GesPaciente>>> Get()
        {
            try
            {
                return await _context.GesPacientes.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrió un error" + ex.Message);
            }
        }

        [HttpGet]
        [Route("obtener/{id:int}")]
        public async Task<ActionResult<GesPaciente>> Get(int id)
        {
            try
            {
                var paciente = await _context.GesPacientes.FirstOrDefaultAsync(x => x.idPaciente == id);

                if (paciente == null)
                {
                    return NotFound();
                }
                return paciente;

            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrió un error" + ex.Message);
            }
        }

        [HttpPost]
        [Route("insertar")]
        public async Task<ActionResult> Post(GesPaciente paciente)
        {
            try
            {
                bool existePaciente = await _pacientesServices.ExistePacienteDuplicado(paciente);

                if (existePaciente)
                {
                    return BadRequest("Ya existe un paciente con los mismos datos");
                }

                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrió un error" + ex.Message);
            }
        }

        [HttpPut]
        [Route("actualizar/{id:int}")]
        public async Task<ActionResult> Put(GesPaciente paciente, int id)
        {
            try
            {
                var pacienteDB = await _context.GesPacientes.AnyAsync(x => x.idPaciente == id);

                if (!pacienteDB)
                {
                    return NotFound();
                }

                bool existePaciente = await _pacientesServices.ExistePacienteDuplicado(paciente);

                if (existePaciente)
                {
                    return BadRequest("Ya existe un paciente con los mismos datos");
                }

                _context.Update(paciente);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrió un error" + ex.Message);
            }
        }

        [HttpDelete]
        [Route("eliminar/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var paciente = await _context.GesPacientes.FirstOrDefaultAsync(x => x.idPaciente == id);

                if (paciente == null)
                {
                    return NotFound();
                }

                _context.GesPacientes.Remove(paciente);
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
