using Application.DTOs.ContasAReceber;
using Application.Interfaces.Logging;
using Application.Interfaces.Repository;
using AutoMapper;

namespace Application.Services
{
    public class ContasAReceberService
    {
        private readonly IContasAReceberRepository _repository;
        private readonly ILoggerManager _logger;
        public ContasAReceberService(IMapper mapper, IContasAReceberRepository repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<ContasAReceberResponse>> ConsultarTodos()
        {
            try
            {
                var response = await _repository.ConsultarTodosAsync();
                if (response == null)
                {
                    _logger.LogWarn("Contas a Receber não encontrado");
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

                _logger.LogInfo("Lista de Receber a Pagar");
                return resultado.OrderBy(x => x.DataDeVencimentoTotal ?? x.DataDeVencimentoDaParcela).ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar contas a receber: {ex.Message}");
                throw new Exception("Erro interno ao consultar contas a receber.");
            }

        }
    }
}
