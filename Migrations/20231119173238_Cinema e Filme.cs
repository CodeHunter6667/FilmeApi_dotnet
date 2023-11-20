using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FilmesApi.Migrations
{
    public partial class CinemaeFilme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_sessoes_tb_cinemas_CinemaId",
                table: "tb_sessoes");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_sessoes_tb_filmes_FilmeId1",
                table: "tb_sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_sessoes",
                table: "tb_sessoes");

            migrationBuilder.DropIndex(
                name: "IX_tb_sessoes_FilmeId1",
                table: "tb_sessoes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tb_sessoes");

            migrationBuilder.DropColumn(
                name: "FilmeId1",
                table: "tb_sessoes");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "tb_sessoes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "tb_sessoes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_sessoes",
                table: "tb_sessoes",
                columns: new[] { "FilmeId", "CinemaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_tb_sessoes_tb_cinemas_CinemaId",
                table: "tb_sessoes",
                column: "CinemaId",
                principalTable: "tb_cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_sessoes_tb_filmes_FilmeId",
                table: "tb_sessoes",
                column: "FilmeId",
                principalTable: "tb_filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_sessoes_tb_cinemas_CinemaId",
                table: "tb_sessoes");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_sessoes_tb_filmes_FilmeId",
                table: "tb_sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_sessoes",
                table: "tb_sessoes");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "tb_sessoes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "FilmeId",
                table: "tb_sessoes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "tb_sessoes",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "FilmeId1",
                table: "tb_sessoes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_sessoes",
                table: "tb_sessoes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_sessoes_FilmeId1",
                table: "tb_sessoes",
                column: "FilmeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_sessoes_tb_cinemas_CinemaId",
                table: "tb_sessoes",
                column: "CinemaId",
                principalTable: "tb_cinemas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_sessoes_tb_filmes_FilmeId1",
                table: "tb_sessoes",
                column: "FilmeId1",
                principalTable: "tb_filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
