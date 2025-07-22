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
                    Profissao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Outros = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsProprioCliente = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Representantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompletoRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NacionalidadeRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfissaoRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefoneRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CelularRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplementoRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CepRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BairroRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CidadeRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeNascimentoRepresentateLegal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdadeRepresentateLegal = table.Column<int>(type: "int", nullable: false),
                    RgRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CpfRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    TipoDeRepresentante = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Representantes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Representantes_ClienteId",
                table: "Representantes",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Representantes");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
