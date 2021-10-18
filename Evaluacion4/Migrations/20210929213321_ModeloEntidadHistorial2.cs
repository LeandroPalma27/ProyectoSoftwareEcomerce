using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Evaluacion4.Migrations
{
    public partial class ModeloEntidadHistorial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistorialCompras",
                columns: table => new
                {
                    IdHistorial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHistorial = table.Column<DateTime>(nullable: false),
                    IdProducto = table.Column<int>(nullable: false),
                    Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialCompras", x => x.IdHistorial);
                    table.ForeignKey(
                        name: "FK_HistorialCompras_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistorialCompras_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialCompras_Id",
                table: "HistorialCompras",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialCompras_IdProducto",
                table: "HistorialCompras",
                column: "IdProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialCompras");
        }
    }
}
