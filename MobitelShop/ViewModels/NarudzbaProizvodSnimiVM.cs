using MobitelShop.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MobitelShop.ViewModels
{
    public class NarudzbaProizvodSnimiVM
    {
       
        public int ID { get; set; }
        public int Kolicina { get; set; }
       
        public int ProizvodID { get; set; }
        public int NarudzbaID { get; set; }
    }
}
