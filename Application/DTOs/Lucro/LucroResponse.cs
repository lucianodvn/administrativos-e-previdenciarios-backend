using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Lucro
{
    public class LucroResponse
    {
        public double TotalPagar {  get; set; }
        public double TotalReceber { get; set; }
        public double TotalLucro { get; set; }
    }
}
