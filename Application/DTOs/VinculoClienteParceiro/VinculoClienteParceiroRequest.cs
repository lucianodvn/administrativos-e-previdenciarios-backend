namespace Application.DTOs.VinculoClienteParceiro
{
    public class VinculoClienteParceiroRequest
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ParceiroId { get; set; }
        public string? senhaGov { get; set; }
        public string? numeroDoProcesso { get; set; }
        public double? Valor { get; set; }
    }
}
