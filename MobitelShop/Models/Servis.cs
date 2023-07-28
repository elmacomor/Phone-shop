using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobitelShop.Models
{
    public class Servis
    {
        [Key]
        public int ID { get; set; }
        public string NazivServisa { get; set; }
        public string BrojTelefona { get; set; }
        [ForeignKey("GradID")]
        public Grad Grad { get; set; }
        public int GradID { get; set; }
        public float cijena { get; set; }
    }
}
