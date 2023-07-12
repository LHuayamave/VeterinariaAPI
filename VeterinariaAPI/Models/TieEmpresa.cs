using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VeterinariaAPI.Entidades;

public partial class TieEmpresa
{
    public int IdEmpresa { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public string NombreEmpresa { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public string NumDocumento { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public string DireccionEmpresa { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public string CorreoEmpresa { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public string TelefonoEmpresa { get; set; }
    [JsonIgnore]
    public virtual ICollection<TieFacturaCabecera> TieFacturaCabeceras { get; set; } = new List<TieFacturaCabecera>();
}
