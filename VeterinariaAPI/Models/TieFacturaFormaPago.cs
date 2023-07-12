using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VeterinariaAPI.Entidades;

public partial class TieFacturaFormaPago
{
    public int IdFacturaFormaPago { get; set; }

    public int IdFacturaCabecera { get; set; }

    public int IdFormaPago { get; set; }
    [JsonIgnore]
    public virtual TieFacturaCabecera IdFacturaCabeceraNavigation { get; set; }
    [JsonIgnore]
    public virtual TieFormaPago IdFormaPagoNavigation { get; set; }
}
