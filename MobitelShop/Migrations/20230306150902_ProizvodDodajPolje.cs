using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobitelShop.Migrations
{
    /// <inheritdoc />
    public partial class ProizvodDodajPolje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grad_Drzava_DrzavaID",
                table: "Grad");

            migrationBuilder.DropForeignKey(
                name: "FK_KreditnaKartica_Korisnik_KorisnikID",
                table: "KreditnaKartica");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Korisnik_KorisnikID",
                table: "Narudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Racun_RacunID",
                table: "Narudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_ShippingPodaci_ShippingPodaciID",
                table: "Narudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaProizvod_Narudzba_NarudzbaID",
                table: "NarudzbaProizvod");

            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaProizvod_Proizvod_ProizvodID",
                table: "NarudzbaProizvod");

            migrationBuilder.DropForeignKey(
                name: "FK_OmiljeniProizvod_Korisnik_KorisnikID",
                table: "OmiljeniProizvod");

            migrationBuilder.DropForeignKey(
                name: "FK_OmiljeniProizvod_Proizvod_ProizvodID",
                table: "OmiljeniProizvod");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_ProizvodTip_ProizvodTipID",
                table: "Proizvod");

            migrationBuilder.DropForeignKey(
                name: "FK_ProizvodVikendAkcija_Proizvod_ProizvodID",
                table: "ProizvodVikendAkcija");

            migrationBuilder.DropForeignKey(
                name: "FK_ProizvodVikendAkcija_VikendAkcija_VikendAkcijaID",
                table: "ProizvodVikendAkcija");

            migrationBuilder.DropForeignKey(
                name: "FK_Racun_Korisnik_KorisnikID",
                table: "Racun");

            migrationBuilder.DropForeignKey(
                name: "FK_Racun_KreditnaKartica_KreditnaKarticaID",
                table: "Racun");

            migrationBuilder.DropForeignKey(
                name: "FK_Servis_Grad_GradID",
                table: "Servis");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingPodaci_Grad_GradID",
                table: "ShippingPodaci");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingPodaci_Korisnik_KorisnikID",
                table: "ShippingPodaci");

            migrationBuilder.AddColumn<string>(
                name: "KratakOpisProizvoda",
                table: "Proizvod",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Grad_Drzava_DrzavaID",
                table: "Grad",
                column: "DrzavaID",
                principalTable: "Drzava",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_KreditnaKartica_Korisnik_KorisnikID",
                table: "KreditnaKartica",
                column: "KorisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Korisnik_KorisnikID",
                table: "Narudzba",
                column: "KorisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Racun_RacunID",
                table: "Narudzba",
                column: "RacunID",
                principalTable: "Racun",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_ShippingPodaci_ShippingPodaciID",
                table: "Narudzba",
                column: "ShippingPodaciID",
                principalTable: "ShippingPodaci",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaProizvod_Narudzba_NarudzbaID",
                table: "NarudzbaProizvod",
                column: "NarudzbaID",
                principalTable: "Narudzba",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaProizvod_Proizvod_ProizvodID",
                table: "NarudzbaProizvod",
                column: "ProizvodID",
                principalTable: "Proizvod",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_OmiljeniProizvod_Korisnik_KorisnikID",
                table: "OmiljeniProizvod",
                column: "KorisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_OmiljeniProizvod_Proizvod_ProizvodID",
                table: "OmiljeniProizvod",
                column: "ProizvodID",
                principalTable: "Proizvod",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_ProizvodTip_ProizvodTipID",
                table: "Proizvod",
                column: "ProizvodTipID",
                principalTable: "ProizvodTip",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProizvodVikendAkcija_Proizvod_ProizvodID",
                table: "ProizvodVikendAkcija",
                column: "ProizvodID",
                principalTable: "Proizvod",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProizvodVikendAkcija_VikendAkcija_VikendAkcijaID",
                table: "ProizvodVikendAkcija",
                column: "VikendAkcijaID",
                principalTable: "VikendAkcija",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Racun_Korisnik_KorisnikID",
                table: "Racun",
                column: "KorisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Racun_KreditnaKartica_KreditnaKarticaID",
                table: "Racun",
                column: "KreditnaKarticaID",
                principalTable: "KreditnaKartica",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Servis_Grad_GradID",
                table: "Servis",
                column: "GradID",
                principalTable: "Grad",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingPodaci_Grad_GradID",
                table: "ShippingPodaci",
                column: "GradID",
                principalTable: "Grad",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingPodaci_Korisnik_KorisnikID",
                table: "ShippingPodaci",
                column: "KorisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grad_Drzava_DrzavaID",
                table: "Grad");

            migrationBuilder.DropForeignKey(
                name: "FK_KreditnaKartica_Korisnik_KorisnikID",
                table: "KreditnaKartica");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Korisnik_KorisnikID",
                table: "Narudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Racun_RacunID",
                table: "Narudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_ShippingPodaci_ShippingPodaciID",
                table: "Narudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaProizvod_Narudzba_NarudzbaID",
                table: "NarudzbaProizvod");

            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaProizvod_Proizvod_ProizvodID",
                table: "NarudzbaProizvod");

            migrationBuilder.DropForeignKey(
                name: "FK_OmiljeniProizvod_Korisnik_KorisnikID",
                table: "OmiljeniProizvod");

            migrationBuilder.DropForeignKey(
                name: "FK_OmiljeniProizvod_Proizvod_ProizvodID",
                table: "OmiljeniProizvod");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_ProizvodTip_ProizvodTipID",
                table: "Proizvod");

            migrationBuilder.DropForeignKey(
                name: "FK_ProizvodVikendAkcija_Proizvod_ProizvodID",
                table: "ProizvodVikendAkcija");

            migrationBuilder.DropForeignKey(
                name: "FK_ProizvodVikendAkcija_VikendAkcija_VikendAkcijaID",
                table: "ProizvodVikendAkcija");

            migrationBuilder.DropForeignKey(
                name: "FK_Racun_Korisnik_KorisnikID",
                table: "Racun");

            migrationBuilder.DropForeignKey(
                name: "FK_Racun_KreditnaKartica_KreditnaKarticaID",
                table: "Racun");

            migrationBuilder.DropForeignKey(
                name: "FK_Servis_Grad_GradID",
                table: "Servis");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingPodaci_Grad_GradID",
                table: "ShippingPodaci");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingPodaci_Korisnik_KorisnikID",
                table: "ShippingPodaci");

            migrationBuilder.DropColumn(
                name: "KratakOpisProizvoda",
                table: "Proizvod");

            migrationBuilder.AddForeignKey(
                name: "FK_Grad_Drzava_DrzavaID",
                table: "Grad",
                column: "DrzavaID",
                principalTable: "Drzava",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_KreditnaKartica_Korisnik_KorisnikID",
                table: "KreditnaKartica",
                column: "KorisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Korisnik_KorisnikID",
                table: "Narudzba",
                column: "KorisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Racun_RacunID",
                table: "Narudzba",
                column: "RacunID",
                principalTable: "Racun",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_ShippingPodaci_ShippingPodaciID",
                table: "Narudzba",
                column: "ShippingPodaciID",
                principalTable: "ShippingPodaci",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaProizvod_Narudzba_NarudzbaID",
                table: "NarudzbaProizvod",
                column: "NarudzbaID",
                principalTable: "Narudzba",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaProizvod_Proizvod_ProizvodID",
                table: "NarudzbaProizvod",
                column: "ProizvodID",
                principalTable: "Proizvod",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OmiljeniProizvod_Korisnik_KorisnikID",
                table: "OmiljeniProizvod",
                column: "KorisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OmiljeniProizvod_Proizvod_ProizvodID",
                table: "OmiljeniProizvod",
                column: "ProizvodID",
                principalTable: "Proizvod",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_ProizvodTip_ProizvodTipID",
                table: "Proizvod",
                column: "ProizvodTipID",
                principalTable: "ProizvodTip",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProizvodVikendAkcija_Proizvod_ProizvodID",
                table: "ProizvodVikendAkcija",
                column: "ProizvodID",
                principalTable: "Proizvod",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProizvodVikendAkcija_VikendAkcija_VikendAkcijaID",
                table: "ProizvodVikendAkcija",
                column: "VikendAkcijaID",
                principalTable: "VikendAkcija",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Racun_Korisnik_KorisnikID",
                table: "Racun",
                column: "KorisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Racun_KreditnaKartica_KreditnaKarticaID",
                table: "Racun",
                column: "KreditnaKarticaID",
                principalTable: "KreditnaKartica",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Servis_Grad_GradID",
                table: "Servis",
                column: "GradID",
                principalTable: "Grad",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingPodaci_Grad_GradID",
                table: "ShippingPodaci",
                column: "GradID",
                principalTable: "Grad",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingPodaci_Korisnik_KorisnikID",
                table: "ShippingPodaci",
                column: "KorisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID");
        }
    }
}
