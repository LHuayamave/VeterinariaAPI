using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Entidades;

namespace VeterinariaAPI.Negocio
{
    public class PacientesServices
    {
        private readonly veterinariaContext _context;

        public PacientesServices(veterinariaContext context)
        {
            _context = context;
        }
        public async Task<bool> ExistePacienteDuplicado(GesPaciente paciente)
        {
            return await _context.GesPacientes.AnyAsync(c =>
                c.nombrePaciente == paciente.nombrePaciente &&
                c.fechaNac == paciente.fechaNac &&
                c.raza == paciente.raza &&
                c.idCliente == paciente.idCliente &&
                c.idTipoPaciente == paciente.idTipoPaciente
            );
        }

    }
}



