using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VeterinariaAPI.Validaciones;

namespace VeterinariaAPI.Entidades;

public partial class GesCliente
{
    [Key]
    public int idCliente { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength (13, MinimumLength =10, ErrorMessage ="El campo {0} no debe tener mas de {1} caracteres")]
    [SoloNumeros]
    public string numDocumento { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(maximumLength:30, ErrorMessage ="El campo {0} no debe tener mas de {1} caracteres")]
    [PrimeraLetraMayuscula]
    public string nombreCliente { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(maximumLength:30, ErrorMessage ="El campo {0} no debe tener mas de {1} caracteres")]
    [PrimeraLetraMayuscula]
    public string apellidoCliente { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [MayorDeEdad]
    public DateTime fechaNac { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(maximumLength:10, ErrorMessage ="El campo {0} no debe tener mas de {1} caracteres")]
    [SoloNumeros]
    public string telefono { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(maximumLength:100, ErrorMessage ="El campo {0} no debe tener mas de {1} caracteres")]
    public string direccion { get; set; }

    [EmailAddress(ErrorMessage = "La estructura no es correcta")]
    public string? correo { get; set; }
    public string? estadoCliente { get; set; }
    public DateTime? fechaCreacion { get; set; }
    public DateTime? fechaActualizacion { get; set; }
    public DateTime? fechaEliminacion { get; set; }
    public virtual ICollection<GesPaciente> GesPacientes { get; set; } = new List<GesPaciente>();
    public virtual ICollection<TieFacturaCabecera> TieFacturaCabeceras { get; set; } = new List<TieFacturaCabecera>();
}