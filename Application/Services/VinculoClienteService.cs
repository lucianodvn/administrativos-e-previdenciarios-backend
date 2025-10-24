using Application.DTOs.VinculoClienteBeneficioEtapa;
using Application.Interfaces.Logging;
using Application.Interfaces.Repository;
using AutoMapper;

namespace Application.Services
{
    public class VinculoClienteService
    {
        private readonly IVinculoClienteRepository _repository;
        private readonly ILoggerManager _logger;
        public VinculoClienteService(IMapper mapper, IVinculoClienteRepository repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<VinculoClienteBeneficioEtapaResponse>> ConsultarTodos()
        {
            try
            {
                var response = await _repository.ConsultarTodosAsync();
                if (response == null)
                {
                    _logger.LogWarn("Vinculo Cliente Beneficio Etapa não encontrado.");
                    return null;
                }

                _logger.LogInfo("Consultar efetuado com sucesso. Vinculo Cliente Beneficio Etapa.");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar Vinculo Cliente Parceiro: {ex.Message}");
                throw new Exception("Erro interno ao consultar Vinculo Cliente Parceiro.");
            }
        }

        public async Task<VinculoClienteBeneficioEtapaResponse> ConsultarPorId(int id)
        {
            try
            {
                var response = await _repository.ConsultarPorId(id);
                if (response == null)
                {
                    _logger.LogWarn("Vinculo Cliente Beneficio Etapa não encontrado.");
                    return null;
                }

                _logger.LogInfo("Consultar efetuado com sucesso. Vinculo Cliente Beneficio Etapa.");
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
