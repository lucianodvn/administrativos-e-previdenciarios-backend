using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTOs.Clientes
{
    public class ClienteRequest
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Nacionalidade { get; set; }
        public string Profissao { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string TipoDeBeneficio { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public int Idade { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
    }
}
