using Application.DTOs.Clientes;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ContasAReceber
{
    public class ContasAReceberResponse
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool IsPago { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int QuantidadeParcelas { get; set; }
        public double Total { get; set; }
        public int ClienteId { get; set; }
        public double ValorEntrada { get; set; }
        public ClienteResponse? ClienteResponse { get; set; }
    }
}
