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
        public string? HtmlContrato { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public double? ValorTotal { get; set; }
        public double? ValorEntrada { get; set; }
        public DateTime? DataDoPagamentoDaEntrada { get; set; }
        public DateTime? DataDoVencimentoValorEntrada { get; set; }
        public int? TotalDeParcelas { get; set; }
        public int? ParcelasPagas { get; set; }
        public int? ParcelasFaltantes { get; set; }
        public StatusContratoEnum StatusContrato { get; set; }
        public double? ValorDasParcelas { get; set; }
        public double? ValorPagoParcela { get; set; }
        public double? ValorRestanteDoContrato { get; set; }
        public int? DiaDoVencimentoParcelas { get; set; }
        public DateTime? DataDoVencimentoTotal { get; set; }
        public DateTime? DataDoVencimentoParcela { get; set; }
        public DateTime? DataPagamentoDaParcela { get; set; }
        public DateTime? ProximoVencimentoDaParcela { get; set; }
    }
}
