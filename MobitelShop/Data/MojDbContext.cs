using Microsoft.EntityFrameworkCore;
using MobitelShop.Models;

namespace MobitelShop.Data
{
    public class MojDbContext : DbContext
    {
        public MojDbContext(DbContextOptions<MojDbContext> options) : base(options)
        {
        }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<KreditnaKartica> KreditnaKartica { get; set; }
        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<NarudzbaProizvod> NarudzbaProizvod { get; set; }
        public DbSet<OmiljeniProizvod> OmiljeniProizvod { get; set; }
        public DbSet<Proizvod> Proizvod { get; set; }
        public DbSet<ProizvodTip> ProizvodTip { get; set; }
        public DbSet<ProizvodVikendAkcija> ProizvodVikendAkcija { get; set; }
        public DbSet<Racun> Racun { get; set; }
        public DbSet<Servis> Servis { get; set; }
        public DbSet<ShippingPodaci> ShippingPodaci { get; set; }
        public DbSet<VikendAkcija> VikendAkcija { get; set; }
        public DbSet<ProizvodGrad> ProizvodGrad { get; set; }

        
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //ovo on nije radio ali je na adilovim vjezbama
    //{
    //  base.OnConfiguring(optionsBuilder);
    //
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder); //ni ovo nego je radio ono modelBuilder.Entity<Student>().ToTable("Student"); ali to nama ne treba
    }


    }
}
