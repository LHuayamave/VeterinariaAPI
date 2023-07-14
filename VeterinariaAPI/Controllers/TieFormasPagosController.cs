using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        [Route("obtener/{id:int}")]
        public async Task<ActionResult<TieFormaPago>> Get(int id)
        {
            try
            {
                var formaPago = await _context.TieFormaPagos.FirstOrDefaultAsync(x => x.IdFormaPago == id);

                if (formaPago == null)
                {
                    return NotFound();
                }
                return formaPago;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }

        }

        [HttpPost]
        [Route("insertar")]
        public async Task<ActionResult> Post(TieFormaPago tieFormaPago)
        {
            try
            {
                _context.Add(tieFormaPago);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        [HttpPut("actualizar/{id:int}")] // api/actualizar/#
        public async Task<ActionResult> Put(int id, TieFormaPago tieFormaPago)
        {
            try
            {
                var existeFormaPago = await _context.TieFormaPagos.AnyAsync(x => x.IdFormaPago == id);
                if (!existeFormaPago)
                {
                    return NotFound();
                }
                _context.Update(tieFormaPago);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        [HttpDelete("eliminar/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var existeFormaPago = await _context.TieFormaPagos.AnyAsync(x => x.IdFormaPago == id);
                if (!existeFormaPago)
                {
                    return NotFound();
                }
                _context.Remove(new TieFormaPago() { IdFormaPago = id });
                await _context.SaveChangesAsync();

                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }

        }
    }
}
