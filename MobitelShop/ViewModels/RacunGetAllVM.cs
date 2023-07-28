using MobitelShop.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobitelShop.ViewModels
{
    public class RacunGetAllVM
    {
        public int ID { get; set; }
        public string BrojRacuna { get; set; }
        public string IznosRacuna { get; set; }
        public string NacinPlacanja { get; set; }
        public int KreditnaKarticaID { get; set; }
        public int UposlenikID { get; set; }
    }
}
