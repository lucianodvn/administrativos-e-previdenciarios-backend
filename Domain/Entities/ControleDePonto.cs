using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ControleDePonto
    {
        public int Id { get; set; }
        [ForeignKey("FuncionarioId")]
        public int FuncionarioId { get; set; }
        public int Dia { get; set; }
        public double? ValorDiaria { get; set; }
        public double? ValorQuinzenal { get; set; }
        public double? ValorMensal { get; set; }
        public DateTime? DiaDoPagamento { get; set; }
        public int? QuantidadeFaltasMes { get; set; }
        public double? ValorDescontado { get; set; }
        public double? TotalReceber { get; set; }
        public virtual Funcionario? Funcionario { get; set; }
        public string? Descricao { get; set; }
    }
}
