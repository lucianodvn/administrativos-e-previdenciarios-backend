using Application.DTOs.Contrato;
using Application.Interfaces.Logging;
using Application.Interfaces.Repository;

namespace Application.Services
{
    public class ContratoService
    {
        private readonly IContratoRepository _repository;
        private readonly ILoggerManager _logger;

        public ContratoService(IContratoRepository repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<ContratoResponse>> ConsultarTodos()
        {
            try
            {
                var response = await _repository.ConsultarTodosAsync();
                if (response == null)
                {
                    _logger.LogWarn("Contrato não encontrado");
                    return null;
                }

                _logger.LogInfo($"Lista de Contratos: {response}.");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar Contratos: {ex.Message}");
                throw new Exception("Erro interno ao consultar Contratos.");
            }
        }

        public async Task<ContratoResponse> ConsultarPorId(int id)
        {
            try
            {
                var response = await _repository.ConsultarPorId(id);
                if (response == null)
                {
                    _logger.LogWarn("Contrato não encontrado.");
                    return null;
                }

                _logger.LogInfo($"Contrato: {response}.");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar Contratos: {ex.Message}");
                throw new Exception("Erro interno ao consultar Contratos.");
            }

        }
    }
}
