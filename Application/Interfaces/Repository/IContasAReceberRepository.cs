using Application.DTOs.ContasAReceber;

namespace Application.Interfaces.Repository
{
    public interface IContasAReceberRepository
    {
        Task<List<ContasAReceberResponse>> ConsultarTodosAsync();
        Task<ContasAReceberResponse> ConsultarPorId(int id);
    }
}
