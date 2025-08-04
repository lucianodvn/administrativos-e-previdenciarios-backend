using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Login
{
    public class LoginRequest
    {
        public string Usuario { get; set; }
        public string SenhaDoUsuario { get; set; }
    }
}
