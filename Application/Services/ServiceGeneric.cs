using Application.Interfaces.Logging;
using Application.Interfaces.Service;
using Domain.Entities;
using Domain.Interfaces.Repository;

namespace Application.Services
{
    public class ServiceGeneric<T> : IServiceGeneric<T> where T : class
    {
        private readonly IRepositoryGeneric<T> _repository;
        private readonly ILoggerManager _logger;

        public ServiceGeneric(IRepositoryGeneric<T> repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task Alterar(T entity)
        {
            try
            {
                await _repository.Alterar(entity);
                await Task.CompletedTask;

                _logger.LogInfo($"{entity} Aterado com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao alterar: {ex.Message}");
                throw new Exception($"Erro interno ao alterar.");
            }

        }

        public async Task<T> ConsultarPorId(object id)
        {
            try
            {
                return await _repository.ConsultarPorId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar {id}: {ex.Message}");
                throw new Exception($"Erro interno ao consultar.");
            }
        }

        public async Task<IEnumerable<T>> ConsultarTodos()
        {
            try
            {
                return await _repository.ConsultarTodos();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar: {ex.Message}");
                throw new Exception($"Erro interno ao consultar.");
            }
        }

        public async Task Excluir(T entity)
        {
            try
            {
                await _repository.Excluir(entity);
                await Task.CompletedTask;
                _logger.LogInfo($"{entity} Excluído com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao excluir{entity}: {ex.Message}");
                throw new Exception($"Erro interno ao consultar.");
            }
        }

        public async Task<T> Salvar(T entity)
        {
            try
            {
                return await _repository.Salvar(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao salvar{entity}: {ex.Message}");
                throw new Exception($"Erro interno ao salvar.");
            }
        }

        public async Task<bool> Existe(string numeroRecibo)
        {
            try
            {
                var existe = await _repository.Existe(numeroRecibo);
                if (existe)
                {
                    _logger.LogWarn($"Número de recibo já existe: {numeroRecibo}");
                    throw new Exception("Número de recibo já existe.");
                }
                _logger.LogInfo($"{existe} Recibo.");
                return existe;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: {ex.Message}");
                throw new Exception($"Erro interno.");
            }

        }

        public async Task AlterarSomenteNecessario<T>(T entity, object id)
        {
            await _repository.AlterarSomenteNecessario(entity, id);

            await Task.CompletedTask;
        }

        public async Task<Agendamento> ConsultarPorNome(string nome)
        {
            try
            {
                return await _repository.ConsultarPorNome(nome);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar {nome}: {ex.Message}");
                throw new Exception($"Erro interno ao consultar.");
            }
        }
    }
}
