using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Conexiones;
using VeterinariaAPI.Entidades;
using VeterinariaAPI.Negocio;

namespace VeterinariaAPI.Controllers
{
    [Route("api/empresas")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly veterinariaContext _context;
        private readonly ValidacionesEmpresa _validacionesEmpresa;

        public EmpresasController(veterinariaContext context, ValidacionesEmpresa validacionesEmpresa)
        {
            _context = context;
            _validacionesEmpresa = validacionesEmpresa;

        }
        [HttpGet]
        [Route("listado")]

        public async Task<ActionResult<List<TieEmpresa>>> ListarEmpresas()
        {
            try
            {
                return await _context.TieEmpresas.ToListAsync();
            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }
        }

        [HttpGet]
        [Route("obtener/{id:int}")]
        public async Task<ActionResult<TieEmpresa>> ListarEmpresaId(int id)
        {
            try
            {
                var empresa = await _context.TieEmpresas.FirstOrDefaultAsync(x => x.IdEmpresa == id);

                if (empresa == null)
                {
                    return BadRequest($"No existe una Empresa con el id: {id}");
                }
                return empresa;

            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }
        }

        [HttpPost]
        [Route("insertar")]
        public async Task<ActionResult> InsertarEmpresa(TieEmpresa tieEmpresa)
        {
            try
            {
                bool existeMismoNombre = await _validacionesEmpresa.validarNombreEmpresa(tieEmpresa);
                bool existeNumeroDocumento = await _validacionesEmpresa.validarNumeroDocumento(tieEmpresa);
                if (existeMismoNombre || existeNumeroDocumento)
                {
                    return BadRequest("¡Error! Revisar los datos ingresados");
                }

                _context.Add(tieEmpresa);
                await _context.SaveChangesAsync();
                return Ok("Datos ingresados exitosamente");
            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }

        }

        [HttpPut("actualizar/{id:int}")]
        public async Task<ActionResult> ActualizarEmpresa(TieEmpresa tieEmpresa, int id)
        {
            try
            {
                bool existeIdEmpresa = await _validacionesEmpresa.validarIdEmpresa(tieEmpresa);

                if (!existeIdEmpresa)
                {
                    return BadRequest($"No existe una Empresa con el id: {id}");
                }

                //bool existeNombreEmpresa = await _validacionesEmpresa.validarNombreEmpresa(tieEmpresa);
                //bool existeNumeroDocumento = await _validacionesEmpresa.validarNumeroDocumento(tieEmpresa);

                //if (existeNombreEmpresa || existeNumeroDocumento)
                //{
                //    return BadRequest("Ya existe una empresa con los datos ingresados");
                //}

                _context.Update(tieEmpresa);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }

        }

        [HttpDelete("eliminar/{id:int}")]
        public async Task<ActionResult> ElimminarEmpresa(int id)
        {
            try
            {
                var existeEmpresa = await _context.TieEmpresas.AnyAsync(x => x.IdEmpresa == id);
                if (!existeEmpresa)
                {
                    return BadRequest($"No existe una empresa con el id: {id}"); ;
                }
                _context.Remove(new TieEmpresa() { IdEmpresa = id });
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
