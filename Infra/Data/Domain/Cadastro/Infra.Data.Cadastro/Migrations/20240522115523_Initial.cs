using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Cadastro.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Cadastro");

            migrationBuilder.CreateTable(
                name: "Reg_Regiao",
                schema: "Cadastro",
                columns: table => new
                {
                    Reg_RegiaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Reg_Nome = table.Column<string>(type: "text", nullable: false),
                    Reg_Sigla = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reg_Regiao", x => x.Reg_RegiaoId);
                });

            migrationBuilder.CreateTable(
                name: "Cod_CodigoDiscagem",
                schema: "Cadastro",
                columns: table => new
                {
                    Cod_CodigoDiscagemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cod_Ddd = table.Column<int>(type: "integer", maxLength: 3, nullable: false),
                    Reg_RegiaoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cod_CodigoDiscagem", x => x.Cod_CodigoDiscagemId);
                    table.ForeignKey(
                        name: "FK_Cod_CodigoDiscagem_Reg_Regiao_Reg_RegiaoId",
                        column: x => x.Reg_RegiaoId,
                        principalSchema: "Cadastro",
                        principalTable: "Reg_Regiao",
                        principalColumn: "Reg_RegiaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Con_Contato",
                schema: "Cadastro",
                columns: table => new
                {
                    Con_ContatoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Con_Nome = table.Column<string>(type: "text", nullable: false),
                    Con_Telefone = table.Column<string>(type: "text", nullable: false),
                    Con_Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Cod_CodigoDiscagemId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Con_Contato", x => x.Con_ContatoId);
                    table.ForeignKey(
                        name: "FK_Con_Contato_Cod_CodigoDiscagem_Cod_CodigoDiscagemId",
                        column: x => x.Cod_CodigoDiscagemId,
                        principalSchema: "Cadastro",
                        principalTable: "Cod_CodigoDiscagem",
                        principalColumn: "Cod_CodigoDiscagemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cod_CodigoDiscagem_Reg_RegiaoId",
                schema: "Cadastro",
                table: "Cod_CodigoDiscagem",
                column: "Reg_RegiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Con_Contato_Cod_CodigoDiscagemId",
                schema: "Cadastro",
                table: "Con_Contato",
                column: "Cod_CodigoDiscagemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Con_Contato",
                schema: "Cadastro");

            migrationBuilder.DropTable(
                name: "Cod_CodigoDiscagem",
                schema: "Cadastro");

            migrationBuilder.DropTable(
                name: "Reg_Regiao",
                schema: "Cadastro");
        }
    }
}
