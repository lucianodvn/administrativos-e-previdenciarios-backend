using Application.DTOs.Contrato;
using Application.Interfaces.Logging;
using Application.Interfaces.Repository;

namespace Application.Services
{
    public class ContratoJudicialService
    {
        private readonly IContratoJudicialRepository _repository;
        private readonly ILoggerManager _logger;

        public ContratoJudicialService(IContratoJudicialRepository repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<ContratoJudicialResponse>> ConsultarTodos()
        {
            try
            {
                var response = await _repository.ConsultarTodosAsync();
                if (response == null)
                {
                    _logger.LogWarn("Contrato Judicial não encontrado");
                    return null;
                }

                _logger.LogInfo($"Lista de Contrato Judicial: {response}");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar Contrato Judicial: {ex.Message}");
                throw new Exception("Erro interno ao consultar Contrato Judicial");
            }

        }

        public async Task<ContratoJudicialResponse> ConsultarPorId(int id)
        {
            try
            {
                var response = await _repository.ConsultarPorId(id);
                if (response == null)
                {
                    _logger.LogWarn("Contrato Judicial não encontrado");
                    return null;
                }

                _logger.LogInfo($"ConsultarPorId: {response}");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar Contrato Judicial: {ex.Message}");
                throw new Exception("Erro interno ao consultar Contrato Judicial");
            }

        }
    }
}
