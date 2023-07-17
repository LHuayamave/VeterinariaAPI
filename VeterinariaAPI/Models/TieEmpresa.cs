using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VeterinariaAPI.Negocio;

namespace VeterinariaAPI.Entidades;

public partial class TieEmpresa
{
    public int IdEmpresa { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public string NombreEmpresa { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    [SoloNumeros]
    [StringLength(13,MinimumLength = 13, ErrorMessage = "El campo {0} debe tener {1} caracteres")]
    public string NumDocumento { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public string DireccionEmpresa { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    [EmailAddress(ErrorMessage = "El campo {0} debe ser una dirección de correo electrónico válida.")]
    public string CorreoEmpresa { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    [SoloNumeros]
    public string TelefonoEmpresa { get; set; }
    [JsonIgnore]
    public virtual ICollection<TieFacturaCabecera> TieFacturaCabeceras { get; set; } = new List<TieFacturaCabecera>();
}
