using MobitelShop.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobitelShop.ViewModels
{
    public class OmiljeniProizvodGetAllVM
    {
        public int ID { get; set; }
        public bool Aktivan { get; set; }
        public int KupacID { get; set; }
        public int ProizvodID { get; set; }
    }
}
