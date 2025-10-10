using Application.DTOs.Usuarios;
using Application.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UserManager<Usuarios> _userManager;
        private readonly IMapper _mapper;

        public UsuarioRepository(UserManager<Usuarios> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<List<UsuarioResponse>> ConsultarTodosAsync()
        {
            var usuarios = await _userManager.Users.ToListAsync();
            return _mapper.Map<List<UsuarioResponse>>(usuarios);
        }

        public async Task<UsuarioResponse> ConsultarPorIdAsync(Guid id)
        {
            var usuario = await _userManager.FindByIdAsync(id.ToString());
            if (usuario == null)
                return null;
            return _mapper.Map<UsuarioResponse>(usuario);
        }

        public async Task<UsuarioResponse> AlterarAsync(UsuarioRequest usuarioRequest)
        {
            Usuarios usuario = new Usuarios
            {
                Id = usuarioRequest.Id.ToString(),
                UserName = usuarioRequest.NomeDoUsuario,
                PasswordHash = usuarioRequest.SenhaDoUsuario,
                IsAdmin = usuarioRequest.IsAdmin
            };

            var response = await _userManager.FindByIdAsync(usuario.Id);
            if (response == null)
                throw new ApplicationException("Usuário não encontrado!");

            var resultado = await _userManager.ChangePasswordAsync(response, usuarioRequest.SenhaDoUsuario, usuarioRequest.ConfirmarSenha);
            if (!resultado.Succeeded)
                throw new ApplicationException("Falha ao atualizar usuário!");
            return _mapper.Map<UsuarioResponse>(usuario);
        }

        public async Task ExcluirAsync(Guid id)
        {
            var usuario = await _userManager.FindByIdAsync(id.ToString());
            if (usuario == null)
                throw new ApplicationException("Usuário não encontrado!");
            var resultado = await _userManager.DeleteAsync(usuario);
            if (!resultado.Succeeded)
                throw new ApplicationException("Falha ao excluir usuário!");
        }
    }
}
