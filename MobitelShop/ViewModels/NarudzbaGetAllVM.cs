using MobitelShop.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobitelShop.ViewModels
{
    public class NarudzbaGetAllVM
    {
        public int ID { get; set; }
        public string DatumNarudzbe { get; set; }
        public int KupacID { get; set; }
        public int ShippingPodaciID { get; set; }
       
        
    }
}
