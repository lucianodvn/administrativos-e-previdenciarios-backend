using Application.DTOs.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioResponse>> ConsultarTodosAsync();
        Task<UsuarioResponse> ConsultarPorIdAsync(Guid id);
        Task<UsuarioResponse> AlterarAsync(UsuarioRequest usuarioRequest);
        Task ExcluirAsync(Guid id);
    }
}
