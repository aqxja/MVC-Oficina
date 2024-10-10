using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_Oficina.Models
{

    [Table("CadastrovendedorId")]
    public class Cadastrovendedor
    {
        [Column("CadastrovendedorId")]
        [Display(Name = "Id dos vendedores")]

        public int CadastrovendedorId { get; set; }

        [Column("Nomevendedor")]
        [Display(Name = "Nome do vendedor")]

        public string Nomevendedor { get; set; } = string.Empty;

        [Column("Cpfvendedor")]
        [Display(Name = "Cpf do vendedor")]

        public int Cpfvendedor { get; set; }

        [Column("Emailvendedor")]
        [Display(Name = "Email do vendedor")]

        public string Emailvendedor { get; set; } = string.Empty;

        [Column("Datanascimentovendedor")]
        [Display(Name = "data de nacimento do vendedor")]

        public DateTime Datanascimentovendedor { get; set; }
    }
}