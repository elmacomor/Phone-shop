using MobitelShop.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MobitelShop.ViewModels
{
    public class ServisSnimiVM
    {
      
        public int ID { get; set; }
        public string NazivServisa { get; set; }
        public string BrojTelefona { get; set; }
        
        public int GradID { get; set; }
        public float cijena { get; set; }
    }
}
