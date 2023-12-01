using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace formate.Models.Entities
{
    public class Categoria
    {
        [Key]
        public int PkCategoria { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }
    }
}
