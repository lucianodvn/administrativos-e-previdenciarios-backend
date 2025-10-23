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
                name: "Agendamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataHoraDoAgendamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAtendido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.Id);
                });

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
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeDaMae = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    EstadoCivilRepresentateLegal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDoFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parceiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeParceiro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroOAB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CepEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BairroEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CidadeEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CnpjEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCivilParceiro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeFantasia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroOabDaEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RgParceiro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NacionalidadeParceiro = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parceiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recibos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroRecibo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recebedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPagoConfirmado = table.Column<bool>(type: "bit", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    HtmlContrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTotal = table.Column<double>(type: "float", nullable: true),
                    ValorEntrada = table.Column<double>(type: "float", nullable: true),
                    DataDoPagamentoDaEntrada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDoVencimentoValorEntrada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalDeParcelas = table.Column<int>(type: "int", nullable: true),
                    ParcelasPagas = table.Column<int>(type: "int", nullable: true),
                    ParcelasFaltantes = table.Column<int>(type: "int", nullable: true),
                    StatusContrato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorDasParcelas = table.Column<double>(type: "float", nullable: true),
                    ValorPagoParcela = table.Column<double>(type: "float", nullable: true),
                    ValorRestanteDoContrato = table.Column<double>(type: "float", nullable: true),
                    DiaDoVencimentoParcelas = table.Column<int>(type: "int", nullable: true),
                    DataDoVencimentoTotal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDoVencimentoParcela = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataPagamentoDaParcela = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProximoVencimentoDaParcela = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "VinculoClienteBeneficioEtapas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    EtapaServicoId = table.Column<int>(type: "int", nullable: false),
                    BeneficiosServicosId = table.Column<int>(type: "int", nullable: false),
                    SenhaGov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroDoProcesso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outros = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Historico = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VinculoClienteBeneficioEtapas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VinculoClienteBeneficioEtapas_BeneficiosServicos_BeneficiosServicosId",
                        column: x => x.BeneficiosServicosId,
                        principalTable: "BeneficiosServicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VinculoClienteBeneficioEtapas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VinculoClienteBeneficioEtapas_EtapaServico_EtapaServicoId",
                        column: x => x.EtapaServicoId,
                        principalTable: "EtapaServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContasAPagar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdParceiro = table.Column<int>(type: "int", nullable: true),
                    IdFornecedor = table.Column<int>(type: "int", nullable: true),
                    IsPago = table.Column<bool>(type: "bit", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasAPagar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasAPagar_Fornecedor_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalTable: "Fornecedor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContasAPagar_Parceiros_IdParceiro",
                        column: x => x.IdParceiro,
                        principalTable: "Parceiros",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContratoJudicial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: true),
                    IdParceiro = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<double>(type: "float", nullable: true),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    HtmlContrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDeContrato = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoJudicial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContratoJudicial_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContratoJudicial_Parceiros_IdParceiro",
                        column: x => x.IdParceiro,
                        principalTable: "Parceiros",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VinculoClienteParceiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ParceiroId = table.Column<int>(type: "int", nullable: false),
                    senhaGov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroDoProcesso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VinculoClienteParceiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VinculoClienteParceiros_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VinculoClienteParceiros_Parceiros_ParceiroId",
                        column: x => x.ParceiroId,
                        principalTable: "Parceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContasAReceber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPago = table.Column<bool>(type: "bit", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuantidadeParcelas = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    ValorEntrada = table.Column<double>(type: "float", nullable: true),
                    IdParceiro = table.Column<int>(type: "int", nullable: true),
                    IdFornecedor = table.Column<int>(type: "int", nullable: true),
                    IdContratoAdm = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasAReceber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasAReceber_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContasAReceber_Contrato_IdContratoAdm",
                        column: x => x.IdContratoAdm,
                        principalTable: "Contrato",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContasAReceber_Fornecedor_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalTable: "Fornecedor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContasAReceber_Parceiros_IdParceiro",
                        column: x => x.IdParceiro,
                        principalTable: "Parceiros",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContasAPagar_IdFornecedor",
                table: "ContasAPagar",
                column: "IdFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_ContasAPagar_IdParceiro",
                table: "ContasAPagar",
                column: "IdParceiro");

            migrationBuilder.CreateIndex(
                name: "IX_ContasAReceber_ClienteId",
                table: "ContasAReceber",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasAReceber_IdContratoAdm",
                table: "ContasAReceber",
                column: "IdContratoAdm");

            migrationBuilder.CreateIndex(
                name: "IX_ContasAReceber_IdFornecedor",
                table: "ContasAReceber",
                column: "IdFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_ContasAReceber_IdParceiro",
                table: "ContasAReceber",
                column: "IdParceiro");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_ClienteId",
                table: "Contrato",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoJudicial_IdCliente",
                table: "ContratoJudicial",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoJudicial_IdParceiro",
                table: "ContratoJudicial",
                column: "IdParceiro");

            migrationBuilder.CreateIndex(
                name: "IX_VinculoClienteBeneficioEtapas_BeneficiosServicosId",
                table: "VinculoClienteBeneficioEtapas",
                column: "BeneficiosServicosId");

            migrationBuilder.CreateIndex(
                name: "IX_VinculoClienteBeneficioEtapas_ClienteId",
                table: "VinculoClienteBeneficioEtapas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_VinculoClienteBeneficioEtapas_EtapaServicoId",
                table: "VinculoClienteBeneficioEtapas",
                column: "EtapaServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_VinculoClienteParceiros_ClienteId",
                table: "VinculoClienteParceiros",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_VinculoClienteParceiros_ParceiroId",
                table: "VinculoClienteParceiros",
                column: "ParceiroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "ContasAPagar");

            migrationBuilder.DropTable(
                name: "ContasAReceber");

            migrationBuilder.DropTable(
                name: "ContratoJudicial");

            migrationBuilder.DropTable(
                name: "Recibos");

            migrationBuilder.DropTable(
                name: "VinculoClienteBeneficioEtapas");

            migrationBuilder.DropTable(
                name: "VinculoClienteParceiros");

            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "BeneficiosServicos");

            migrationBuilder.DropTable(
                name: "EtapaServico");

            migrationBuilder.DropTable(
                name: "Parceiros");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
