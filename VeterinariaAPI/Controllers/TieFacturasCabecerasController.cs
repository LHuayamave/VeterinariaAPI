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
                return await _context.TieFacturaCabeceras.Include(x => x.oIdCliente).Include(x => x.TieFacturaDetalles).Include(x => x.oIdUsuario).ToListAsync();
            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }
        }


        [HttpGet]
        [Route("obtener/{id:int}")]
        public async Task<ActionResult<TieFacturaCabecera>> Get(int id)
        {
            try
            {
                var facturaCabecera = await _context.TieFacturaCabeceras.Include(x => x.oIdCliente).Include(x => x.oIdUsuario).Include(x => x.TieFacturaDetalles).FirstOrDefaultAsync(x => x.IdFacturaCabecera == id);

                if (facturaCabecera == null)
                {
                    return NotFound();
                }
                return facturaCabecera;

            }
            catch(Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }
        }

        [HttpPost]
        [Route("insertar")]
        public async Task<ActionResult> Post(TieFacturaCabecera facturaCabecera) 
        {
            try
            {
                _context.Add(facturaCabecera);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }
            
        }

        //[HttpPut("actualizar/{id:int}")] // api/autores/#
        //public async Task<ActionResult> Put(TieFacturaCabecera facturaCabecera, int id)
        //{
        //    try
        //    {
        //        var existe = await _context.TieFacturaCabeceras.AnyAsync(x => x.IdFacturaCabecera == id);
        //        if (!existe)
        //        {
        //            return NotFound();
        //        }

        //        _context.Update(facturaCabecera);
        //        await _context.SaveChangesAsync();
        //        return Ok();
        //    }
        //    catch(Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
        //    }
            
        //}

        //[HttpDelete("eliminar/{id:int}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        var existe = await _context.TieFacturaCabeceras.AnyAsync(x => x.IdFacturaCabecera == id);
        //        if (!existe)
        //        {
        //            return NotFound();
        //        }
        //        _context.Remove(new TieFacturaCabecera() { IdFacturaCabecera = id });
        //        await _context.SaveChangesAsync();

        //        return Ok();
        //    }
        //    catch(Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
        //    }
            
        //}

    }
}
