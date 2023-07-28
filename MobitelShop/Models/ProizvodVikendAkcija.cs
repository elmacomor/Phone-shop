using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobitelShop.Models
{
    public class ProizvodVikendAkcija
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("VikendAkcijaID")]
        public VikendAkcija VikendAkcija { get; set; }
        public int VikendAkcijaID { get; set; }
        [ForeignKey("ProizvodID")]
        public Proizvod Proizvod { get; set; }
        public int ProizvodID { get; set; }
    }
}
