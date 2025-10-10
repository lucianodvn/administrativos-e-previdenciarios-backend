using Application.DTOs.Usuarios;
using Application.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuarios> _userManager;
        private SignInManager<Usuarios> _signInManager;
        private TokenService _tokenService;
        private readonly IUsuarioRepository _usuarioRepository;


        public UsuarioService(IMapper mapper, UserManager<Usuarios> userManager, SignInManager<Usuarios> signInManager, TokenService tokenService, IUsuarioRepository usuarioRepository)
        {

            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _usuarioRepository = usuarioRepository;
        }

        public async Task CadastraUsuario(UsuarioRequest dto)
        {
            Usuarios usuario = _mapper.Map<Usuarios>(dto);
            usuario.UserName = dto.NomeDoUsuario;

            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.SenhaDoUsuario);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar usuário!");
            }
        }

        public async Task<List<UsuarioResponse>> ConsultaTodosUsuarios()
        {
            var usuarios = await _usuarioRepository.ConsultarTodosAsync();

            if (usuarios == null || !usuarios.Any())
                throw new ApplicationException("Nenhum usuário encontrado!");

            return usuarios;
        }

        public async Task<UsuarioResponse> ConsultarPorId(Guid id)
        {
            var usuario = await _usuarioRepository.ConsultarPorIdAsync(id);
            if (usuario == null)
                throw new ApplicationException("Usuário não encontrado!");
            return _mapper.Map<UsuarioResponse>(usuario);
        }

        public async Task<UsuarioResponse> AlterarUsuario(UsuarioRequest dto)
        {
            var usuario = await _usuarioRepository.AlterarAsync(dto);
            return usuario;
        }

        public async Task ExcluirUsuario(Guid id)
        {
            await _usuarioRepository.ExcluirAsync(id);
        }
    }
}
