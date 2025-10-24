using Application.DTOs.ContasAPagar;
using Application.Interfaces.Logging;
using Application.Interfaces.Repository;
using AutoMapper;

namespace Application.Services
{
    public class ContasAPagarService
    {
        private readonly IContasAPagarRepository _repository;
        private readonly ILoggerManager _logger;

        public ContasAPagarService(IMapper mapper, IContasAPagarRepository repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<ContasAPagarResponse>> ConsultarTodos()
        {
            try
            {
                var response = await _repository.ConsultarTodosAsync();
                if (response == null)
                {
                    _logger.LogWarn("Contas a Pagar não encontrado");
                    return null;
                }
                _logger.LogInfo("Lista de Contas a Pagar");
                return response.OrderBy(x => x.DataVencimento).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar contas a pagar: {ex.Message}");
                throw new Exception("Erro interno ao consultar contas a pagar.");
            }
        }

        public async Task<ContasAPagarResponse> ConsultarPorId(int id)
        {
            try
            {
                var response = await _repository.ConsultarPorId(id);
                if (response == null)
                {
                    _logger.LogWarn("Contas a Pagar não encontrado");
                    return null;
                }

                _logger.LogInfo($"Consulta Contas a Pagar: {response}");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar contas a pagar: {ex.Message}");
                throw new Exception("Erro interno ao consultar contas a pagar.");
            }
        }
    }
}
