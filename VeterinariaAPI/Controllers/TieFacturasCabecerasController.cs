using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Conexiones;
using VeterinariaAPI.Entidades;
using VeterinariaAPI.Negocio;

namespace VeterinariaAPI.Controllers
{
    [Route("api/facturasCabeceras")]
    [ApiController]
    public class TieFacturasCabecerasController : ControllerBase
    {
        private readonly veterinariaContext _context;
        private readonly ValidacionesFacturaCabecera _validacionesFacturaCabecera;

        public TieFacturasCabecerasController(veterinariaContext context, ValidacionesFacturaCabecera validacionesFacturaCabecera)
        {
            _context = context;
            _validacionesFacturaCabecera = validacionesFacturaCabecera;
        }

        [HttpGet]
        [Route("listado")]
        public async Task<ActionResult<List<TieFacturaCabecera>>> ObtenerListadoFacturasCabeceras()
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
        public async Task<ActionResult<TieFacturaCabecera>> ObtenerFacturaCabeceraId(int id)
        {
            try
            {
                var facturaCabecera = await _context.TieFacturaCabeceras.Include(x => x.oIdCliente).Include(x => x.oIdUsuario).Include(x => x.TieFacturaDetalles).FirstOrDefaultAsync(x => x.IdFacturaCabecera == id);

                if (facturaCabecera == null)
                {
                    return BadRequest($"No existe la factura con el id: {id}");
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
        public async Task<ActionResult> InsertarFacturaCabecera(TieFacturaCabecera facturaCabecera) 
        {
            try
            {
                bool existeNumeroFactura = await _validacionesFacturaCabecera.validarNumeroDocumento(facturaCabecera);
                if (existeNumeroFactura)
                {
                    return BadRequest("El numero de factura ingresado ya existe");
                }
                _context.Add(facturaCabecera);
                await _context.SaveChangesAsync();
                return Ok("Datos ingresados exitosamente");
            }
            catch(Exception ex)
            {
                return Content("Ocurrió un error " + ex.Message);
            }   
        }
    }
}
