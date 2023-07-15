using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Entidades;

namespace VeterinariaAPI.Negocio
{
    public class TipoPacienteService
    {
        private readonly veterinariaContext _context;

        public TipoPacienteService(veterinariaContext context)
        {
            _context = context;
        }

        public async Task<bool> ExisteTipoPacienteDuplicado(GesTipoPaciente tipoPaciente)
        {
            return await _context.GesTipoPacientes.AnyAsync(c =>
                c.idTipoPaciente == tipoPaciente.idTipoPaciente &&
                c.tipoPaciente == tipoPaciente.tipoPaciente
                                      );
        }
    }
}
