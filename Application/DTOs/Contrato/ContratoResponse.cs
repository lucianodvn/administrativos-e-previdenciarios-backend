using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Contrato
{
    public class ContratoResponse
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string HtmlContrato { get; set; }
        public DateTime DataCriacao { get; set; }
        public string NomeCliente { get; set; }
    }

}
