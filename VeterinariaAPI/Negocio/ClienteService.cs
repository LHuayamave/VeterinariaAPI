using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Entidades;

namespace VeterinariaAPI.Negocio
{
    public class ClienteService
    {
        private readonly veterinariaContext _context;

        public ClienteService(veterinariaContext context)
        {
            _context = context;
        }

        public async Task<bool> ExisteClienteDuplicado(GesCliente cliente)
        {
            return await _context.GesClientes.AnyAsync(c =>
                c.numDocumento == cliente.numDocumento &&
                c.nombreCliente == cliente.nombreCliente &&
                c.apellidoCliente == cliente.apellidoCliente &&
                c.fechaNac == cliente.fechaNac &&
                c.telefono == cliente.telefono &&
                c.direccion == cliente.direccion &&
                c.correo == cliente.correo
            );
        }
    }
}
