using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EtapaServico
{
    public class EtapaServicoRequest
    {
        public int id { get; set; }
        [Required]
        public string NomeEtapaServico { get; set; }
    }
}
