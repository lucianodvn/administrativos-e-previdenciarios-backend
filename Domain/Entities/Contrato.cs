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
        public string DiaVencimento { get; set; }

        [ForeignKey("IdBeneficioServico")]
        public int? IdBeneficioServico { get; set; }
        public virtual BeneficiosServicos? Beneficios { get; set; }
        public string? DataVencimentoInicioParcelas { get; set; }
        public string? DataVencimentoFimParcelas { get; set; }
        public double? ValorParcelas { get; set; }
        public double? ValorEntrada { get; set; }
        public DateTime? DataPagamento { get; set; }
        public double? ValorTotal { get; set; }
        public int? QuantidadeParcelas { get; set; }
        public double? ValorRestante { get; set; }
        public DateTime? DataVencimentoEntrada { get; set; }
    }
}
