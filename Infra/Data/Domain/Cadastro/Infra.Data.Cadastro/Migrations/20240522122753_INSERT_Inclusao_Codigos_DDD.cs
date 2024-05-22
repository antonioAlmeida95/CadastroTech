using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Cadastro.Migrations
{
    /// <inheritdoc />
    public partial class INSERT_Inclusao_Codigos_DDD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Região Centro-Oeste
            migrationBuilder.InsertData(
                table: "Cod_CodigoDiscagem",
                schema: "Cadastro",
                columns: new[]
                {
                    "Cod_CodigoDiscagemId",
                    "Cod_Ddd",
                    "Reg_RegiaoId"
                },
                values: new object[,]
                {
                    { Guid.Parse("51fe35ef-ee56-4b7d-96d7-74c1c86a8c0f"), 61, "f3a26bc6-2444-481c-a21e-10d06633c9e7"},
                    { Guid.Parse("fc9733f2-a886-4b94-afbe-a1265c5e9759"), 62, "f3a26bc6-2444-481c-a21e-10d06633c9e7"},
                    { Guid.Parse("d4af9b7b-9973-4cba-808d-799355da6aff"), 64, "f3a26bc6-2444-481c-a21e-10d06633c9e7"},
                    { Guid.Parse("98b4e6a1-a63c-480c-9df0-276e63b18da9"), 65, "f3a26bc6-2444-481c-a21e-10d06633c9e7"},
                    { Guid.Parse("48916426-eef5-48aa-969f-89eebbe4e1bf"), 66, "f3a26bc6-2444-481c-a21e-10d06633c9e7"},
                    { Guid.Parse("05a1f7d8-58e5-4b4d-95cf-b76451317254"), 67, "f3a26bc6-2444-481c-a21e-10d06633c9e7"},
                });
            
            //Região Nordeste
            migrationBuilder.InsertData(
                table: "Cod_CodigoDiscagem",
                schema: "Cadastro",
                columns: new[]
                {
                    "Cod_CodigoDiscagemId",
                    "Cod_Ddd",
                    "Reg_RegiaoId"
                },
                values: new object[,]
                {
                    { Guid.Parse("dd68b177-786e-47c6-8232-5a9d14e85a1f"), 82, "4962c256-0850-455f-8a85-617e9ee941c0"},
                    { Guid.Parse("236dda22-addf-45ca-a975-be0d0366398f"), 71, "4962c256-0850-455f-8a85-617e9ee941c0"},
                    { Guid.Parse("6324f59b-65ec-4af8-b10d-64b825a03df1"), 73, "4962c256-0850-455f-8a85-617e9ee941c0"},
                    { Guid.Parse("a424e61d-c67b-48c9-9a06-a753bf4ba58c"), 74, "4962c256-0850-455f-8a85-617e9ee941c0"},
                    { Guid.Parse("e3854c2c-7817-4233-962a-7f3df55779a4"), 75, "4962c256-0850-455f-8a85-617e9ee941c0"},
                    { Guid.Parse("c1146ee7-d890-4382-9026-aa685ed966db"), 77, "4962c256-0850-455f-8a85-617e9ee941c0"},
                    { Guid.Parse("2cdc6c2c-ded5-47fa-8a4f-0ff4bfd35e9b"), 85, "4962c256-0850-455f-8a85-617e9ee941c0"},
                    { Guid.Parse("a9a84037-8685-4839-ba4c-cfd775957162"), 88, "4962c256-0850-455f-8a85-617e9ee941c0"},
                    { Guid.Parse("35b14d1a-187a-43ff-93a5-cfb710ffb385"), 98, "4962c256-0850-455f-8a85-617e9ee941c0"},
                    { Guid.Parse("c18cb4d5-89dd-41da-86de-217ecdef7070"), 99, "4962c256-0850-455f-8a85-617e9ee941c0"},
                    { Guid.Parse("07a5c99d-4e27-421e-beb4-f5c52ec92e5f"), 83, "4962c256-0850-455f-8a85-617e9ee941c0"},
                    { Guid.Parse("1f569bb4-50f5-4b1d-99b5-58f40ff77be2"), 81, "4962c256-0850-455f-8a85-617e9ee941c0"},
                    { Guid.Parse("3df36dd9-1bba-4e38-8edc-42e6ac6d6d87"), 87, "4962c256-0850-455f-8a85-617e9ee941c0"},
                    { Guid.Parse("75020ae3-4362-4359-ac83-271eb0876a63"), 86, "4962c256-0850-455f-8a85-617e9ee941c0"},
                    { Guid.Parse("5bdf6b32-c339-45bb-9f4a-e0ba8dcbf82e"), 89, "4962c256-0850-455f-8a85-617e9ee941c0"},
                    { Guid.Parse("eb57e9ec-8216-4938-9710-19d17bd43168"), 84, "4962c256-0850-455f-8a85-617e9ee941c0"},
                    { Guid.Parse("49319d34-f8bf-4e3e-8ab4-1305b45ab09c"), 79, "4962c256-0850-455f-8a85-617e9ee941c0"}
                });
            
            //Região Norte
            migrationBuilder.InsertData(
                table: "Cod_CodigoDiscagem",
                schema: "Cadastro",
                columns: new[]
                {
                    "Cod_CodigoDiscagemId",
                    "Cod_Ddd",
                    "Reg_RegiaoId"
                },
                values: new object[,]
                {
                    { Guid.Parse("545ce54c-a587-47bf-b0c0-e73f97df9df3"), 68, "301be142-1644-4f85-b6d7-d5119b9e04ae"},
                    { Guid.Parse("77154457-f44f-4438-8ff0-5ad92da141d9"), 96, "301be142-1644-4f85-b6d7-d5119b9e04ae"},
                    { Guid.Parse("c2921375-ed07-43f8-914d-b734b61913d7"), 92, "301be142-1644-4f85-b6d7-d5119b9e04ae"},
                    { Guid.Parse("7563a706-05e1-48ba-bc7d-f4ef5283b64c"), 97, "301be142-1644-4f85-b6d7-d5119b9e04ae"},
                    { Guid.Parse("580af63e-a157-4837-8181-721d891647f5"), 91, "301be142-1644-4f85-b6d7-d5119b9e04ae"},
                    { Guid.Parse("d18e6515-b567-4555-b036-5b326b1bffc7"), 93, "301be142-1644-4f85-b6d7-d5119b9e04ae"},
                    { Guid.Parse("0ebe18d4-b3f9-42f9-bafe-7d4d17a8123c"), 94, "301be142-1644-4f85-b6d7-d5119b9e04ae"},
                    { Guid.Parse("a2e27664-55b9-4a4b-adb2-3951c384a0cf"), 69, "301be142-1644-4f85-b6d7-d5119b9e04ae"},
                    { Guid.Parse("930fa3d3-33db-4144-911d-cf712cf44ea9"), 95, "301be142-1644-4f85-b6d7-d5119b9e04ae"},
                    { Guid.Parse("2677d264-42d3-4812-8324-c3c4a36a8796"), 63, "301be142-1644-4f85-b6d7-d5119b9e04ae"}
                });
            
            //Região Sudeste
            migrationBuilder.InsertData(
                table: "Cod_CodigoDiscagem",
                schema: "Cadastro",
                columns: new[]
                {
                    "Cod_CodigoDiscagemId",
                    "Cod_Ddd",
                    "Reg_RegiaoId"
                },
                values: new object[,]
                {
                    { Guid.Parse("10a3418d-befb-4eb1-9b96-1e22230127a8"), 27, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"},
                    { Guid.Parse("93ce3736-4104-431e-8a07-8533bf0583b8"), 28, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"},
                    { Guid.Parse("1f73bad1-b9ce-449a-ac81-33e6bb21c12b"), 31, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"},
                    { Guid.Parse("97ef9c33-04dc-4bad-a3cb-0f6942c99815"), 32, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"},
                    { Guid.Parse("386c857b-d0e3-4ec9-ad22-8d82c757a5e4"), 33, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"},
                    { Guid.Parse("f70ebc3e-934c-4d32-a9e4-d455e4354d5d"), 34, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"},
                    { Guid.Parse("b10796b2-9ee0-49ff-9d7d-029e48f38f82"), 35, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"},
                    { Guid.Parse("1ce7f159-9a26-4106-8743-b09f066a17bc"), 37, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"},
                    { Guid.Parse("0017ae22-6d1f-45d5-84c9-439cdc20e30f"), 38, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"},
                    { Guid.Parse("2acf4586-5841-4c0d-9695-f2dc61cf58ae"), 21, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"},
                    { Guid.Parse("f5e04cb8-41d5-48c1-b17d-b301b6b30c97"), 22, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"},
                    { Guid.Parse("8328b640-332d-42e0-bc64-caf8497a1751"), 24, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"},
                    { Guid.Parse("bc858609-83b8-462b-b745-f648dd841570"), 11, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"},
                    { Guid.Parse("740132a0-675e-4537-b24b-7951e8d5e3c9"), 12, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"},
                    { Guid.Parse("7de36a6e-7cc3-423d-b284-2497348b0c9b"), 13, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"},
                    { Guid.Parse("967df510-4a5c-45f6-b9b3-cd513ff3b743"), 14, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"},
                    { Guid.Parse("17193633-134a-4578-aebe-5822761e3f9a"), 15, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"},
                    { Guid.Parse("a87b8d4a-f2bf-4159-94f7-fc616852fae6"), 16, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"},
                    { Guid.Parse("a5fbb467-8c55-449d-ba7d-3254ca1230b7"), 17, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"},
                    { Guid.Parse("a9f3d4d4-50b1-4cb9-a131-8d0ece1efdcd"), 18, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"},
                    { Guid.Parse("6916ae93-ade9-4a02-9950-6b99a5c9f6cc"), 19, "ce53cfbb-b1eb-48b2-8dc4-30e9409ffa04"}
                });
            
            //Região Sul
            migrationBuilder.InsertData(
                table: "Cod_CodigoDiscagem",
                schema: "Cadastro",
                columns: new[]
                {
                    "Cod_CodigoDiscagemId",
                    "Cod_Ddd",
                    "Reg_RegiaoId"
                },
                values: new object[,]
                {
                    { Guid.Parse("e998ac00-a1a2-4bf5-85b8-671b29b62e75"), 41, "4aa63d9d-dec6-4059-bdce-d6b1619eee38"},
                    { Guid.Parse("d9ff228e-cb9c-4ade-96ea-463b7565376e"), 42, "4aa63d9d-dec6-4059-bdce-d6b1619eee38"},
                    { Guid.Parse("52bce241-30ed-4a6f-9df7-bc71b07a2e0a"), 43, "4aa63d9d-dec6-4059-bdce-d6b1619eee38"},
                    { Guid.Parse("5f1271dc-461d-4012-a710-5057969565a7"), 44, "4aa63d9d-dec6-4059-bdce-d6b1619eee38"},
                    { Guid.Parse("32ceff31-4c42-4c71-9a37-1715ead7dc20"), 45, "4aa63d9d-dec6-4059-bdce-d6b1619eee38"},
                    { Guid.Parse("034109b3-3ea2-4ad7-bcdb-1627c287529a"), 46, "4aa63d9d-dec6-4059-bdce-d6b1619eee38"},
                    { Guid.Parse("6e192464-852a-4baa-849c-86051bb097f4"), 51, "4aa63d9d-dec6-4059-bdce-d6b1619eee38"},
                    { Guid.Parse("bb9b2fb7-5837-4616-8abc-ef2b012aea5d"), 53, "4aa63d9d-dec6-4059-bdce-d6b1619eee38"},
                    { Guid.Parse("b11b4444-dae4-43cd-8874-9debf1fbf181"), 54, "4aa63d9d-dec6-4059-bdce-d6b1619eee38"},
                    { Guid.Parse("87adc308-66d4-4ced-b3ca-dfad8dd01556"), 55, "4aa63d9d-dec6-4059-bdce-d6b1619eee38"},
                    { Guid.Parse("26dad4d8-5850-4edc-bc2d-81a32bea8ad4"), 47, "4aa63d9d-dec6-4059-bdce-d6b1619eee38"},
                    { Guid.Parse("ff532021-4c78-426d-bcad-208b3128c721"), 48, "4aa63d9d-dec6-4059-bdce-d6b1619eee38"},
                    { Guid.Parse("182ac76e-e48b-427f-93c4-a964059ede1f"), 49, "4aa63d9d-dec6-4059-bdce-d6b1619eee38"}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //Região Centro-Oeste
            migrationBuilder.DeleteData(table: "Con_Contato", schema: "Cadastro",
                keyColumn: "Cod_CodigoDiscagemId", keyValues: new object[]
                {
                    Guid.Parse("51fe35ef-ee56-4b7d-96d7-74c1c86a8c0f"),
                    Guid.Parse("fc9733f2-a886-4b94-afbe-a1265c5e9759"),
                    Guid.Parse("d4af9b7b-9973-4cba-808d-799355da6aff"),
                    Guid.Parse("98b4e6a1-a63c-480c-9df0-276e63b18da9"),
                    Guid.Parse("48916426-eef5-48aa-969f-89eebbe4e1bf"),
                    Guid.Parse("05a1f7d8-58e5-4b4d-95cf-b76451317254")
                });
            
            migrationBuilder.DeleteData(table: "Cod_CodigoDiscagem", schema: "Cadastro",
                keyColumn: "Cod_CodigoDiscagemId", keyValues: new object[]
                {
                    Guid.Parse("51fe35ef-ee56-4b7d-96d7-74c1c86a8c0f"),
                    Guid.Parse("fc9733f2-a886-4b94-afbe-a1265c5e9759"),
                    Guid.Parse("d4af9b7b-9973-4cba-808d-799355da6aff"),
                    Guid.Parse("98b4e6a1-a63c-480c-9df0-276e63b18da9"),
                    Guid.Parse("48916426-eef5-48aa-969f-89eebbe4e1bf"),
                    Guid.Parse("05a1f7d8-58e5-4b4d-95cf-b76451317254")
                });
            
            //Região Nordeste
            migrationBuilder.DeleteData(table: "Con_Contato", schema: "Cadastro",
                keyColumn: "Cod_CodigoDiscagemId", keyValues: new object[]
                {
                    Guid.Parse("dd68b177-786e-47c6-8232-5a9d14e85a1f"),
                    Guid.Parse("236dda22-addf-45ca-a975-be0d0366398f"),
                    Guid.Parse("6324f59b-65ec-4af8-b10d-64b825a03df1"),
                    Guid.Parse("a424e61d-c67b-48c9-9a06-a753bf4ba58c"),
                    Guid.Parse("e3854c2c-7817-4233-962a-7f3df55779a4"),
                    Guid.Parse("c1146ee7-d890-4382-9026-aa685ed966db"),
                    Guid.Parse("2cdc6c2c-ded5-47fa-8a4f-0ff4bfd35e9b"),
                    Guid.Parse("a9a84037-8685-4839-ba4c-cfd775957162"),
                    Guid.Parse("35b14d1a-187a-43ff-93a5-cfb710ffb385"),
                    Guid.Parse("c18cb4d5-89dd-41da-86de-217ecdef7070"),
                    Guid.Parse("07a5c99d-4e27-421e-beb4-f5c52ec92e5f"),
                    Guid.Parse("1f569bb4-50f5-4b1d-99b5-58f40ff77be2"),
                    Guid.Parse("3df36dd9-1bba-4e38-8edc-42e6ac6d6d87"),
                    Guid.Parse("75020ae3-4362-4359-ac83-271eb0876a63"),
                    Guid.Parse("5bdf6b32-c339-45bb-9f4a-e0ba8dcbf82e"),
                    Guid.Parse("eb57e9ec-8216-4938-9710-19d17bd43168"),
                    Guid.Parse("49319d34-f8bf-4e3e-8ab4-1305b45ab09c")
                });
            
            migrationBuilder.DeleteData(table: "Cod_CodigoDiscagem", schema: "Cadastro",
                keyColumn: "Cod_CodigoDiscagemId", keyValues: new object[]
                {
                    Guid.Parse("dd68b177-786e-47c6-8232-5a9d14e85a1f"),
                    Guid.Parse("236dda22-addf-45ca-a975-be0d0366398f"),
                    Guid.Parse("6324f59b-65ec-4af8-b10d-64b825a03df1"),
                    Guid.Parse("a424e61d-c67b-48c9-9a06-a753bf4ba58c"),
                    Guid.Parse("e3854c2c-7817-4233-962a-7f3df55779a4"),
                    Guid.Parse("c1146ee7-d890-4382-9026-aa685ed966db"),
                    Guid.Parse("2cdc6c2c-ded5-47fa-8a4f-0ff4bfd35e9b"),
                    Guid.Parse("a9a84037-8685-4839-ba4c-cfd775957162"),
                    Guid.Parse("35b14d1a-187a-43ff-93a5-cfb710ffb385"),
                    Guid.Parse("c18cb4d5-89dd-41da-86de-217ecdef7070"),
                    Guid.Parse("07a5c99d-4e27-421e-beb4-f5c52ec92e5f"),
                    Guid.Parse("1f569bb4-50f5-4b1d-99b5-58f40ff77be2"),
                    Guid.Parse("3df36dd9-1bba-4e38-8edc-42e6ac6d6d87"),
                    Guid.Parse("75020ae3-4362-4359-ac83-271eb0876a63"),
                    Guid.Parse("5bdf6b32-c339-45bb-9f4a-e0ba8dcbf82e"),
                    Guid.Parse("eb57e9ec-8216-4938-9710-19d17bd43168"),
                    Guid.Parse("49319d34-f8bf-4e3e-8ab4-1305b45ab09c")
                });
            
            //Região Norte
            migrationBuilder.DeleteData(table: "Con_Contato", schema: "Cadastro",
                keyColumn: "Cod_CodigoDiscagemId", keyValues: new object[]
                {
                    Guid.Parse("545ce54c-a587-47bf-b0c0-e73f97df9df3"),
                    Guid.Parse("77154457-f44f-4438-8ff0-5ad92da141d9"),
                    Guid.Parse("c2921375-ed07-43f8-914d-b734b61913d7"),
                    Guid.Parse("7563a706-05e1-48ba-bc7d-f4ef5283b64c"),
                    Guid.Parse("580af63e-a157-4837-8181-721d891647f5"),
                    Guid.Parse("d18e6515-b567-4555-b036-5b326b1bffc7"),
                    Guid.Parse("0ebe18d4-b3f9-42f9-bafe-7d4d17a8123c"),
                    Guid.Parse("a2e27664-55b9-4a4b-adb2-3951c384a0cf"),
                    Guid.Parse("930fa3d3-33db-4144-911d-cf712cf44ea9"),
                    Guid.Parse("2677d264-42d3-4812-8324-c3c4a36a8796")
                });
            
            migrationBuilder.DeleteData(table: "Cod_CodigoDiscagem", schema: "Cadastro",
                keyColumn: "Cod_CodigoDiscagemId", keyValues: new object[]
                {
                    Guid.Parse("545ce54c-a587-47bf-b0c0-e73f97df9df3"),
                    Guid.Parse("77154457-f44f-4438-8ff0-5ad92da141d9"),
                    Guid.Parse("c2921375-ed07-43f8-914d-b734b61913d7"),
                    Guid.Parse("7563a706-05e1-48ba-bc7d-f4ef5283b64c"),
                    Guid.Parse("580af63e-a157-4837-8181-721d891647f5"),
                    Guid.Parse("d18e6515-b567-4555-b036-5b326b1bffc7"),
                    Guid.Parse("0ebe18d4-b3f9-42f9-bafe-7d4d17a8123c"),
                    Guid.Parse("a2e27664-55b9-4a4b-adb2-3951c384a0cf"),
                    Guid.Parse("930fa3d3-33db-4144-911d-cf712cf44ea9"),
                    Guid.Parse("2677d264-42d3-4812-8324-c3c4a36a8796")
                });
            
            //Região Sudeste
            migrationBuilder.DeleteData(table: "Con_Contato", schema: "Cadastro",
                keyColumn: "Cod_CodigoDiscagemId", keyValues: new object[]
                {
                    Guid.Parse("10a3418d-befb-4eb1-9b96-1e22230127a8"),
                    Guid.Parse("93ce3736-4104-431e-8a07-8533bf0583b8"),
                    Guid.Parse("1f73bad1-b9ce-449a-ac81-33e6bb21c12b"),
                    Guid.Parse("97ef9c33-04dc-4bad-a3cb-0f6942c99815"),
                    Guid.Parse("386c857b-d0e3-4ec9-ad22-8d82c757a5e4"),
                    Guid.Parse("f70ebc3e-934c-4d32-a9e4-d455e4354d5d"),
                    Guid.Parse("b10796b2-9ee0-49ff-9d7d-029e48f38f82"),
                    Guid.Parse("1ce7f159-9a26-4106-8743-b09f066a17bc"),
                    Guid.Parse("0017ae22-6d1f-45d5-84c9-439cdc20e30f"),
                    Guid.Parse("2acf4586-5841-4c0d-9695-f2dc61cf58ae"),
                    Guid.Parse("f5e04cb8-41d5-48c1-b17d-b301b6b30c97"),
                    Guid.Parse("8328b640-332d-42e0-bc64-caf8497a1751"),
                    Guid.Parse("bc858609-83b8-462b-b745-f648dd841570"),
                    Guid.Parse("740132a0-675e-4537-b24b-7951e8d5e3c9"),
                    Guid.Parse("7de36a6e-7cc3-423d-b284-2497348b0c9b"),
                    Guid.Parse("967df510-4a5c-45f6-b9b3-cd513ff3b743"),
                    Guid.Parse("17193633-134a-4578-aebe-5822761e3f9a"),
                    Guid.Parse("a87b8d4a-f2bf-4159-94f7-fc616852fae6"),
                    Guid.Parse("a5fbb467-8c55-449d-ba7d-3254ca1230b7"),
                    Guid.Parse("a9f3d4d4-50b1-4cb9-a131-8d0ece1efdcd"),
                    Guid.Parse("6916ae93-ade9-4a02-9950-6b99a5c9f6cc")
                });
            
            migrationBuilder.DeleteData(table: "Cod_CodigoDiscagem", schema: "Cadastro",
                keyColumn: "Cod_CodigoDiscagemId", keyValues: new object[]
                {
                    Guid.Parse("10a3418d-befb-4eb1-9b96-1e22230127a8"),
                    Guid.Parse("93ce3736-4104-431e-8a07-8533bf0583b8"),
                    Guid.Parse("1f73bad1-b9ce-449a-ac81-33e6bb21c12b"),
                    Guid.Parse("97ef9c33-04dc-4bad-a3cb-0f6942c99815"),
                    Guid.Parse("386c857b-d0e3-4ec9-ad22-8d82c757a5e4"),
                    Guid.Parse("f70ebc3e-934c-4d32-a9e4-d455e4354d5d"),
                    Guid.Parse("b10796b2-9ee0-49ff-9d7d-029e48f38f82"),
                    Guid.Parse("1ce7f159-9a26-4106-8743-b09f066a17bc"),
                    Guid.Parse("0017ae22-6d1f-45d5-84c9-439cdc20e30f"),
                    Guid.Parse("2acf4586-5841-4c0d-9695-f2dc61cf58ae"),
                    Guid.Parse("f5e04cb8-41d5-48c1-b17d-b301b6b30c97"),
                    Guid.Parse("8328b640-332d-42e0-bc64-caf8497a1751"),
                    Guid.Parse("bc858609-83b8-462b-b745-f648dd841570"),
                    Guid.Parse("740132a0-675e-4537-b24b-7951e8d5e3c9"),
                    Guid.Parse("7de36a6e-7cc3-423d-b284-2497348b0c9b"),
                    Guid.Parse("967df510-4a5c-45f6-b9b3-cd513ff3b743"),
                    Guid.Parse("17193633-134a-4578-aebe-5822761e3f9a"),
                    Guid.Parse("a87b8d4a-f2bf-4159-94f7-fc616852fae6"),
                    Guid.Parse("a5fbb467-8c55-449d-ba7d-3254ca1230b7"),
                    Guid.Parse("a9f3d4d4-50b1-4cb9-a131-8d0ece1efdcd"),
                    Guid.Parse("6916ae93-ade9-4a02-9950-6b99a5c9f6cc")
                });
            
            //Região Sul
            migrationBuilder.DeleteData(table: "Con_Contato", schema: "Cadastro",
                keyColumn: "Cod_CodigoDiscagemId", keyValues: new object[]
                {
                    Guid.Parse("e998ac00-a1a2-4bf5-85b8-671b29b62e75"),
                    Guid.Parse("d9ff228e-cb9c-4ade-96ea-463b7565376e"),
                    Guid.Parse("52bce241-30ed-4a6f-9df7-bc71b07a2e0a"),
                    Guid.Parse("5f1271dc-461d-4012-a710-5057969565a7"),
                    Guid.Parse("32ceff31-4c42-4c71-9a37-1715ead7dc20"),
                    Guid.Parse("034109b3-3ea2-4ad7-bcdb-1627c287529a"),
                    Guid.Parse("6e192464-852a-4baa-849c-86051bb097f4"),
                    Guid.Parse("bb9b2fb7-5837-4616-8abc-ef2b012aea5d"),
                    Guid.Parse("b11b4444-dae4-43cd-8874-9debf1fbf181"),
                    Guid.Parse("87adc308-66d4-4ced-b3ca-dfad8dd01556"),
                    Guid.Parse("26dad4d8-5850-4edc-bc2d-81a32bea8ad4"),
                    Guid.Parse("ff532021-4c78-426d-bcad-208b3128c721"),
                    Guid.Parse("182ac76e-e48b-427f-93c4-a964059ede1f")
                });
            
            migrationBuilder.DeleteData(table: "Cod_CodigoDiscagem", schema: "Cadastro",
                keyColumn: "Cod_CodigoDiscagemId", keyValues: new object[]
                {
                    Guid.Parse("e998ac00-a1a2-4bf5-85b8-671b29b62e75"),
                    Guid.Parse("d9ff228e-cb9c-4ade-96ea-463b7565376e"),
                    Guid.Parse("52bce241-30ed-4a6f-9df7-bc71b07a2e0a"),
                    Guid.Parse("5f1271dc-461d-4012-a710-5057969565a7"),
                    Guid.Parse("32ceff31-4c42-4c71-9a37-1715ead7dc20"),
                    Guid.Parse("034109b3-3ea2-4ad7-bcdb-1627c287529a"),
                    Guid.Parse("6e192464-852a-4baa-849c-86051bb097f4"),
                    Guid.Parse("bb9b2fb7-5837-4616-8abc-ef2b012aea5d"),
                    Guid.Parse("b11b4444-dae4-43cd-8874-9debf1fbf181"),
                    Guid.Parse("87adc308-66d4-4ced-b3ca-dfad8dd01556"),
                    Guid.Parse("26dad4d8-5850-4edc-bc2d-81a32bea8ad4"),
                    Guid.Parse("ff532021-4c78-426d-bcad-208b3128c721"),
                    Guid.Parse("182ac76e-e48b-427f-93c4-a964059ede1f")
                });
        }
    }
}
