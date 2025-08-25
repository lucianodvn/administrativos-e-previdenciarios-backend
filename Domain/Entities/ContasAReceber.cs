using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ContasAReceber
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool IsPago { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int QuantidadeParcelas { get; set; }
        public double Total { get; set; }
        public int ClienteId { get; set; }
    }
}
