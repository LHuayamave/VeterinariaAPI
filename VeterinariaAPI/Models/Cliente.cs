using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VeterinariaAPI.Entidades;

public partial class Cliente
{
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int IdCliente { get; set; }

    public string NombreCliente { get; set; }

    public string NumDocumentoCliente { get; set; }
    [JsonIgnore]
    public virtual ICollection<TieFacturaCabecera> TieFacturaCabeceras { get; set; } = new List<TieFacturaCabecera>();
}
