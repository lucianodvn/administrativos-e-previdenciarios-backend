using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AgendaResponse
    {
        public string NomeDoCliente { get; set; }
        public DateTime DataDoAgendamento { get; set; }
        public DateTime DataDoVencimento { get; set; }
        public double ValorAReceber { get; set; }
        public int NumeroDaParcela { get; set; }
    }
}
