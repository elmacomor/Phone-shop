using MobitelShop.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobitelShop.ViewModels
{
    public class KreditnaKarticaGetAllVM
    {
        public int ID { get; set; }
        public string BrojKartice { get; set; }
        public int SC { get; set; }
        public int KupacID { get; set; }
    }
}
