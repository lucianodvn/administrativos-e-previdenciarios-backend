using Application.DTOs.Clientes;
using Application.DTOs.Parceiro;

namespace Application.DTOs.VinculoClienteParceiro
{
    public class VinculoClienteParceiroResponse
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public virtual ClienteResponse? Cliente { get; set; }
        public int ParceiroId { get; set; }
        public virtual ParceiroResponse? Parceiro { get; set; }
        public string? senhaGov { get; set; }
        public string? numeroDoProcesso { get; set; }
    }
}
