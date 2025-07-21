using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class criartabelarepresentantelegal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EtapdaDeServico",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsProprioCliente",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NumeroDoProcesso",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Outros",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenhaGov",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "EtapdaDeServico",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IsProprioCliente",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "NumeroDoProcesso",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Outros",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "SenhaGov",
                table: "Clientes");
        }
    }
}
