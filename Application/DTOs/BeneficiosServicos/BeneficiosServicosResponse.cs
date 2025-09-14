using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.BeneficiosServicos
{
    public class BeneficiosServicosResponse
    {
        public int Id { get; set; }
        public string NomeBeneficioServico { get; set; }
    }
}
