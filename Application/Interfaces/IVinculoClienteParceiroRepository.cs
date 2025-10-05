using Application.DTOs.VinculoClienteParceiro;

namespace Application.Interfaces
{
    public interface IVinculoClienteParceiroRepository
    {
        Task<List<VinculoClienteParceiroResponse>> ConsultarTodosAsync();
        Task<VinculoClienteParceiroResponse> ConsultarPorId(int id);
    }
}
