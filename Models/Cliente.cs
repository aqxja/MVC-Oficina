using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_Oficina.Models
{

    [Table("Cliente")]
    public class Cliente
    {
        [Column("ClienteId")]
        [Display(Name = "Id do Cliente")]

        public int ClienteId { get; set; }

        [Column("Nomecliente")]
        [Display(Name = "Nome do Cliente")]

        public string Nomecliente { get; set; } = string.Empty;

        [Column("CpfCliente")]
        [Display(Name = "Cpf do Cliente")]

        public int CpfCliente { get; set; }

        [Column("EmailCliente")]
        [Display(Name = "Email do Cliente")]

        public string EmailCliente { get; set; } = string.Empty;

        [Column("Datadenacimentocliente")]
        [Display(Name = "Data de Nacimento do Cliente")]

        public DateTime Datadenacimentocliente { get; set; }

        [Column("TelefoneCliente")]
        [Display(Name = "Telefone do Cliente")]

        public int TelefoneCliente { get; set; }

        [ForeignKey("PremiumId")]

        public int PremiumId { get; set; }

        public Premium? Premium { get; set; }
    }
}
