using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VeterinariaAPI.Validaciones;

namespace VeterinariaAPI.Entidades
{

    public class GesPaciente
    {
        [Key]
        public int idPaciente { get; set; }
        
        [Required]
        [StringLength(maximumLength: 10, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [PrimeraLetraMayuscula]
        public string nombrePaciente { get; set; }

        [Required]
        public DateTime fechaNac { get; set; }

        [Required]
        [StringLength(maximumLength: 10, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [PrimeraLetraMayuscula]
        public string raza { get; set; }

        [Required]
        public string idTipoPaciente { get; set; }

        [Required]
        public int idCliente { get; set; }
        public string? estadoPaciente { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public DateTime? fechaActualizacion { get; set; }
        public DateTime? fechaEliminacion { get; set; }
        public int? edad { get; set; }
        [JsonIgnore]
        public virtual GesCliente Cliente { get; set; }
        [JsonIgnore]
        public virtual GesTipoPaciente TipoPaciente { get; set; }
    }

}
