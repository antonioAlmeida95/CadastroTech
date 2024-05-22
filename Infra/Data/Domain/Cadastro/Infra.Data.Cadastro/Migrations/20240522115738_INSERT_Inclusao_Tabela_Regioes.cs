using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Cadastro.Migrations
{
    /// <inheritdoc />
    public partial class INSERT_Inclusao_Tabela_Regioes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reg_Regiao",
                schema: "Cadastro",
                columns: new []
                {
                    "Reg_RegiaoId",
                    "Reg_Nome",
                    "Reg_Sigla"
                },
                values: new object[,]
                {
                    { Guid.Parse("4962c256-0850-455f-8a85-617e9ee941c0"), "Nordeste", "NE" },
                    { Guid.Parse("301be142-1644-4f85-b6d7-d5119b9e04ae"), "Norte", "N" },
                    { Guid.Parse("f3a26bc6-2444-481c-a21e-10d06633c9e7"), "Centro-Oeste", "CO" },
                    { Guid.Parse("ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"), "Sudeste", "SE" },
                    { Guid.Parse("4aa63d9d-dec6-4059-bdce-d6b1619eee38"), "Sul", "S" }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "Cod_CodigoDiscagem", schema: "Cadastro",
                keyColumn: "Reg_RegiaoId", keyValues: new object[]
                {
                    Guid.Parse("4962c256-0850-455f-8a85-617e9ee941c0"),
                    Guid.Parse("301be142-1644-4f85-b6d7-d5119b9e04ae"),
                    Guid.Parse("f3a26bc6-2444-481c-a21e-10d06633c9e7"),
                    Guid.Parse("ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"),
                    Guid.Parse("4aa63d9d-dec6-4059-bdce-d6b1619eee38")
                });
            
            migrationBuilder.DeleteData(table: "Reg_Regiao", schema: "Cadastro",
                keyColumn: "Reg_RegiaoId", keyValues: new object[]
                {
                    Guid.Parse("4962c256-0850-455f-8a85-617e9ee941c0"),
                    Guid.Parse("301be142-1644-4f85-b6d7-d5119b9e04ae"),
                    Guid.Parse("f3a26bc6-2444-481c-a21e-10d06633c9e7"),
                    Guid.Parse("ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"),
                    Guid.Parse("4aa63d9d-dec6-4059-bdce-d6b1619eee38")
                });
        }
    }
}
