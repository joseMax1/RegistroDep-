using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    public partial class Modificaciones10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arbitros_Torneos_TorneoId",
                table: "Arbitros");

            migrationBuilder.DropIndex(
                name: "IX_Arbitros_TorneoId",
                table: "Arbitros");

            migrationBuilder.DropColumn(
                name: "TorneoId",
                table: "Arbitros");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TorneoId",
                table: "Arbitros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Arbitros_TorneoId",
                table: "Arbitros",
                column: "TorneoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Arbitros_Torneos_TorneoId",
                table: "Arbitros",
                column: "TorneoId",
                principalTable: "Torneos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
