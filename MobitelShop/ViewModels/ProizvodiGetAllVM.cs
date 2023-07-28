using MobitelShop.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobitelShop.ViewModels
{
    public class ProizvodiGetAllVM
    {
        public int ID { get; set; }
        public string Marka { get; set; }
        public float Cijena { get; set; }
        public byte[]? Slika_bajtovi { get; set; }
        public byte[]? Slika_umanjena { get; set; }
        public string Specifikacije { get; set; }
        public string Boja { get; set; }
        public int ProizvodTipID { get; set; }
        public string? ProizvodTipNaziv { get; set; }
        public string? KratakOpisProizvoda { get;set; }
    }
}
