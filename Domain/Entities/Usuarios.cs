using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string NomeDoUsuario { get; set; }
        public string Usuario { get; set; }
        public string SenhaDoUsuario { get; set; }
        public bool IsAdmin { get; set; }
    }
}
