using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobitelShop.Migrations
{
    /// <inheritdoc />
    public partial class cijena : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "cijena",
                table: "Servis",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cijena",
                table: "Servis");
        }
    }
}
