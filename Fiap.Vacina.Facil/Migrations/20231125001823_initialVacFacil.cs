using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Vacina.Facil.Migrations
{
    /// <inheritdoc />
    public partial class initialVacFacil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_VacinaFacil_End",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_VacinaFacil_End", x => x.EnderecoId);
                });

            migrationBuilder.CreateTable(
                name: "T_VacinaFacil_Fabricante",
                columns: table => new
                {
                    FabricanteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_VacinaFacil_Fabricante", x => x.FabricanteId);
                });

            migrationBuilder.CreateTable(
                name: "T_VacinaFacil_Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_VacinaFacil_Cliente", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_T_VacinaFacil_Cliente_T_VacinaFacil_End_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "T_VacinaFacil_End",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_VacinaFacil_Vaccine",
                columns: table => new
                {
                    VaccineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Composicao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Intervalo = table.Column<int>(type: "int", nullable: false),
                    DoseVacina = table.Column<int>(type: "int", nullable: false),
                    FabricanteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_VacinaFacil_Vaccine", x => x.VaccineId);
                    table.ForeignKey(
                        name: "FK_T_VacinaFacil_Vaccine_T_VacinaFacil_Fabricante_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "T_VacinaFacil_Fabricante",
                        principalColumn: "FabricanteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_VacinaFacil_Aviso",
                columns: table => new
                {
                    AvisoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dt_Aviso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ds_Descrição = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_VacinaFacil_Aviso", x => x.AvisoId);
                    table.ForeignKey(
                        name: "FK_T_VacinaFacil_Aviso_T_VacinaFacil_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "T_VacinaFacil_Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_VacinaFacil_Dependente",
                columns: table => new
                {
                    DependenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_VacinaFacil_Dependente", x => x.DependenteId);
                    table.ForeignKey(
                        name: "FK_T_VacinaFacil_Dependente_T_VacinaFacil_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "T_VacinaFacil_Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_VacinaFacil_Aviso_ClienteId",
                table: "T_VacinaFacil_Aviso",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_T_VacinaFacil_Cliente_EnderecoId",
                table: "T_VacinaFacil_Cliente",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_T_VacinaFacil_Dependente_ClienteId",
                table: "T_VacinaFacil_Dependente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_T_VacinaFacil_Vaccine_FabricanteId",
                table: "T_VacinaFacil_Vaccine",
                column: "FabricanteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_VacinaFacil_Aviso");

            migrationBuilder.DropTable(
                name: "T_VacinaFacil_Dependente");

            migrationBuilder.DropTable(
                name: "T_VacinaFacil_Vaccine");

            migrationBuilder.DropTable(
                name: "T_VacinaFacil_Cliente");

            migrationBuilder.DropTable(
                name: "T_VacinaFacil_Fabricante");

            migrationBuilder.DropTable(
                name: "T_VacinaFacil_End");
        }
    }
}
