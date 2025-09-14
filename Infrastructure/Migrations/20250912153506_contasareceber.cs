using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class contasareceber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeneficiosServicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeBeneficioServico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiosServicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EtapaServico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEtapaServico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtapaServico", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
     name: "EtapaServicoId",
     table: "Clientes",
     type: "int",
     nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BeneficiosServicosId",
                table: "Clientes",
                type: "int",
                nullable: true);


            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_EtapaServico_EtapaServicoId",
                table: "Clientes",
                column: "EtapaServicoId",
                principalTable: "EtapaServico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
               name: "FK_Clientes_BeneficiosServicos_BeneficiosServicosId",
               table: "Clientes",
               column: "BeneficiosServicosId",
               principalTable: "BeneficiosServicos",
               principalColumn: "Id",
               onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropTable(
                name: "BeneficiosServicos");

            migrationBuilder.DropTable(
                name: "EtapaServico");
        }
    }
}
