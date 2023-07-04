using System;
using System.Collections.Generic;

namespace VeterinariaAPI.Entidades;

public partial class TieFormaPago
{
    public int IdFormaPago { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<TieFacturaFormaPago> TieFacturaFormaPagos { get; set; } = new List<TieFacturaFormaPago>();
}
