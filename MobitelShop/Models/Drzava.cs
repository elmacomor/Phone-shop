using System.ComponentModel.DataAnnotations;

namespace MobitelShop.Models
{
    public class Drzava
    {
        [Key]
        public int ID { get; set; }
        public string Naziv { get; set; }
    }
}
