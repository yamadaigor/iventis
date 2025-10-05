using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iventis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entregador",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(14)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NumeroCnh = table.Column<string>(type: "text", nullable: false),
                    TipoCnh = table.Column<int>(type: "integer", nullable: false),
                    ImagemCnh = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ano = table.Column<string>(type: "varchar(4)", nullable: false),
                    Modelo = table.Column<string>(type: "text", nullable: false),
                    Placa = table.Column<string>(type: "varchar(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MotoId = table.Column<Guid>(type: "uuid", nullable: false),
                    EntregadorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DtInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DtTermino = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DtPrevisaoTermino = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Plano = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locacao_Entregador_EntregadorId",
                        column: x => x.EntregadorId,
                        principalTable: "Entregador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Locacao_Moto_MotoId",
                        column: x => x.MotoId,
                        principalTable: "Moto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_EntregadorId",
                table: "Locacao",
                column: "EntregadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_MotoId",
                table: "Locacao",
                column: "MotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locacao");

            migrationBuilder.DropTable(
                name: "Entregador");

            migrationBuilder.DropTable(
                name: "Moto");
        }
    }
}
