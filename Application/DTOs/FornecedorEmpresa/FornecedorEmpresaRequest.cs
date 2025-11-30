using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.FornecedorEmpresa
{
    public class FornecedorEmpresaRequest
    {
        public int Id { get; set; }
        public string NomeFornecedorEmpresa { get; set; }
        public string? CnpjCpf { get; set; }
        public string? Descricao { get; set; }
        public int? DiaVencimento { get; set; }
        public string FormaPagamento { get; set; }
        public string? Banco { get; set; }
        public string? TipoDeConta { get; set; }
        public string? Agencia { get; set; }
        public string? Conta { get; set; }
        public string? ChavePix { get; set; }
    }
}
