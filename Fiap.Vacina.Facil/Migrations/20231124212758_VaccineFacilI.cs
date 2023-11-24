using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Vacina.Facil.Migrations
{
    /// <inheritdoc />
    public partial class VaccineFacilI : Migration
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
                name: "T_VacinaFacil_Vaccine",
                columns: table => new
                {
                    VaccineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Composicao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Intervalo = table.Column<int>(type: "int", nullable: false),
                    DoseVacina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_VacinaFacil_Vaccine", x => x.VaccineId);
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
                name: "T_VacinaFacil_Fabricante",
                columns: table => new
                {
                    FabricanteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    VaccineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_VacinaFacil_Fabricante", x => x.FabricanteId);
                    table.ForeignKey(
                        name: "FK_T_VacinaFacil_Fabricante_T_VacinaFacil_Vaccine_VaccineId",
                        column: x => x.VaccineId,
                        principalTable: "T_VacinaFacil_Vaccine",
                        principalColumn: "VaccineId");
                });

            migrationBuilder.CreateTable(
                name: "T_VacinaFacil_Aviso",
                columns: table => new
                {
                    AvisoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Dt_Aviso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ds_Descrição = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_VacinaFacil_Aviso", x => new { x.ClienteId, x.AvisoId });
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

            migrationBuilder.CreateTable(
                name: "DependenteVaccines",
                columns: table => new
                {
                    DependenteId = table.Column<int>(type: "int", nullable: false),
                    VaccineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependenteVaccines", x => new { x.DependenteId, x.VaccineId });
                    table.ForeignKey(
                        name: "FK_DependenteVaccines_T_VacinaFacil_Dependente_VaccineId",
                        column: x => x.VaccineId,
                        principalTable: "T_VacinaFacil_Dependente",
                        principalColumn: "DependenteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DependenteVaccines_T_VacinaFacil_Vaccine_DependenteId",
                        column: x => x.DependenteId,
                        principalTable: "T_VacinaFacil_Vaccine",
                        principalColumn: "VaccineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DependenteVaccines_VaccineId",
                table: "DependenteVaccines",
                column: "VaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_T_VacinaFacil_Cliente_EnderecoId",
                table: "T_VacinaFacil_Cliente",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_T_VacinaFacil_Dependente_ClienteId",
                table: "T_VacinaFacil_Dependente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_T_VacinaFacil_Fabricante_VaccineId",
                table: "T_VacinaFacil_Fabricante",
                column: "VaccineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DependenteVaccines");

            migrationBuilder.DropTable(
                name: "T_VacinaFacil_Aviso");

            migrationBuilder.DropTable(
                name: "T_VacinaFacil_Fabricante");

            migrationBuilder.DropTable(
                name: "T_VacinaFacil_Dependente");

            migrationBuilder.DropTable(
                name: "T_VacinaFacil_Vaccine");

            migrationBuilder.DropTable(
                name: "T_VacinaFacil_Cliente");

            migrationBuilder.DropTable(
                name: "T_VacinaFacil_End");
        }
    }
}
