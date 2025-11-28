using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AdendoContrato
{
    public class AdendoContratoRequest
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
        public int ClienteId { get; set; }
        public int TipoBeneficioId { get; set; }
    }
}
