using Microsoft.EntityFrameworkCore.Migrations;

namespace Evaluacion4.Migrations
{
    public partial class ScriptCampoCantidad1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "HistorialCompras",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "HistorialCompras");
        }
    }
}
