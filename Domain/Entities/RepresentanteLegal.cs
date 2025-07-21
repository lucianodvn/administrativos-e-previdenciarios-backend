using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RepresentanteLegal
    {
        public int Id { get; set; }
        public string NomeCompletoRepresentateLegal { get; set; }
        public string NacionalidadeRepresentateLegal { get; set; }
        public string ProfissaoRepresentateLegal { get; set; }
        public string EnderecoRepresentateLegal { get; set; }
        public string TelefoneRepresentateLegal { get; set; }
        public string CelularRepresentateLegal { get; set; }
        public string ComplementoRepresentateLegal { get; set; }
        public string CepRepresentateLegal { get; set; }
        public string BairroRepresentateLegal { get; set; }
        public string CidadeRepresentateLegal { get; set; }
        public string EstadoRepresentateLegal { get; set; }
        public DateTime DataDeNascimentoRepresentateLegal { get; set; }
        public int IdadeRepresentateLegal { get; set; }
        public string RgRepresentateLegal { get; set; }
        public string CpfRepresentateLegal { get; set; }
        public string EmailRepresentateLegal { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string TipoDeRepresentante { get; set; }
        public string OutrosRepresentateLegal { get; set; }
    }
}
