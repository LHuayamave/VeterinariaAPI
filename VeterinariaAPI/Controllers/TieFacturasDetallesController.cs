using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Conexiones;
using VeterinariaAPI.Entidades;

namespace VeterinariaAPI.Controllers
{
    [Route("api/facturasDetalles")]
    [ApiController]
    public class TieFacturasDetallesController : ControllerBase
    {
        private readonly veterinariaContext _context;
        public TieFacturasDetallesController(veterinariaContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listado")]
        public async Task<ActionResult<List<TieFacturaDetalle>>> Get()
        {
            try
            {
                return await _context.TieFacturaDetalles.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("obtener/{id:int}")]
        public async Task<ActionResult<TieFacturaDetalle>> Get(int id)
        {
            var facturaDetalle = await _context.TieFacturaDetalles.FirstOrDefaultAsync(x => x.IdFacturaDetalle == id);

            if (facturaDetalle == null)
            {
                return NotFound();
            }
            return facturaDetalle;

        }
    }
}
