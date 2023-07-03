using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using VeterinariaAPI.Conexiones;
//using VeterinariaAPI.Entidades;
//using Microsoft.AspNetCore.Http;

namespace VeterinariaAPI.Controllers
{
    /*[ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly veterinariaContext _context;

        public UsuariosController(veterinariaContext context)
        {
            _context = context;
        }

        // GET: UsuariosControlador
        [HttpGet]
        [Route("listado")]

        public async Task<ActionResult<List<Usuario>>> Get()
        {
            try {
                return await _context.Usuarios.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }
    }*/
}