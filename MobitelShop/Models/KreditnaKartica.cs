using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobitelShop.Models
{
    public class KreditnaKartica
    {
        [Key]
        public int ID { get; set; }
        public string BrojKartice { get; set; }
        public int SC { get; set; }
        [ForeignKey("KorisnikID")]
        public Korisnik Korisnik { get; set; }
        public int KorisnikID { get; set; }
    }
}
