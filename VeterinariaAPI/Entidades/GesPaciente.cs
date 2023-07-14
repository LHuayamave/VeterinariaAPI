using System.Text.Json.Serialization;

namespace VeterinariaAPI.Entidades
{

    public class GesPaciente
    {
        public int idPaciente { get; set; }
        public string nombrePaciente { get; set; }
        public DateTime fechaNac { get; set; }
        //public string peso { get; set; }
        public string raza { get; set; }
        //public string sexo { get; set; }
        public string idTipoPaciente { get; set; }
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
