using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ContasAPagar
    {
        public int Id { get; set; }
        public double? Valor { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }

        [ForeignKey("IdFornecedorEmpresa")]
        public int? IdFornecedorEmpresa { get; set; }
        public virtual FornecedorEmpresa? FornecedorEmpresa { get; set; }

        [ForeignKey("IdFornecedor")]
        public int? IdFornecedor { get; set; }
        public virtual Fornecedor? Fornecedor { get; set; }
        public bool? IsPago { get; set; }
    }
}
