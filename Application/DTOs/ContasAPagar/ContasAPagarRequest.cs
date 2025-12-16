namespace Application.DTOs.ContasAPagar
{
    public class ContasAPagarRequest
    {
        public int Id { get; set; }
        public double? Valor { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int? IdFornecedorEmpresa { get; set; }
        public int? IdFornecedor { get; set; }
        public bool? IsPago { get; set; }
    }
}
