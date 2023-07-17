﻿using Microsoft.AspNetCore.Http;
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
                return Content("Ocurrió un error" + ex.Message);
            }
        }
        [HttpGet]
        [Route("obtener/{id:int}")]
        public async Task<ActionResult<TieFacturaDetalle>> Get(int id)
        {
            try
            {
                var facturaDetalle = await _context.TieFacturaDetalles.FirstOrDefaultAsync(x => x.IdFacturaDetalle == id);

                if (facturaDetalle == null)
                {
                    return NotFound();
                }
                return facturaDetalle;
            }
            catch(Exception ex) {
                return Content("Ocurrió un error" + ex.Message);
            }
            
        }

        [HttpPost]
        [Route("insertar")]
        public async Task<ActionResult> Post(TieFacturaDetalle facturaDetalle)
        {
            try
            {
                _context.Add(facturaDetalle);
                await _context.SaveChangesAsync();
                return Ok("Datos ingresados exitosamente");
            }
            catch(Exception ex)
            {
                return Content("Ocurrió un error" + ex.Message);
            }       
        }
    }
}
