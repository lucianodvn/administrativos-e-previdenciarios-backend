using Application.Interfaces.Service;
using Application.Interfaces.UseCase;
using AutoMapper;

namespace Application.UseCases
{
    public class UseCaseGeneric<TEntity, TRequest, TResponse> : IUseCaseGeneric<TRequest, TResponse>
    where TEntity : class, new()
    {

        private readonly IServiceGeneric<TEntity> _serviceGeneric;
        private readonly IMapper _mapper;

        public UseCaseGeneric(IServiceGeneric<TEntity> serviceGeneric, IMapper mapper)
        {
            _serviceGeneric = serviceGeneric;
            _mapper = mapper;
        }
        public async Task Alterar(int id, TRequest request)
        {
            var entidade = _mapper.Map<TEntity>(request);
            await _serviceGeneric.Alterar(entidade);
        }

        public async Task<TResponse> ConsultarPorId(int id)
        {
            var entidade = await _serviceGeneric.ConsultarPorId(id);
            if (entidade == null)
            {
                return default;
            }
            return _mapper.Map<TResponse>(entidade);
        }

        public async Task<IEnumerable<TResponse>> ConsultarTodos()
        {
            var entidades = await _serviceGeneric.ConsultarTodos();
            var resultado = _mapper.Map<IEnumerable<TResponse>>(entidades);
            return resultado;
        }

        public async Task<bool> Excluir(int id)
        {
            var entity = await _serviceGeneric.ConsultarPorId(id);
            if (entity == null)
            {
                return false;
            }
            await _serviceGeneric.Excluir(entity);
            return true;
        }

        public async Task<TResponse> Salvar(TRequest request)
        {
            var entity = _mapper.Map<TEntity>(request);
            var savedEntity = await _serviceGeneric.Salvar(entity);
            return _mapper.Map<TResponse>(savedEntity);
        }

        public async Task<bool> Existe(string numeroRecibo)
        {
            return await _serviceGeneric.Existe(numeroRecibo);
        }

        public async Task AlterarSomenteNecessario<T>(T request, object id)
        {
            var entidade = _mapper.Map<TEntity>(request);
            await _serviceGeneric.AlterarSomenteNecessario(entidade, id);
        }
    }
}
