using Application.DTOs.ContasAPagar;
using Application.Interfaces.Logging;
using Application.Interfaces.Repository;
using AutoMapper;
using System.Runtime.CompilerServices;

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

        public async Task<List<ContasAPagarResponse>> ConsultarPorEmpresaId(int id)
        {
            try
            {
                var response = await _repository.ConsultarPorEmpresaId(id);
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

        public async Task<List<ContasAPagarResponse>> ConsultarPorEmpresaIdMesAnos(int id, int mes, int ano)
        {
            try
            {
                var response = await _repository.ConsultarPorEmpresaIdMesAno(id, mes, ano);
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

        public async Task<List<ContasAPagarResponse>> ListarContasDoAnoAnterior(int id)
        {
            try
            {
                var response = await _repository.ListarContasDoAnoAnterior(id);
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

        public async Task<double> ObterValoresAPagar(int idEmpresa, int mes)
        {
            try
            {
                var response = await _repository.ObterValoresAPagar(idEmpresa, mes);
                _logger.LogInfo($"Valor total a pagar: {response}");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter valores a pagar: {ex.Message}");
                throw new Exception("Erro interno ao obter valores a pagar.");
            }
        }

        public async Task<double> SomaTotalContasApgarAnoAnterior(int id)
        {
            try
            {
                var response = await _repository.SomaTotalContasApgarAnoAnterior(id);
                _logger.LogInfo($"Valor total a pagar do ano anterior: {response}");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter valores a pagar do ano anterior: {ex.Message}");
                throw new Exception("Erro interno ao obter valores a pagar do ano anterior.");
            }
        }

        public async Task<List<ContasAPagarResponse>> ConsultarContasAMigrar(int idEmpresa, int mes, int ano)
        {
            try
            {
                var response = await _repository.ConsultarContasAMigrar(idEmpresa, mes, ano);
                if (response == null || !response.Any())
                {
                    _logger.LogWarn("Nenhuma conta a pagar encontrada");
                    return null;
                }
                _logger.LogInfo($"Consulta Contas a Pagar: {response}");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar contas a pagaR: {ex.Message}");
                throw new Exception("Erro interno ao consultar contas a pagar.");
            }
        }
    }
}
