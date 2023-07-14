using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Conexiones;
using VeterinariaAPI.Entidades;
using VeterinariaAPI.Negocio;

namespace VeterinariaAPI.Controllers
{
    [Route("api/formasPagos")]
    [ApiController]
    public class TieFormasPagosController : ControllerBase
    {
        private readonly veterinariaContext _context;
        private readonly ValidacionesFormaPago _validacionesFormaPago;
        public TieFormasPagosController(veterinariaContext context, ValidacionesFormaPago validacionesFormaPago)
        {
            _context = context;
            _validacionesFormaPago = validacionesFormaPago;
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
                return Content("Ocurrió un error" + ex.Message);
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
                    return BadRequest($"No existe una forma de pago con el id: {id}");
                }
                return formaPago;
            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }

        }

        [HttpPost]
        [Route("insertar")]
        public async Task<ActionResult> Post(TieFormaPago tieFormaPago)
        {
            try
            {
                bool existeMismoNombrePago = await _validacionesFormaPago.validarNombreFormaPago(tieFormaPago);
                if (existeMismoNombrePago)
                {
                    return BadRequest("Ya existe una forma de pago con ese nombre");
                }
                _context.Add(tieFormaPago);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }
        }

        [HttpPut("actualizar/{id:int}")]
        public async Task<ActionResult> Put(int id, TieFormaPago tieFormaPago)
        {
            try
            {
                var existeFormaPago = await _context.TieFormaPagos.AnyAsync(x => x.IdFormaPago == id);
                var existeNombreFormaPago = await _context.TieFormaPagos.AnyAsync(x => x.Nombre == tieFormaPago.Nombre);
                if (!existeFormaPago)
                {
                    return BadRequest($"No existe una forma de pago con el id {id}");
                }
                if (existeNombreFormaPago)
                {
                    return BadRequest("Ya existe una forma de pago con los datos ingresados");
                }
                _context.Update(tieFormaPago);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
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
                    return BadRequest($"No existe una forma de pago con el id {id}");
                }
                _context.Remove(new TieFormaPago() { IdFormaPago = id });
                await _context.SaveChangesAsync();

                return Ok();

            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }
        }
    }
}
