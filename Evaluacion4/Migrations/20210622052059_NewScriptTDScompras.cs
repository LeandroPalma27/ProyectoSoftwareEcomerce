using Microsoft.EntityFrameworkCore.Migrations;

namespace Evaluacion4.Migrations
{
    public partial class NewScriptTDScompras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Compras");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Compras",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_Id",
                table: "Compras",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdProducto",
                table: "Compras",
                column: "IdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_AspNetUsers_Id",
                table: "Compras",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Producto_IdProducto",
                table: "Compras",
                column: "IdProducto",
                principalTable: "Producto",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_AspNetUsers_Id",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Producto_IdProducto",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_Id",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_IdProducto",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Compras");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
