using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [NotMapped]
    public class Agenda
    {
        public int IdCliente { get; set; }
        public int IdContaAReceber { get; set; }
        public string NomeDoCliente { get; set; }
        public DateTime DataDoAgendamento { get; set; }
        public DateTime DataDoVencimento { get; set; }
        public double ValorAReceber { get; set; }
        public int NumeroDaParcela { get; set; }
    }
}
