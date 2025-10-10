namespace Application.DTOs.Agendamento
{
    public class AgendamentoRequest
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string? Telefone { get; set; }
        public string? Celular { get; set; }
        public string? Email { get; set; }
        public DateTime DataHoraDoAgendamento { get; set; }
        public bool IsAtendido { get; set; }
    }
}
