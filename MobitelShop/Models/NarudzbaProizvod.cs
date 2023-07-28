using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobitelShop.Models
{
    public class NarudzbaProizvod
    {
        [Key]
        public int ID { get; set; }
        public int Kolicina { get; set; }
        [ForeignKey("ProizvodID")]
        public Proizvod Proizvod { get; set; }
        public int ProizvodID { get; set; }
        [ForeignKey("NarudzbaID")]
        public Narudzba Narudzba { get; set; }
        public int NarudzbaID { get; set; }
    }
}
