using Application.DTOs.Fornecedor;
using Application.DTOs.Parceiro;

namespace Application.DTOs.ContasAPagar
{
    public class ContasAPagarResponse
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int? IdParceiro { get; set; }
        public ParceiroResponse? Parceiro { get; set; }
        public int? IdFornecedor { get; set; }
        public FornecedorResponse? Fornecedor { get; set; }
        public bool IsPago { get; set; }
        public string Item { get; set; }
    }
}
