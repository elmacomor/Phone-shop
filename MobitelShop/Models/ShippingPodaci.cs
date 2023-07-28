using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobitelShop.Models
{
    public class ShippingPodaci
    {
        [Key]
        public int ID { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
        [ForeignKey("GradID")]
        public Grad Grad { get; set; }
        public int GradID { get; set; }
        [ForeignKey("KorisnikID")]
        public Korisnik Korisnik { get; set; }
        public int KorisnikID { get; set; }
  }
}
