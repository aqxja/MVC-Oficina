using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_Oficina.Models
{

    [Table("Premium")]
    public class Premium
    {
        [Column("PremiumId")]
        [Display(Name = "Id do Premium")]

        public int PremiumId { get; set; }

        [Column("Tipodepremium")]
        [Display(Name = "Tipo de Premium")]

        public string Tipodepremium { get; set; } = string.Empty;


        [Column("Descontodopremium")]
        [Display(Name = "Desconto do Premium")]

        public int Descontodopremium { get; set; }

    }
}
