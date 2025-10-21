using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ContratoJudicial
    {
        public int Id { get; set; }
        [ForeignKey("IdCliente")]
        public int? IdCliente { get; set; }
        public virtual Cliente? Cliente { get; set; }
        [ForeignKey("IdParceiro")]
        public int? IdParceiro { get; set; }
        public virtual Parceiro? Parceiro { get; set; }
        public double? Valor { get; set; }
        public DateTime? DataPagamento { get; set; }
        public bool? Status { get; set; }
        public string? HtmlContrato { get; set; }
        public TipoDeContratoEnum TipoDeContrato { get; set; }
    }
}
