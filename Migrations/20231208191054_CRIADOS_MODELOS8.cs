using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace micherlane.Migrations
{
    public partial class CRIADOS_MODELOS8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemNotaDaVenda",
                columns: table => new
                {
                    ItemsId = table.Column<int>(type: "int", nullable: false),
                    NotaDaVendasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemNotaDaVenda", x => new { x.ItemsId, x.NotaDaVendasId });
                    table.ForeignKey(
                        name: "FK_ItemNotaDaVenda_Item_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemNotaDaVenda_NotaDaVenda_NotaDaVendasId",
                        column: x => x.NotaDaVendasId,
                        principalTable: "NotaDaVenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ItemNotaDaVenda_NotaDaVendasId",
                table: "ItemNotaDaVenda",
                column: "NotaDaVendasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemNotaDaVenda");
        }
    }
}
