using System;
using System.Collections.Generic;

namespace VeterinariaAPI.Entidades;

public partial class TieFacturaFormaPago
{
    public int IdFacturaFormaPago { get; set; }

    public int IdFacturaCabecera { get; set; }

    public int IdFormaPago { get; set; }

    public virtual TieFacturaCabecera oIdFacturaCabecera { get; set; }

    public virtual TieFormaPago oIdFormaPago { get; set; }
}
