using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Conexiones;
using VeterinariaAPI.Entidades;

namespace VeterinariaAPI.Negocio
{
    public class ValidacionesEmpresa
    {
        private readonly veterinariaContext _context;

        public ValidacionesEmpresa(veterinariaContext context)
        {
            _context = context;
        }

        public async Task<bool> validarIdEmpresa(TieEmpresa tieEmpresa)
        {
            return await _context.TieEmpresas.AnyAsync(x => x.IdEmpresa == tieEmpresa.IdEmpresa);
        }
        public async Task<bool> validarNumeroDocumento(TieEmpresa tieEmpresa)
        {
            return await _context.TieEmpresas.AnyAsync(x => x.NumDocumento == tieEmpresa.NumDocumento);
        }

        public async Task<bool> validarNombreEmpresa(TieEmpresa tieEmpresa)
        {
            return await _context.TieEmpresas.AnyAsync(x => x.NombreEmpresa == tieEmpresa.NombreEmpresa);
        }
    }
}
