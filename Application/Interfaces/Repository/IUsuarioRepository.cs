using Application.DTOs.Usuarios;

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
