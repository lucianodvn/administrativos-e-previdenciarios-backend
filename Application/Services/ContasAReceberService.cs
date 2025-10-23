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

            var resultado = response
            .Where(x =>
                (x.DataDeVencimentoTotal?.Month == DateTime.Now.Month &&
                 x.DataDeVencimentoTotal?.Year == DateTime.Now.Year) ||

                (x.DataDeVencimentoDaParcela?.Month == DateTime.Now.Month &&
                 x.DataDeVencimentoDaParcela?.Year == DateTime.Now.Year) ||

                (x.DataDeVencimentoTotal == null && x.DataDeVencimentoDaParcela == null)
            )
            .ToList();

            return resultado.OrderBy(x => x.DataDeVencimentoTotal ?? x.DataDeVencimentoDaParcela).ToList();
        }
    }
}
