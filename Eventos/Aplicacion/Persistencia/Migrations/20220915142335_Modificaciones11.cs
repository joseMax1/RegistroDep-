using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    public partial class Modificaciones11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnidadDeportivas_Torneos_TorneoId",
                table: "UnidadDeportivas");

            migrationBuilder.DropIndex(
                name: "IX_UnidadDeportivas_TorneoId",
                table: "UnidadDeportivas");

            migrationBuilder.DropColumn(
                name: "TorneoId",
                table: "UnidadDeportivas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TorneoId",
                table: "UnidadDeportivas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UnidadDeportivas_TorneoId",
                table: "UnidadDeportivas",
                column: "TorneoId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnidadDeportivas_Torneos_TorneoId",
                table: "UnidadDeportivas",
                column: "TorneoId",
                principalTable: "Torneos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
