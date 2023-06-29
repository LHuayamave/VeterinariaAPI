using System;
using System.Collections.Generic;

namespace VeterinariaAPI.Entidades;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string NombreCliente { get; set; }

    public string NumDocumentoCliente { get; set; }

    public virtual ICollection<TieFacturaCabecera> TieFacturaCabeceras { get; set; } = new List<TieFacturaCabecera>();
}
