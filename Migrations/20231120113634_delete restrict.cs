using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesApi.Migrations
{
    public partial class deleterestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_cinemas_tb_enderecos_EnderecoId",
                table: "tb_cinemas");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_cinemas_tb_enderecos_EnderecoId",
                table: "tb_cinemas",
                column: "EnderecoId",
                principalTable: "tb_enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_cinemas_tb_enderecos_EnderecoId",
                table: "tb_cinemas");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_cinemas_tb_enderecos_EnderecoId",
                table: "tb_cinemas",
                column: "EnderecoId",
                principalTable: "tb_enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
