using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Cpf = table.Column<string>(type: "TEXT", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Cargo = table.Column<string>(type: "TEXT", nullable: true),
                    NRegistro = table.Column<string>(type: "TEXT", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                });

            migrationBuilder.CreateTable(
                name: "OrdensServicos",
                columns: table => new
                {
                    OrdemDeServicoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DescricaoServico = table.Column<string>(type: "TEXT", nullable: true),
                    Instrumento = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    ValorEstimado = table.Column<double>(type: "REAL", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdensServicos", x => x.OrdemDeServicoId);
                    table.ForeignKey(
                        name: "FK_OrdensServicos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdensServicos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Cpf", "CriadoEm", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, "1234", new DateTime(2024, 12, 7, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9877), "Luis", "41984707329" },
                    { 2, "5678", new DateTime(2024, 12, 8, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9882), "Victor", "41997438180" },
                    { 3, "9101", new DateTime(2024, 12, 8, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9885), "Carmem", "41963457075" },
                    { 4, "1121", new DateTime(2024, 12, 8, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9888), "Otavio", "41988623514" },
                    { 5, "3141", new DateTime(2024, 12, 9, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9890), "João Pedro", "41999125678" },
                    { 6, "5161", new DateTime(2024, 12, 9, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9893), "Luisa", "43990842030" },
                    { 7, "7181", new DateTime(2024, 12, 10, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9895), "Vitória", "47988702098" },
                    { 8, "9202", new DateTime(2024, 12, 10, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9898), "Julia", "42988635587" },
                    { 9, "1222", new DateTime(2024, 12, 12, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9901), "Marcela", "41995234578" },
                    { 10, "3242", new DateTime(2024, 12, 12, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9904), "Marcia", "45987889339" }
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "FuncionarioId", "Cargo", "CriadoEm", "NRegistro", "Nome" },
                values: new object[,]
                {
                    { 1, "Luthier", new DateTime(2024, 12, 2, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9688), null, "Cleiton" },
                    { 2, "Luthier Aprendiz", new DateTime(2025, 2, 1, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9701), null, "Antônio" },
                    { 3, "Luthier", new DateTime(2025, 2, 15, 19, 6, 24, 583, DateTimeKind.Local).AddTicks(9704), null, "Paulo" }
                });

            migrationBuilder.InsertData(
                table: "OrdensServicos",
                columns: new[] { "OrdemDeServicoId", "ClienteId", "CriadoEm", "DescricaoServico", "FuncionarioId", "Instrumento", "Status", "ValorEstimado" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 7, 19, 6, 24, 584, DateTimeKind.Local).AddTicks(14), "Troca da Cortiça", 1, "Clarinete", "Finalizado", 106.59999999999999 },
                    { 2, 2, new DateTime(2024, 12, 8, 19, 6, 24, 584, DateTimeKind.Local).AddTicks(18), "Realinhamento do Braço", 2, "Violão Takamine", "Pendente", 560.0 },
                    { 3, 3, new DateTime(2024, 12, 8, 19, 6, 24, 584, DateTimeKind.Local).AddTicks(21), "Lustragem", 1, "Trombone", "Pendente", 130.0 },
                    { 4, 6, new DateTime(2024, 12, 9, 19, 6, 24, 584, DateTimeKind.Local).AddTicks(25), "Troca de cordas e Manutenções Gerais", 1, "Ibanez", "Em Andamento", 570.0 },
                    { 5, 4, new DateTime(2024, 12, 8, 19, 6, 24, 584, DateTimeKind.Local).AddTicks(28), "Revisão", 2, "Fagote", "Pendente", 200.0 },
                    { 6, 8, new DateTime(2024, 12, 10, 19, 6, 24, 584, DateTimeKind.Local).AddTicks(31), "Realinhamento do Braço", 2, "Takamine", "Pendente", 500.0 },
                    { 7, 3, new DateTime(2024, 12, 8, 19, 6, 24, 584, DateTimeKind.Local).AddTicks(35), "Troca de trastes", 3, "Violão Yamaha", "Pendente", 900.0 },
                    { 8, 10, new DateTime(2024, 12, 12, 19, 6, 24, 584, DateTimeKind.Local).AddTicks(38), "Revisão", 3, "Guitarra Gibson", "Pendente", 400.0 },
                    { 9, 5, new DateTime(2024, 12, 9, 19, 6, 24, 584, DateTimeKind.Local).AddTicks(41), "Troca de cordas e Manutenções Gerais", 3, "Violão DiGiogio", "Em Andamento", 643.0 },
                    { 10, 7, new DateTime(2024, 12, 10, 19, 6, 24, 584, DateTimeKind.Local).AddTicks(44), "Revisão", 3, "Contrabaixo", "Finalizado", 700.39999999999998 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdensServicos_ClienteId",
                table: "OrdensServicos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdensServicos_FuncionarioId",
                table: "OrdensServicos",
                column: "FuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdensServicos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
