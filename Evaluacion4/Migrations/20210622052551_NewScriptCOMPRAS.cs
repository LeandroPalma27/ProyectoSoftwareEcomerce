using Microsoft.EntityFrameworkCore.Migrations;

namespace Evaluacion4.Migrations
{
    public partial class NewScriptCOMPRAS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Categoria_CategoriaIdCategoria",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_CategoriaIdCategoria",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "CategoriaIdCategoria",
                table: "Compras");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdCategoria",
                table: "Compras",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_CategoriaIdCategoria",
                table: "Compras",
                column: "CategoriaIdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Categoria_CategoriaIdCategoria",
                table: "Compras",
                column: "CategoriaIdCategoria",
                principalTable: "Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
