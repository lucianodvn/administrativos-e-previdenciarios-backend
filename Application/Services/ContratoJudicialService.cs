using Application.DTOs.Contrato;
using Application.Interfaces.Repository;

namespace Application.Services
{
    public class ContratoJudicialService
    {
        private readonly IContratoJudicialRepository _repository;

        public ContratoJudicialService(IContratoJudicialRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ContratoJudicialResponse>> ConsultarTodos()
        {
            var response = await _repository.ConsultarTodosAsync();
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public async Task<ContratoJudicialResponse> ConsultarPorId(int id)
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
