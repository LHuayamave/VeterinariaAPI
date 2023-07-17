using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VeterinariaAPI.Negocio;

namespace VeterinariaAPI.Entidades;

public partial class TieFacturaCabecera
{
    public int IdFacturaCabecera { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int IdEmpresa { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int IdUsuario { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    [SoloNumeros]
    public string NumeroFactura { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public DateTime FechaFacturaCreacion { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int IdCliente { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public string NombreCliente { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    [SoloNumeros]
    [StringLength(13, MinimumLength = 10, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
    public string NumDocumentoCliente { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public double? SubtotalFactura { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public double? Iva { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public double? TotalFactura { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    [SoloLetras]
    public string EstadoFacturaCabecera { get; set; }
    public string Observaciones { get; set; }
    [JsonIgnore]
    public virtual Cliente oIdCliente { get; set; }
    [JsonIgnore]
    public virtual TieEmpresa oIdEmpresa { get; set; }
    [JsonIgnore]
    public virtual Usuario oIdUsuario { get; set; }
    public virtual ICollection<TieFacturaDetalle> TieFacturaDetalles { get; set; } = new List<TieFacturaDetalle>();
    [JsonIgnore]
    public virtual ICollection<TieFacturaFormaPago> TieFacturaFormaPagos { get; set; } = new List<TieFacturaFormaPago>();
}
