using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Recibo
{
    public class ReciboRequest
    {
        public int Id { get; set; }
        public string NumeroRecibo { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Recebedor { get; set; }
        public double Valor { get; set; }
        public string? Observacoes { get; set; }
        public bool IsPagoConfirmado { get; set; }
        public int ClienteId { get; set; }
    }
}
