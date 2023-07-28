using MobitelShop.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobitelShop.ViewModels
{
    public class ProizvodVikendAkcijaSpremiVM
    {
        public int ID { get; set; }
        public int VikendAkcijaID { get; set; }
        public int ProizvodID { get; set; }
    }
}
