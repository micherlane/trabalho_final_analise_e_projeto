using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace micherlane.Migrations
{
    public partial class NotaDeVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NotaDaVendaId",
                table: "Pagamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NotaDaVenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    Tipo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Devolvido = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    VendedorId = table.Column<int>(type: "int", nullable: false),
                    TipoDePagamentoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaDaVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotaDaVenda_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotaDaVenda_TipoDePagamento_TipoDePagamentoId",
                        column: x => x.TipoDePagamentoId,
                        principalTable: "TipoDePagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotaDaVenda_Vendedor_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NotaDaVendaTransportadora",
                columns: table => new
                {
                    NotaDaVendasId = table.Column<int>(type: "int", nullable: false),
                    TransportadorasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaDaVendaTransportadora", x => new { x.NotaDaVendasId, x.TransportadorasId });
                    table.ForeignKey(
                        name: "FK_NotaDaVendaTransportadora_NotaDaVenda_NotaDaVendasId",
                        column: x => x.NotaDaVendasId,
                        principalTable: "NotaDaVenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotaDaVendaTransportadora_Transportadora_TransportadorasId",
                        column: x => x.TransportadorasId,
                        principalTable: "Transportadora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_NotaDaVendaId",
                table: "Pagamento",
                column: "NotaDaVendaId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaDaVenda_ClienteId",
                table: "NotaDaVenda",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaDaVenda_TipoDePagamentoId",
                table: "NotaDaVenda",
                column: "TipoDePagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaDaVenda_VendedorId",
                table: "NotaDaVenda",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaDaVendaTransportadora_TransportadorasId",
                table: "NotaDaVendaTransportadora",
                column: "TransportadorasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_NotaDaVenda_NotaDaVendaId",
                table: "Pagamento",
                column: "NotaDaVendaId",
                principalTable: "NotaDaVenda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamento_NotaDaVenda_NotaDaVendaId",
                table: "Pagamento");

            migrationBuilder.DropTable(
                name: "NotaDaVendaTransportadora");

            migrationBuilder.DropTable(
                name: "NotaDaVenda");

            migrationBuilder.DropIndex(
                name: "IX_Pagamento_NotaDaVendaId",
                table: "Pagamento");

            migrationBuilder.DropColumn(
                name: "NotaDaVendaId",
                table: "Pagamento");
        }
    }
}
