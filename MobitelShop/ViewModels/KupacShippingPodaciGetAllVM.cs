using MobitelShop.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MobitelShop.ViewModels
{
    public class KupacShippingPodaciGetAllVM
    {
       
        public int ID { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
        public int GradID { get; set; }
    }
}
