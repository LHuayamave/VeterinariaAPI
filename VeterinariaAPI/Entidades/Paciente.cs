namespace VeterinariaAPI.Entidades
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNac { get; set; }
        public string Color { get; set; }
        public string Senias { get; set; }
        public string Foto { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
