using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Conexiones;
using VeterinariaAPI.Entidades;

namespace VeterinariaAPI.Negocio
{
    public class ValidacionesFacturaCabecera
    {
        private readonly veterinariaContext _context;
        public ValidacionesFacturaCabecera(veterinariaContext context)
        {
            _context = context;
        }
        public async Task<bool> validarNumeroDocumento(TieFacturaCabecera tieFacturaCabecera)
        {
            return await _context.TieFacturaCabeceras.AnyAsync(x => x.NumeroFactura == tieFacturaCabecera.NumeroFactura);
        }
    }
}
