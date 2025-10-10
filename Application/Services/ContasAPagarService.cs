using Application.DTOs.ContasAPagar;
using Application.Interfaces.Repository;
using AutoMapper;

namespace Application.Services
{
    public class ContasAPagarService
    {
        private readonly IContasAPagarRepository _repository;

        public ContasAPagarService(IMapper mapper, IContasAPagarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ContasAPagarResponse>> ConsultarTodos()
        {
            var response = await _repository.ConsultarTodosAsync();
            if (response == null)
            {
                return null;
            }
            return response.OrderBy(x => x.DataVencimento).ToList();
        }

        public async Task<ContasAPagarResponse> ConsultarPorId(int id)
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
