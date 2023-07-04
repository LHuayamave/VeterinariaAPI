using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Conexiones;
using VeterinariaAPI.Entidades;

namespace VeterinariaAPI.Controllers
{
    [Route("api/facturasCabeceras")]
    [ApiController]
    public class TieFacturasCabecerasController : ControllerBase
    {
        private readonly veterinariaContext _context;
        public TieFacturasCabecerasController(veterinariaContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listado")]
        public async Task<ActionResult<List<TieFacturaCabecera>>> Get()
        {
            try
            {
                return await _context.TieFacturaCabeceras.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }



        [HttpGet]
        [Route("obtener/{id:int}")]
        public async Task<ActionResult<TieFacturaCabecera>> Get(int id)
        {
            var facturaCabecera = await _context.TieFacturaCabeceras.FirstOrDefaultAsync(x => x.IdFacturaCabecera == id);

            if (facturaCabecera == null)
            {
                return NotFound();
            }
            return facturaCabecera;

        }

    }
}
