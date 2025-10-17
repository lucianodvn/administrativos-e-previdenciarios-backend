using Application.DTOs.Clientes;
using Application.DTOs.Contrato;
using Application.DTOs.Fornecedor;
using Application.DTOs.Parceiro;

namespace Application.DTOs.ContasAReceber
{
    public class ContasAReceberResponse
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool IsPago { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int QuantidadeParcelas { get; set; }
        public double Total { get; set; }
        public double ValorEntrada { get; set; }
        public int? ClienteId { get; set; }
        public ClienteResponse? Cliente { get; set; }
        public int? IdParceiro { get; set; }
        public ParceiroResponse? Parceiro { get; set; }
        public int? IdFornecedor { get; set; }
        public FornecedorResponse? Fornecedor { get; set; }
        public int? IdContratoAdm { get; set; }
        public virtual ContratoResponse? Contrato { get; set; }
    }
}
