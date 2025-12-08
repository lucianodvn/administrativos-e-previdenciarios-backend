using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Contrato
    {
        public int Id { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }
        public int DiaVencimento { get; set; }

        [ForeignKey("IdBeneficioServico")]
        public int? IdBeneficioServico { get; set; }
        public virtual BeneficiosServicos? Beneficios { get; set; }
        public string? DataVencimentoInicioParcelas { get; set; }
        public string? DataVencimentoFimParcelas { get; set; }
        public double? ValorParcelas { get; set; }
        public double? ValorPago { get; set; }
        public double? ValorEntrada { get; set; }
        public DateTime? DataPagamento { get; set; }
        public bool? StatusPagamentoMensal { get; set; }
        public string? StatusPagamentoTotal { get; set; }
        public string? Observacao { get; set; }
        public double? ValorTotal { get; set; }
    }
}
