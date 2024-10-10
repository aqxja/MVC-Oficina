using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_Oficina.Models
{

    [Table("CadastropecasId")]
    public class Cadastropecas
    {
        [Column("CadastropecasId")]
        [Display(Name = "Id das peças")]

        public int CadastropecasId { get; set; }

        [Column("Nomepeca")]
        [Display(Name = "Nome da peça")]

        public string Nomepeca { get; set; } = string.Empty;

        [Column("Tipopeca")]
        [Display(Name = "Tipo da peça")]

        public string Tipopeca { get; set; } = string.Empty;

        [Column("Valorpeca")]
        [Display(Name = "Valor da peça")]

        public int Valorpeca { get; set; } 
    }
}
