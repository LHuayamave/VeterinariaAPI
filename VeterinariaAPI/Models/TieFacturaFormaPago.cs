using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VeterinariaAPI.Entidades;

public partial class TieFacturaFormaPago
{
    public int IdFacturaFormaPago { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int IdFacturaCabecera { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int IdFormaPago { get; set; }
    [JsonIgnore]
    public virtual TieFacturaCabecera IdFacturaCabeceraNavigation { get; set; }
    [JsonIgnore]
    public virtual TieFormaPago IdFormaPagoNavigation { get; set; }
}
