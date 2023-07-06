using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Conexiones;
using VeterinariaAPI.Entidades;

namespace VeterinariaAPI.Controllers
{
    [Route("api/facturasFormasPagos")]
    [ApiController]
    public class TieFacturasFormasPagosController : ControllerBase
    {
        private readonly veterinariaContext _context;
        public TieFacturasFormasPagosController(veterinariaContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listado")]
        public async Task<ActionResult<List<TieFacturaFormaPago>>> Get()
        {
            try
            {
                return await _context.TieFacturaFormaPagos.ToListAsync();
            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }
        }

        [HttpGet]
        [Route("obtener/{id:int}")]
        public async Task<ActionResult<TieFacturaFormaPago>> Get(int id)
        {
            try
            {
                var facturaFormaPago = await _context.TieFacturaFormaPagos.FirstOrDefaultAsync(x => x.IdFacturaFormaPago == id);

                if (facturaFormaPago == null)
                {
                    return NotFound();
                }
                return facturaFormaPago;
            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }

        }

        [HttpPost]
        [Route("insertar")]
        public async Task<ActionResult> Post(TieFacturaFormaPago tieFacturaFormaPago)
        {
            try
            {
                _context.Add(tieFacturaFormaPago);
                await _context.SaveChangesAsync();
                return Ok();

            }
            catch(Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }
        }
    }
}
