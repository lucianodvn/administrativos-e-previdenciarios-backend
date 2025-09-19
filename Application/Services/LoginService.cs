using Application.DTOs.Login;
using Application.DTOs.Usuarios;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LoginService
    {
        //private readonly ILoginRepository _loginRepository;
        private IMapper _mapper;
        private UserManager<Usuarios> _userManager;
        private SignInManager<Usuarios> _signInManager;
        private TokenService _tokenService;
        public LoginService(IMapper mapper, UserManager<Usuarios> userManager, SignInManager<Usuarios> signInManager, TokenService tokenService)
        {
         
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        //public async Task<Usuarios> ConsultarLogin(string nome, string senha)
        //{
        //    Usuarios login = await _loginRepository.ConsultarLogin(nome, senha);
        //    return login;
        //}

        public async Task CadastraUsuario(UsuarioRequest dto)
        {
            Usuarios usuario = _mapper.Map<Usuarios>(dto);
            usuario.Id = Guid.NewGuid().ToString();
            usuario.UserName = dto.NomeDoUsuario;

            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.SenhaDoUsuario);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar usuário!");
            }
        }

        public async Task<LoginResponse> Login(LoginRequest dto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Usuário não autenticado!");
            }

            var usuario = _signInManager
                .UserManager
                .Users
                .FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

            var token = _tokenService.GenerateToken(usuario);

            LoginResponse loginResponse = new LoginResponse
            {
                isAdmin = usuario.IsAdmin,
                Token = token
            };

            return loginResponse;

        }

        public async Task<bool> UsuarioIsAdmin(LoginRequest dto)
        {
            var resultado = await _userManager.FindByNameAsync(dto.Username);

            if (resultado == null)
            {
                throw new ApplicationException("Usuário não autenticado!");
            }

            return resultado.IsAdmin;

        }
    }
}
