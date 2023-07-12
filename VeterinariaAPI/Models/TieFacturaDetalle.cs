using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VeterinariaAPI.Entidades;

public partial class TieFacturaDetalle
{
    public int IdFacturaDetalle { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int? IdFacturaCabecera { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public string NombreProducto { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public double PrecioProducto { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int CantidadProducto { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public double SubtotalProducto { get; set; }
    [JsonIgnore]
    public virtual TieFacturaCabecera IdFacturaCabeceraNavigation { get; set; }
}
