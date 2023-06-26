using System.ComponentModel.DataAnnotations;

namespace VeterinariaAPI.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public DateTime FechaNac { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Direccion { get; set; }

     }
}
