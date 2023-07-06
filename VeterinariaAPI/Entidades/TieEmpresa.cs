using System;
using System.Collections.Generic;

namespace VeterinariaAPI.Entidades;

public partial class TieEmpresa
{
    public int IdEmpresa { get; set; }

    public string NombreEmpresa { get; set; }

    public string NumDocumento { get; set; }

    public string direccionEmpresa { get; set; }

    public string correoEmpresa { get; set; }

    public string telefonoEmpresa { get; set; }

    public virtual ICollection<TieFacturaCabecera> TieFacturaCabeceras { get; set; } = new List<TieFacturaCabecera>();
}
