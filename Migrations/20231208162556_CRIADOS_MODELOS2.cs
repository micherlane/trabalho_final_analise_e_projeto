using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace micherlane.Migrations
{
    public partial class CRIADOS_MODELOS2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Banco",
                table: "TipoDePagamento");

            migrationBuilder.DropColumn(
                name: "Bandeira",
                table: "TipoDePagamento");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "TipoDePagamento");

            migrationBuilder.DropColumn(
                name: "NomeDoBanco",
                table: "TipoDePagamento");

            migrationBuilder.DropColumn(
                name: "NumeroDoCartao",
                table: "TipoDePagamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Banco",
                table: "TipoDePagamento",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bandeira",
                table: "TipoDePagamento",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "TipoDePagamento",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NomeDoBanco",
                table: "TipoDePagamento",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NumeroDoCartao",
                table: "TipoDePagamento",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
