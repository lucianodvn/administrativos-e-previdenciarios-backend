using Application.DTOs.Clientes;
using Application.DTOs.ContasAPagar;
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
    public class ClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly ILoggerManager _logger;

        public ClienteService(IMapper mapper, IClienteRepository repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<ClienteResponse>> ConsultarTodos()
        {
            try
            {
                var response = await _repository.ConsultarTodosAsync();
                if (response == null)
                {
                    _logger.LogWarn("Cliente não encontrado");
                    return null;
                }
                _logger.LogInfo("Lista de Clientes");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar Clientes: {ex.Message}");
                throw new Exception("Erro interno ao consultar Clientes.");
            }
        }

        public async Task<ClienteResponse> ConsultarPorId(int id)
        {
            try
            {
                var response = await _repository.ConsultarPorId(id);
                if (response == null)
                {
                    _logger.LogWarn("Cliente não encontrado");
                    return null;
                }

                _logger.LogInfo($"Cliente: {response}");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar Cliente: {ex.Message}");
                throw new Exception("Erro interno ao consultar Cliente.");
            }
        }
    }
}

