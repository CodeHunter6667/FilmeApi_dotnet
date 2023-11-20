using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FilmesApi.Migrations
{
    public partial class muitosparamuitos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_sessoes_tb_filmes_FilmeId",
                table: "tb_sessoes");

            migrationBuilder.DropIndex(
                name: "IX_tb_sessoes_FilmeId",
                table: "tb_sessoes");

            migrationBuilder.AddColumn<int>(
                name: "FilmeId1",
                table: "tb_sessoes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "tb_filmes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_tb_sessoes_FilmeId1",
                table: "tb_sessoes",
                column: "FilmeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_sessoes_tb_filmes_FilmeId1",
                table: "tb_sessoes",
                column: "FilmeId1",
                principalTable: "tb_filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_sessoes_tb_filmes_FilmeId1",
                table: "tb_sessoes");

            migrationBuilder.DropIndex(
                name: "IX_tb_sessoes_FilmeId1",
                table: "tb_sessoes");

            migrationBuilder.DropColumn(
                name: "FilmeId1",
                table: "tb_sessoes");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "tb_filmes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_tb_sessoes_FilmeId",
                table: "tb_sessoes",
                column: "FilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_sessoes_tb_filmes_FilmeId",
                table: "tb_sessoes",
                column: "FilmeId",
                principalTable: "tb_filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
