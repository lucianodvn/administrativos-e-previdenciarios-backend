using Application.DTOs.ContasAPagar;

namespace Application.Interfaces.Repository
{
    public interface IContasAPagarRepository
    {
        Task<List<ContasAPagarResponse>> ConsultarTodosAsync();
        Task<ContasAPagarResponse> ConsultarPorId(int id);
        Task<List<ContasAPagarResponse>> ConsultarPorEmpresaId(int id);
    }
}
