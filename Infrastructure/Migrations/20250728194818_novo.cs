using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class novo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nacionalidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profissao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDeBeneficio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EtapaDeServico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenhaGov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDoProcesso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Outros = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsProprioCliente = table.Column<bool>(type: "bit", nullable: false),
                    NomeCompletoRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NacionalidadeRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfissaoRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoneRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CelularRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplementoRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CepRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BairroRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CidadeRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeNascimentoRepresentateLegal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdadeRepresentateLegal = table.Column<int>(type: "int", nullable: true),
                    RgRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpfRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDeRepresentante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutrosRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCivilRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    HtmlContrato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contrato_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_ClienteId",
                table: "Contrato",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
