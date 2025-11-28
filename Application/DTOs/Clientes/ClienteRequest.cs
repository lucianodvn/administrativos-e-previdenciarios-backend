using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs.Clientes
{
    public class ClienteRequest
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Nacionalidade { get; set; }
        public string Profissao { get; set; }
        public string Endereco { get; set; }
        public string? Telefone { get; set; }
        public string Celular { get; set; }
        public string? Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string? NomeDaMae { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public int Idade { get; set; }
        public string? Rg { get; set; }
        public string Cpf { get; set; }
        public string? Email { get; set; }
        public string? Historico { get; set; }
        public bool IsProprioCliente { get; set; }
        public string? NomeCompletoRepresentateLegal { get; set; }
        public string? NacionalidadeRepresentateLegal { get; set; }
        public string? ProfissaoRepresentateLegal { get; set; }
        public string? EnderecoRepresentateLegal { get; set; }
        public string? TelefoneRepresentateLegal { get; set; }
        public string? CelularRepresentateLegal { get; set; }
        public string? ComplementoRepresentateLegal { get; set; }
        public string? CepRepresentateLegal { get; set; }
        public string? BairroRepresentateLegal { get; set; }
        public string? CidadeRepresentateLegal { get; set; }
        public string? EstadoRepresentateLegal { get; set; }
        public DateTime? DataDeNascimentoRepresentateLegal { get; set; }
        public int? IdadeRepresentateLegal { get; set; }
        public string? RgRepresentateLegal { get; set; }
        public string? CpfRepresentateLegal { get; set; }
        public string? EmailRepresentateLegal { get; set; }
        public string? outrosRepresentateLegal { get; set; }
        public string? TipoDeRepresentante { get; set; }
        public string EstadoCivil { get; set; }
        public string? EstadoCivilRepresentateLegal { get; set; }
        public string? SenhaInss { get; set; }
        public string? NumeroProcesso { get; set; }
        public int TipoBeneficioId { get; set; }
        public int EtapaServicoId { get; set; }
    }
}
