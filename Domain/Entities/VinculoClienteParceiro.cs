using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class VinculoClienteParceiro
    {
        public int Id { get; set; }
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }
        [ForeignKey("ParceiroId")]
        public int ParceiroId { get; set; }
        public virtual Parceiro? Parceiro { get; set; }
        public string? senhaGov { get; set; }
        public string? numeroDoProcesso { get; set; }
        public double? Valor { get; set; }
    }
}
