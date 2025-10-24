using Application.DTOs.VinculoClienteParceiro;
using Application.Interfaces.Logging;
using Application.Interfaces.Repository;

namespace Application.Services
{
    public class VinculoClienteParceiroService
    {
        private readonly IVinculoClienteParceiroRepository _repository;
        private readonly ILoggerManager _logger;
        public VinculoClienteParceiroService(IVinculoClienteParceiroRepository repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<VinculoClienteParceiroResponse>> ConsultarTodos()
        {
            try
            {
                var response = await _repository.ConsultarTodosAsync();
                if (response == null)
                {
                    _logger.LogWarn("Vinculo Cliente Parceiro não encontrado.");
                    return null;
                }

                _logger.LogInfo("Consultar efetuado com sucesso. Vinculo Cliente Parceiro");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar Vinculo Cliente Parceiro: {ex.Message}");
                throw new Exception("Erro interno ao consultar Vinculo Cliente Parceiro.");
            }
        }

        public async Task<VinculoClienteParceiroResponse> ConsultarPorId(int id)
        {
            try
            {
                var response = await _repository.ConsultarPorId(id);
                if (response == null)
                {
                    _logger.LogWarn("Vinculo Cliente Parceiro não encontrado.");
                    return null;
                }
                _logger.LogInfo("Consultar efetuado com sucesso. Vinculo Cliente Parceiro");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar Vinculo Cliente Parceiro: {ex.Message}");
                throw new Exception("Erro interno ao consultar Vinculo Cliente Parceiro.");
            }
        }
    }
}
