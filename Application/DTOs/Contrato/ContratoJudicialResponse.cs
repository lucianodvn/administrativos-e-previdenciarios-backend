using Application.DTOs.Clientes;
using Application.DTOs.Parceiro;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs.Contrato
{
    public class ContratoJudicialResponse
    {
        public int Id { get; set; }
        [ForeignKey("IdCliente")]
        public int? IdCliente { get; set; }
        public virtual ClienteResponse? Cliente { get; set; }
        [ForeignKey("IdParceiro")]
        public int? IdParceiro { get; set; }
        public virtual ParceiroResponse? Parceiro { get; set; }
        public double? Valor { get; set; }
        public DateTime? DataPagamento { get; set; }
        public bool? Status { get; set; }
        public string? HtmlContrato { get; set; }
        public string TipoDeContrato { get; set; }
    }
}
