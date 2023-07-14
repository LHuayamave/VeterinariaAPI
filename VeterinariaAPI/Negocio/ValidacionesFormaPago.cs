using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Conexiones;
using VeterinariaAPI.Entidades;

namespace VeterinariaAPI.Negocio
{
    public class ValidacionesFormaPago
    {
        private readonly veterinariaContext _context;

        public ValidacionesFormaPago(veterinariaContext context)
        {
            _context = context;
        }

        public async Task<bool> validarNombreFormaPago(TieFormaPago tieFormaPago)
        {
            return await _context.TieFormaPagos.AnyAsync(x => x.Nombre == tieFormaPago.Nombre);
        }
    }
}
