using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobitelShop.Models
{
    public class OmiljeniProizvod
    {
        [Key]
        public int ID { get; set; }
        public bool Aktivan { get; set; }
        [ForeignKey("KorisnikID")]
        public Korisnik Korisnik { get; set; }
        public int KorisnikID { get; set; }
        [ForeignKey("ProizvodID")]
        public Proizvod Proizvod { get; set; }
        public int ProizvodID { get; set; }
    }
}
