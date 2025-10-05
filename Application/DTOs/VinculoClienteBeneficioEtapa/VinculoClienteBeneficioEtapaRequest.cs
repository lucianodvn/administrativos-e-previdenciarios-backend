using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.VinculoClienteBeneficioEtapa
{
    public class VinculoClienteBeneficioEtapaRequest
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int EtapaServicoId { get; set; }
        public int BeneficiosServicosId { get; set; }
        public string? SenhaGov { get; set; }
        public string? NumeroDoProcesso { get; set; }
        public string? Outros { get; set; }
        public string? Historico { get; set; }
    }
}
