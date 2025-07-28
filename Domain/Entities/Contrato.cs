using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Contrato
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public string HtmlContrato { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
