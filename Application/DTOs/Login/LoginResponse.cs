using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Login
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public bool isAdmin { get; set; }
    }
}
