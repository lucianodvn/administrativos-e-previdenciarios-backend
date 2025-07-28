using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Contrato
{
    public class ContratoRequest
    {
        public int ClienteId { get; set; }
        public string HtmlContrato { get; set; }
    }
}
