using System.ComponentModel.DataAnnotations;
using VeterinariaAPI.Validaciones;

namespace VeterinariaAPI.Entidades
{
    public class GesTipoPaciente
    {
        [Required]
        [StringLength(maximumLength: 1, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [PrimeraLetraMayuscula]
        public string idTipoPaciente { get; set; }

        [Required]
        [StringLength(maximumLength: 10, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [PrimeraLetraMayuscula]
        public string tipoPaciente { get; set; }

        public string? estadoTipoPaciente { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public DateTime? fechaActualizacion { get; set; }
        public DateTime? fechaEliminacion { get; set; }
        public virtual ICollection<GesPaciente> GesPacientes { get; set; } = new List<GesPaciente>();
    }
}
