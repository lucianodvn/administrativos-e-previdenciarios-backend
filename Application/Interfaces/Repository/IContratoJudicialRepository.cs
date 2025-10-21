using Application.DTOs.Contrato;

namespace Application.Interfaces.Repository
{
    public interface IContratoJudicialRepository
    {
        Task<List<ContratoJudicialResponse>> ConsultarTodosAsync();
        Task<ContratoJudicialResponse> ConsultarPorId(int id);
    }
}
