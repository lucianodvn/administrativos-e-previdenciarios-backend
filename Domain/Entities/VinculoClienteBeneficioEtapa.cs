using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class VinculoClienteBeneficioEtapa
    {
        public int Id { get; set; }
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }

        [ForeignKey("EtapaServicoId")]
        public int EtapaServicoId { get; set; }
        public virtual EtapaServico? EtapaServico { get; set; }

        [ForeignKey("BeneficiosServicosId")]
        public int BeneficiosServicosId { get; set; }
        public virtual BeneficiosServicos? BeneficiosServicos { get; set; }
        public string? SenhaGov { get; set; }
        public string? NumeroDoProcesso { get; set; }
        public string? Outros { get; set; }
        public string? Historico { get; set; }
    }
}
