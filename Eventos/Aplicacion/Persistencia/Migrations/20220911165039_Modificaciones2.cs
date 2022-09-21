using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    public partial class Modificaciones2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArbitroId",
                table: "colegios");

            migrationBuilder.CreateIndex(
                name: "IX_Arbitros_ColegioId",
                table: "Arbitros",
                column: "ColegioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Arbitros_colegios_ColegioId",
                table: "Arbitros",
                column: "ColegioId",
                principalTable: "colegios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arbitros_colegios_ColegioId",
                table: "Arbitros");

            migrationBuilder.DropIndex(
                name: "IX_Arbitros_ColegioId",
                table: "Arbitros");

            migrationBuilder.AddColumn<int>(
                name: "ArbitroId",
                table: "colegios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
