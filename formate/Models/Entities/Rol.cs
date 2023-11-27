using System.ComponentModel.DataAnnotations;

namespace formate.Models.Entities
{
    public class Rol
    {
        [Key]
        public int PkRoles { get; set; }
        [Required]
        public string Nombrerol { get; set; }
    }
}
