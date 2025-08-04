using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public async Task<Usuarios> ConsultarLogin(string nome, string senha)
        {
            Usuarios login = await _loginRepository.ConsultarLogin(nome, senha);
            return login;
        }
    }
}
