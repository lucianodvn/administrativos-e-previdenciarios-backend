using Application.DTOs.Contrato;

namespace Application.Interfaces.Repository
{
    public interface IContratoRepository
    {
        Task<List<ContratoResponse>> ConsultarTodosAsync();
        Task<ContratoResponse> ConsultarPorId(int id);
    }
}
