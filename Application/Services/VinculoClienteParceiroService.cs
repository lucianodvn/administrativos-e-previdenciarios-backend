using Application.DTOs.VinculoClienteParceiro;
using Application.Interfaces;

namespace Application.Services
{
    public class VinculoClienteParceiroService
    {
        private readonly IVinculoClienteParceiroRepository _repository;
        public VinculoClienteParceiroService(IVinculoClienteParceiroRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<VinculoClienteParceiroResponse>> ConsultarTodos()
        {
            var response = await _repository.ConsultarTodosAsync();
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public async Task<VinculoClienteParceiroResponse> ConsultarPorId(int id)
        {
            var response = await _repository.ConsultarPorId(id);
            if (response == null)
            {
                return null;
            }

            return response;
        }
    }
}
