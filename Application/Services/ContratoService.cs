using Application.DTOs.Contrato;
using Application.Interfaces.Repository;

namespace Application.Services
{
    public class ContratoService
    {
        private readonly IContratoRepository _repository;

        public ContratoService(IContratoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ContratoResponse>> ConsultarTodos()
        {
            var response = await _repository.ConsultarTodosAsync();
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public async Task<ContratoResponse> ConsultarPorId(int id)
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
