using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Conexiones;
using VeterinariaAPI.Entidades;

namespace VeterinariaAPI.Negocio
{
    public class Validaciones
    {
        private readonly veterinariaContext _context;
        public Validaciones(veterinariaContext context)
        {
            _context = context;
        }
        //public async task<bool> validarnumerodocumento(string numerodocumento)
        //{
        //    var existenumerodocumento = await _context.tieempresas.anyasync(x => x.numdocumento == numerodocumento);
        //    if (existenumerodocumento)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
