using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ContasAReceber
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool IsPago { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int QuantidadeParcelas { get; set; }
        public double Total { get; set; }

        [ForeignKey("ClienteId")]
        public int? ClienteId { get; set; }

        public virtual Cliente? Cliente { get; set; }
        public double? ValorEntrada { get; set; }

        [ForeignKey("IdParceiro")]
        public int? IdParceiro { get; set; }
        public virtual Parceiro? Parceiro { get; set; }

        [ForeignKey("IdFornecedor")]
        public int? IdFornecedor { get; set; }
        public virtual Fornecedor? Fornecedor { get; set; }
        [ForeignKey("IdContratoAdm")]
        public int? IdContratoAdm { get; set; }
        public virtual Contrato? Contrato { get; set; }

        [ForeignKey("IdContratoJud")]
        public int? IdContratoJud { get; set; }
        public virtual ContratoJudicial? ContratoJudicial { get; set; }
    }
}
