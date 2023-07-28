using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobitelShop.Models
{
    public class Proizvod
    {
        [Key]
        public int ID { get; set; }
        public string Marka { get; set; }
        public float Cijena { get; set; }
        public string Boja { get; set; }
        public string Specifikacije { get; set; }
        [ForeignKey("ProizvodTipID")]
        public ProizvodTip ProizvodTip { get; set; }
        public int ProizvodTipID { get; set; }
        public string? KratakOpisProizvoda { get; set; }
    }
}
