using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class parceiro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Cria a tabela Parceiros
            migrationBuilder.CreateTable(
                name: "Parceiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeParceiro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parceiros", x => x.Id);
                });

            // Adiciona a coluna ParceiroId à tabela Clientes
            migrationBuilder.AddColumn<int>(
                name: "ParceiroId",
                table: "Clientes",
                type: "int",
                nullable: true);

            // Cria o índice
            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ParceiroId",
                table: "Clientes",
                column: "ParceiroId");

            // Adiciona a chave estrangeira
            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Parceiros_ParceiroId",
                table: "Clientes",
                column: "ParceiroId",
                principalTable: "Parceiros",
                principalColumn: "Id");
        }

        
    }
}
