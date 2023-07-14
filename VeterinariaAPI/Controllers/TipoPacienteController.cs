using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Entidades;

namespace VeterinariaAPI.Controllers
{
    [ApiController]
    [Route("api/tipoPaciente")]
    public class TipoPacienteController:ControllerBase
    {
        private readonly veterinariaContext _context;

        public TipoPacienteController(veterinariaContext context)
        {
            _context = context;
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
    }
}
