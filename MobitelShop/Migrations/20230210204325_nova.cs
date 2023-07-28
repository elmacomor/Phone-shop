using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobitelShop.Migrations
{
    /// <inheritdoc />
    public partial class nova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KreditnaKartica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojKartice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SC = table.Column<int>(type: "int", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KreditnaKartica", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KreditnaKartica_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProizvodTip",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProizvodTip", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VikendAkcija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Od = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Do = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IznosPopusta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VikendAkcija", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostanskiBroj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrzavaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojRacuna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IznosRacuna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NacinPlacanja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KreditnaKarticaID = table.Column<int>(type: "int", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Racun_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Racun_KreditnaKartica_KreditnaKarticaID",
                        column: x => x.KreditnaKarticaID,
                        principalTable: "KreditnaKartica",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cijena = table.Column<float>(type: "real", nullable: false),
                    Boja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specifikacije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProizvodTipID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Proizvod_ProizvodTip_ProizvodTipID",
                        column: x => x.ProizvodTipID,
                        principalTable: "ProizvodTip",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Servis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivServisa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servis", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Servis_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ShippingPodaci",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradID = table.Column<int>(type: "int", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingPodaci", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShippingPodaci_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ShippingPodaci_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OmiljeniProizvod",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aktivan = table.Column<bool>(type: "bit", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    ProizvodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OmiljeniProizvod", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OmiljeniProizvod_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OmiljeniProizvod_Proizvod_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvod",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProizvodVikendAkcija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VikendAkcijaID = table.Column<int>(type: "int", nullable: false),
                    ProizvodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProizvodVikendAkcija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProizvodVikendAkcija_Proizvod_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvod",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProizvodVikendAkcija_VikendAkcija_VikendAkcijaID",
                        column: x => x.VikendAkcijaID,
                        principalTable: "VikendAkcija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumNarudzbe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    ShippingPodaciID = table.Column<int>(type: "int", nullable: false),
                    RacunID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Narudzba_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Narudzba_Racun_RacunID",
                        column: x => x.RacunID,
                        principalTable: "Racun",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Narudzba_ShippingPodaci_ShippingPodaciID",
                        column: x => x.ShippingPodaciID,
                        principalTable: "ShippingPodaci",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "NarudzbaProizvod",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    ProizvodID = table.Column<int>(type: "int", nullable: false),
                    NarudzbaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaProizvod", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NarudzbaProizvod_Narudzba_NarudzbaID",
                        column: x => x.NarudzbaID,
                        principalTable: "Narudzba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_NarudzbaProizvod_Proizvod_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvod",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaID",
                table: "Grad",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_KreditnaKartica_KorisnikID",
                table: "KreditnaKartica",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_KorisnikID",
                table: "Narudzba",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_RacunID",
                table: "Narudzba",
                column: "RacunID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_ShippingPodaciID",
                table: "Narudzba",
                column: "ShippingPodaciID");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaProizvod_NarudzbaID",
                table: "NarudzbaProizvod",
                column: "NarudzbaID");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaProizvod_ProizvodID",
                table: "NarudzbaProizvod",
                column: "ProizvodID");

            migrationBuilder.CreateIndex(
                name: "IX_OmiljeniProizvod_KorisnikID",
                table: "OmiljeniProizvod",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_OmiljeniProizvod_ProizvodID",
                table: "OmiljeniProizvod",
                column: "ProizvodID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_ProizvodTipID",
                table: "Proizvod",
                column: "ProizvodTipID");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodVikendAkcija_ProizvodID",
                table: "ProizvodVikendAkcija",
                column: "ProizvodID");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodVikendAkcija_VikendAkcijaID",
                table: "ProizvodVikendAkcija",
                column: "VikendAkcijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_KorisnikID",
                table: "Racun",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_KreditnaKarticaID",
                table: "Racun",
                column: "KreditnaKarticaID");

            migrationBuilder.CreateIndex(
                name: "IX_Servis_GradID",
                table: "Servis",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingPodaci_GradID",
                table: "ShippingPodaci",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingPodaci_KorisnikID",
                table: "ShippingPodaci",
                column: "KorisnikID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NarudzbaProizvod");

            migrationBuilder.DropTable(
                name: "OmiljeniProizvod");

            migrationBuilder.DropTable(
                name: "ProizvodVikendAkcija");

            migrationBuilder.DropTable(
                name: "Servis");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "VikendAkcija");

            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropTable(
                name: "ShippingPodaci");

            migrationBuilder.DropTable(
                name: "ProizvodTip");

            migrationBuilder.DropTable(
                name: "KreditnaKartica");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
