using Application.DTOs.BeneficiosServicos;
using Application.DTOs.Clientes;
using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs.Contrato
{
    public class ContratoResponse
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public virtual ClienteResponse? Cliente { get; set; }
        public int DiaVencimento { get; set; }
        public int? IdBeneficioServico { get; set; }
        public virtual BeneficiosServicosResponse? Beneficios { get; set; }
        public string? DataVencimentoInicioParcelas { get; set; }
        public string? DataVencimentoFimParcelas { get; set; }
        public double? ValorParcelas { get; set; }
        public double? ValorEntrada { get; set; }
        public DateTime? DataPagamento { get; set; }
        public bool? StatusPagamentoMensal { get; set; }
        public string? StatusPagamentoTotal { get; set; }
        public string? Observacao { get; set; }
        public double? ValorTotal { get; set; }
        public int? QuantidadeParcelas { get; set; }
        public double? ValorRestante { get; set; }
        public DateTime? DataVencimentoParcelas { get; set; }
    }
}
