namespace Domain.Entities
{
    public class ContasAPagar
    {
        public int Id { get; set; }
        public string NomeDaConta { get; set; }
        public double Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}
