namespace MobitelShop.ViewModels
{
    public class ProizvodSnimiVM
    {
        public int ID { get; set; }
        public string Marka { get; set; }
        public float Cijena { get; set; }
        public string? Slika_bajtovi { get; set; }
        public string Boja { get; set; }
        public string Specifikacije { get; set; }
        public int ProizvodTipID { get; set; }
        public string? KratakOpisProizvoda { get; set; }
    }
}
