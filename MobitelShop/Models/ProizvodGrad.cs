using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobitelShop.Models
{
    public class ProizvodGrad
    {
        [Key]
        public int ID { get; set; }
        public int Kolicina { get; set; }
        [ForeignKey("ProizvodID")]
        public Proizvod Proizvod { get; set; }
        public int ProizvodID { get; set; }
        [ForeignKey("GradID")]
        public Grad Grad { get; set; }
        public int GradID { get; set; }
    }
}
