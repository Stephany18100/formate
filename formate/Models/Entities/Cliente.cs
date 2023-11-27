using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace formate.Models.Entities
{
    public class Cliente
    {
        [Key]
        public int PkCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }

        [ForeignKey("Roles")]
        public int? FkRol { get; set; }
        public Rol Roles { get; set; }

    }
}
