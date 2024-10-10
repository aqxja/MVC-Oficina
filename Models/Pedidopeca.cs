using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_Oficina.Models
{

    [Table("Pedidopeca")]
    public class Pedidopeca
    {
        [Column("PedidopecaId")]
        [Display(Name = "Id do Premium")]

        public int PedidopecaId { get; set; }

        [ForeignKey("PedidoId")]

        public int PedidoId { get; set; }

        public Pedido? Pedido { get; set; }

        [ForeignKey("CadastropecasId")]

        public int CadastropecasId { get; set; }

        public Cadastropecas? Cadastropecas { get; set; }
    }
}