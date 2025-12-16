using Application.DTOs.ContasAPagar;
using Application.DTOs.FornecedorEmpresa;
using Application.Interfaces.Logging;
using Application.Interfaces.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FornecedorEmpresaService
    {
        private readonly IFornecedorEmpresaRepository _repository;
        private readonly ILoggerManager _logger;

        public FornecedorEmpresaService(IMapper mapper, IFornecedorEmpresaRepository repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<FornecedorEmpresaResponse>> ConsultarTodos()
        {
            try
            {
                var response = await _repository.ConsultarTodosAsync();
                if (response == null)
                {
                    _logger.LogWarn("Fornecedores não encontrado");
                    return null;
                }
                _logger.LogInfo("Lista de Fornecedores");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar Fornecedores: {ex.Message}");
                throw new Exception("Erro interno ao consultar Fornecedores.");
            }
        }

        public async Task<FornecedorEmpresaResponse> ConsultarPorId(int id)
        {
            try
            {
                var response = await _repository.ConsultarPorId(id);
                if (response == null)
                {
                    _logger.LogWarn("Fornecedor não encontrado");
                    return null;
                }

                _logger.LogInfo($"Consulta Contas a Pagar: {response}");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar Fornecedor: {ex.Message}");
                throw new Exception("Erro interno ao consultar Fornecedor.");
            }
        }

        public async Task<List<FornecedorEmpresaResponse>> ConsultarPorEmpresaId(int id)
        {
            try
            {
                var response = await _repository.ConsultarPorEmpresaId(id);
                if (response == null)
                {
                    _logger.LogWarn("Fornecedor não encontrado");
                    return null;
                }

                _logger.LogInfo($"Consulta Fornecedor: {response}");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar Forncedor: {ex.Message}");
                throw new Exception("Erro interno ao consultar Fornecedor.");
            }
        }
    }
}

