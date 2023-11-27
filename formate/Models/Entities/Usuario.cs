using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace formate.Models.Entities
{
    public class Usuario
    {
        [Key]
        public int PkUsuario {  get; set; }
        [Required]
        public string NombreUsu {  get; set; }
        [Required]
        public string Contrasena { get; set;}
        [Required]

        [ForeignKey("Roles")]
        public int? FkRol { get; set; }
        public Rol Roles { get; set; }



    }
}
