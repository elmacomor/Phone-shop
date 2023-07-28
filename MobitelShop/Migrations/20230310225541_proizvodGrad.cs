using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobitelShop.Migrations
{
    /// <inheritdoc />
    public partial class proizvodGrad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProizvodGrad",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    ProizvodID = table.Column<int>(type: "int", nullable: false),
                    GradID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProizvodGrad", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProizvodGrad_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProizvodGrad_Proizvod_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvod",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodGrad_GradID",
                table: "ProizvodGrad",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodGrad_ProizvodID",
                table: "ProizvodGrad",
                column: "ProizvodID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProizvodGrad");
        }
    }
}
