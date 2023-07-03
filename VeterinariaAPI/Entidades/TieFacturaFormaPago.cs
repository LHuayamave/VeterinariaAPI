using System;
using System.Collections.Generic;

namespace VeterinariaAPI.Entidades;

public partial class TieFacturaFormaPago
{
    public int IdFacturaFormaPago { get; set; }

    public int IdFacturaCabecera { get; set; }

    public int IdFormaPago { get; set; }

    public virtual TieFacturaCabecera IdFacturaCabeceraNavigation { get; set; }

    public virtual TieFormaPago IdFormaPagoNavigation { get; set; }
}
