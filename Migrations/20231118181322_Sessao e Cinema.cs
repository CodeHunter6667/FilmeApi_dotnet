using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesApi.Migrations
{
    public partial class SessaoeCinema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CinemaId",
                table: "tb_sessoes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_sessoes_CinemaId",
                table: "tb_sessoes",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_sessoes_tb_cinemas_CinemaId",
                table: "tb_sessoes",
                column: "CinemaId",
                principalTable: "tb_cinemas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_sessoes_tb_cinemas_CinemaId",
                table: "tb_sessoes");

            migrationBuilder.DropIndex(
                name: "IX_tb_sessoes_CinemaId",
                table: "tb_sessoes");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "tb_sessoes");
        }
    }
}
