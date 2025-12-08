namespace Application.DTOs.ContasAReceber
{
    public class ContasAReceberResponse
    {
        public int Id { get; set; }
        public string? TipoClienteOuParceiro { get; set; }
        public string? Nome { get; set; }
        public string? TipoDeContrato { get; set; }
        public double? ValorTotal { get; set; }
        public double? ValorEntrada { get; set; }
        public double? ValorParcela { get; set; }
        public DateTime? DataDeVencimentoTotal { get; set; }
        public DateTime? DataDeVencimentoDaParcela { get; set; }
        public DateTime? DataDoVencimentoValorEntrada { get; set; }
    }
}
