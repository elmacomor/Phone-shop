using System.ComponentModel.DataAnnotations;

namespace MobitelShop.Models
{
    public class ProizvodTip
    {
        [Key]
        public int ID { get; set; }
        public string Naziv { get; set; }
    }
}
