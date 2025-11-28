using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AdendoContrato
    {
        public int Id { get; set; }
        public int? DiaVencimentoUtil { get; set; }
        public DateTime? DataVencimento { get; set; }
        public int? DiaPagamentoUtil { get; set; }
        public DateTime? DataPagamento { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public int? InicioParcelas { get; set; }
        public int? FimParcelas { get; set; }
        public double? ValorParcelas { get; set; }
        public double? ValorEntrada { get; set; }
        public double? ValorPago { get; set; }
        public bool StatusPagamentoMensal { get; set; }
        public bool StatusPagamentoTotal { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        [ForeignKey("TipoBeneficioId")]
        public int TipoBeneficioId { get; set; }
        public virtual BeneficiosServicos Beneficio { get; set; }
    }
}
