using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Conexiones;
using VeterinariaAPI.Entidades;

namespace VeterinariaAPI.Controllers
{
    [Route("api/formasPagos")]
    [ApiController]
    public class TieFormasPagosController : ControllerBase
    {
        private readonly veterinariaContext _context;
        public TieFormasPagosController(veterinariaContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listado")]
        public async Task<ActionResult<List<TieFormaPago>>> Get()
        {
            try
            {
                return await _context.TieFormaPagos.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }
    }
}
