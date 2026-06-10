using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Funcionario
{
    public class FuncionarioRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Celular { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Funcao { get; set; }
        public TipoDeRecebimentoEnum TipoDeRecebimento { get; set; }
        public string? Pis { get; set; }
        public string? Ctps { get; set; }
        public string? Serie { get; set; }
        public string? SenhaInss { get; set; }
        public string Cep { get; set; }
        public string? Complemento { get; set; }
    }
}
