using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ContasAReceber
    {
        public int Id { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente? Cliente { get; set; }
        public int ClienteId { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public string? Descricao { get; set; }
        public string? TipoDeAtendimento { get; set; }
        public int? QuantidadeParcelas { get; set; }
        public string? FormaPagamento { get; set; }
        public bool? StatusPagamento { get; set; }
        public double? ValorDevido { get; set; }
        public double? ValorPago { get; set; }
        public string? NumeroParcela { get; set; }
    }
}
