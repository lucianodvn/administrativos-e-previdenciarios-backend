using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Usuarios
{
    public class UsuarioRequest
    {
        public string NomeDoUsuario { get; set; }
        public string Usuario { get; set; }
        public string SenhaDoUsuario { get; set; }
        public bool IsAdmin { get; set; }
    }
}
