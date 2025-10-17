namespace Application.DTOs.ContasAReceber
{
    public class ContasAReceberRequest
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool IsPago { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int? QuantidadeParcelas { get; set; }
        public double Total { get; set; }
        public int ClienteId { get; set; }
        public double ValorEntrada { get; set; }
        public int? IdParceiro { get; set; }
        public int? IdFornecedor { get; set; }
        public int? IdContratoAdm { get; set; }
    }
}
