using Application.DTOs.ContasAReceber;

namespace Application.Interfaces.Repository
{
    public interface IContasAReceberRepository
    {
        Task<List<ContasAReceberResponse>> ConsultarTodosAsync();
        Task<ContasAReceberResponse> ConsultarId(int id);
        Task<List<ContasAReceberResponse>> ConsultarPoClienteId(int id);
        Task SalvarTodos(List<ContasAReceberRequest> request);
        Task<List<ContasAReceberResponse>> ConsultarPorTipoAsync(int tipo);

    }
}
