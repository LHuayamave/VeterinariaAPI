using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VeterinariaAPI.Entidades;

public partial class TieFormaPago
{
    public int IdFormaPago { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public string Nombre { get; set; }
    [JsonIgnore]
    public virtual ICollection<TieFacturaFormaPago> TieFacturaFormaPagos { get; set; } = new List<TieFacturaFormaPago>();
}
