using Application.DTOs.ContasAReceber;
using Application.Interfaces.Repository;
using AutoMapper;

namespace Application.Services
{
    public class ContasAReceberService
    {
        private readonly IContasAReceberRepository _repository;

        public ContasAReceberService(IMapper mapper, IContasAReceberRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ContasAReceberResponse>> ConsultarTodos()
        {
            var response = await _repository.ConsultarTodosAsync();
            if (response == null)
            {
                return null;
            }
            return response.OrderBy(x => x.DataVencimento).ToList();
        }

        public async Task<ContasAReceberResponse> ConsultarPorId(int id)
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
