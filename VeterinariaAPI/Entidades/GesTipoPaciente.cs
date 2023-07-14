namespace VeterinariaAPI.Entidades
{
    public class GesTipoPaciente
    {
        public string idTipoPaciente { get; set; }
        public string tipoPaciente { get; set; }
        public string? estadoTipoPaciente { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public DateTime? fechaActualizacion { get; set; }
        public DateTime? fechaEliminacion { get; set; }
        public virtual ICollection<GesPaciente> GesPacientes { get; set; } = new List<GesPaciente>();
    }
}
