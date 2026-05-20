using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enemix.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial_MG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MateriaisEstudo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    AreaConhecimento = table.Column<int>(type: "integer", nullable: false),
                    ConteudoTeorico = table.Column<string>(type: "text", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaisEstudo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TopicosEstudo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    DescricaoHtml = table.Column<string>(type: "text", nullable: true),
                    ImagemUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AreaConhecimento = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicosEstudo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaterialEstudoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Enunciado = table.Column<string>(type: "text", nullable: false),
                    AlternativaA = table.Column<string>(type: "text", nullable: true),
                    AlternativaB = table.Column<string>(type: "text", nullable: true),
                    AlternativaC = table.Column<string>(type: "text", nullable: true),
                    AlternativaD = table.Column<string>(type: "text", nullable: true),
                    AlternativaE = table.Column<string>(type: "text", nullable: true),
                    AlternativaCorreta = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    Resolucao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questoes_MateriaisEstudo_MaterialEstudoId",
                        column: x => x.MaterialEstudoId,
                        principalTable: "MateriaisEstudo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_MaterialEstudoId",
                table: "Questoes",
                column: "MaterialEstudoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questoes");

            migrationBuilder.DropTable(
                name: "TopicosEstudo");

            migrationBuilder.DropTable(
                name: "MateriaisEstudo");
        }
    }
}
