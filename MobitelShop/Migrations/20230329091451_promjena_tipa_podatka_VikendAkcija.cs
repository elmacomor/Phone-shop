using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobitelShop.Migrations
{
    /// <inheritdoc />
    public partial class promjenatipapodatkaVikendAkcija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IznosPopusta",
                table: "VikendAkcija",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IznosPopusta",
                table: "VikendAkcija",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
