using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobitelShop.Models
{
    public class Narudzba
    {
        [Key]
        public int ID { get; set; }
        public string DatumNarudzbe { get; set; }
        [ForeignKey("KorisnikID")]
        public Korisnik Korisnik { get; set; }
        public int KorisnikID { get; set; }
        [ForeignKey("ShippingPodaciID")]
        public ShippingPodaci ShippingPodaci { get; set; }
        public int ShippingPodaciID { get; set; }
        [ForeignKey("RacunID")]
        public Racun Racun { get; set; }
        public int RacunID { get; set; }
  }
}
