using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobitelShop.Models
{
    public class Grad
    {
        [Key]
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }
        [ForeignKey("DrzavaID")]
        public Drzava Drzava { get; set; }
        public int DrzavaID { get; set; }
    }
}
