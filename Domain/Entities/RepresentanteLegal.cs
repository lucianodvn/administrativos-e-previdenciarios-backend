using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RepresentanteLegal
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Nacionalidade { get; set; }
        public string Profissao { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public int Idade { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string TipoDeRepresentante { get; set; }
    }
}
