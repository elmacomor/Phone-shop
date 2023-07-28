using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobitelShop.Models
{
    public class Racun
    {
        [Key]
        public int ID { get; set; }
        public string BrojRacuna { get; set; }
        public string IznosRacuna { get; set; }
        public string NacinPlacanja { get; set; }
        [ForeignKey("KreditnaKarticaID")]
        public KreditnaKartica KreditnaKartica { get; set; }
        public int KreditnaKarticaID { get; set; }
        [ForeignKey("KorisnikID")]
        public Korisnik korisnik { get; set; }
        public int KorisnikID { get; set; }
    }
}
