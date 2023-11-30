using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace formate.Models.Entities
{
    public class Comentario
    {
        [Key]       //Mov Tay
        public int PkComentario {  get; set; }

        [Required]
        public string Texto { get; set; }

        [ForeignKey ("Cliente")]
        public int? FkCliente { get; set; }
        public Cliente Clientes { get; set; }
    }
}
