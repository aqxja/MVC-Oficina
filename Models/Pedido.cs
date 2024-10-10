using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_Oficina.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        [Column("PedidoId")]
        [Display(Name = "Id do Pedido")]

        public int PedidoId { get; set; }

        [ForeignKey("CadastrovendedorId")]

        public int CadastrovendedorId { get; set; }

        public Cadastrovendedor? Cadastrovendedor { get; set; }


        [ForeignKey("ClienteId")]

        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        [Column("Dadosdopedido")]
        [Display(Name = "Dados do Pedido")]

        public string Dadosdopedido { get; set; } = string.Empty;

        [Column("Datadopedido")]
        [Display(Name = "Data do Pedido")]

        public DateTime Datadopedido { get; set; }
    }
}
