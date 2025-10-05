using Application.DTOs.BeneficiosServicos;
using Application.DTOs.Clientes;
using Application.DTOs.EtapaServico;

namespace Application.DTOs.VinculoClienteBeneficioEtapa
{
    public class VinculoClienteBeneficioEtapaResponse
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public ClienteResponse? Cliente { get; set; }

        public int EtapaServicoId { get; set; }
        public EtapaServicoResponse? EtapaServico { get; set; }

        public int BeneficiosServicosId { get; set; }
        public BeneficiosServicosResponse? BeneficiosServicos { get; set; }

        public string? SenhaGov { get; set; }
        public string? NumeroDoProcesso { get; set; }
        public string? Outros { get; set; }
        public string? Historico { get; set; }
    }

}
