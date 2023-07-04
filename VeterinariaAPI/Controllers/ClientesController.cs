using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using VeterinariaAPI.Conexiones;
//using VeterinariaAPI.Entidades;
using Microsoft.AspNetCore.Http;

namespace VeterinariaAPI.Controllers
{
    //[ApiController]
    //[Route("api/clientes")]
    //public class ClientesController : ControllerBase
    //{
    //    private readonly veterinariaContext _context;
    //    public ClientesController(veterinariaContext context)
    //    {
    //        _context = context;
    //    }

    //    [HttpGet]
    //    [Route("listado")]
    //    public async Task<ActionResult<List<Cliente>>> Get()
    //    {
    //        try
    //        {
    //            return await _context.Clientes.ToListAsync();
    //        }
    //        catch (Exception ex)
    //        {
    //            return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
    //        }
    //    }

    //}
}
