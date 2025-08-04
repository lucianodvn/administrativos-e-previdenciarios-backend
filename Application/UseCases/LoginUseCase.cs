using Application.DTOs.Login;
using Application.DTOs.Usuarios;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;

        public LoginUseCase(ILoginService loginService, IMapper mapper)
        {
            _loginService = loginService;
            _mapper = mapper;
        }
        public async Task<UsuarioResponse> ConsultarLogin(LoginRequest loginRequest)
        {
            var entidade = await _loginService.ConsultarLogin(loginRequest.Usuario, loginRequest.SenhaDoUsuario);
            if (entidade == null)
            {
                return default;
            }
            return _mapper.Map<UsuarioResponse>(entidade);
        }
    }
}
