using System;
using System.Collections.Generic;

namespace VeterinariaAPI.Entidades;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; }

    public virtual ICollection<TieFacturaCabecera> TieFacturaCabeceras { get; set; } = new List<TieFacturaCabecera>();
}
