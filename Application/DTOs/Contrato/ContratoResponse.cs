using Application.DTOs.Clientes;

namespace Application.DTOs.Contrato
{
    public class ContratoResponse
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string? HtmlContrato { get; set; }
        public DateTime DataCriacao { get; set; }
        public string NomeCliente { get; set; }
        public ClienteResponse Cliente { get; set; }
        public double? ValorTotal { get; set; }
        public double? ValorEntrada { get; set; }
        public DateTime? DataDoPagamentoDaEntrada { get; set; }
        public DateTime? DataDoVencimentoValorEntrada { get; set; }
        public int? TotalDeParcelas { get; set; }
        public int? ParcelasPagas { get; set; }
        public int? ParcelasFaltantes { get; set; }
        public string StatusContrato { get; set; }
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
