namespace Application.DTOs.Contrato
{
    public class ContratoJudicialRequest
    {
        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public int? IdParceiro { get; set; }
        public double? Valor { get; set; }
        public DateTime? DataPagamento { get; set; }
        public bool? Status { get; set; }
        public string? HtmlContrato { get; set; }
        public string TipoDeContrato { get; set; }
    }
}
