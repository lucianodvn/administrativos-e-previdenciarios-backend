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

                _logger.LogInfo("Lista de Receber");
                return response;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar contas a receber: {ex.Message}");
                throw new Exception("Erro interno ao consultar contas a receber.");
            }
        }

        public async Task<ContasAReceberResponse> ConsultarPorId(int id)
        {
            try
            {
                var response = await _repository.ConsultarId(id);
                if (response == null)
                {
                    _logger.LogWarn("Conta a Receber não encontrado");
                    return null;
                }

                _logger.LogInfo($"Response da conta Receber: {response}");
                return response;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar conta a receber: {ex.Message}");
                throw new Exception("Erro interno ao consultar conta a receber.");
            }

        }

        public async Task<List<ContasAReceberResponse>> ConsultarPorIdCliente(int id)
        {
            try
            {
                var response = await _repository.ConsultarPoClienteId(id);
                if (response == null)
                {
                    _logger.LogWarn("Contas a Receber não encontrado para esse cliente.");
                    return null;
                }

                _logger.LogInfo($"Lista de Receber para esse cliente: {response}");
                return response;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar contas a receber para esse cliente: {ex.Message}");
                throw new Exception("Erro interno ao consultar contas a receber para esse cliente.");
            }
        }

        public async Task SalvarTodos(List<ContasAReceberRequest> request)
        {
            try
            {
                await _repository.SalvarTodos(request);
                _logger.LogInfo("Contas a Receber salvas com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao salvar contas a receber: {ex.Message}");
                throw new Exception("Erro interno ao salvar contas a receber.");
            }
        }

        public async Task<List<ContasAReceberResponse>> ConsultarPorTipoAsync(int tipo)
        {
            try
            {
                var response = await _repository.ConsultarPorTipoAsync(tipo);
                if (response == null)
                {
                    _logger.LogWarn("Contas a Receber não encontrado para esse tipo.");
                    return null;
                }
                _logger.LogInfo($"Lista de Receber para esse tipo: {response}");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar contas a receber para esse tipo: {ex.Message}");
                throw new Exception("Erro interno ao consultar contas a receber para esse tipo.");
            }
        }
    }
}
