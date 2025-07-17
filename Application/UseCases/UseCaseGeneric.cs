using Application.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var entdade = _mapper.Map<TEntity>(request);
            await _serviceGeneric.Alterar(entdade);
        }

        public async Task<TResponse> ConsultarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TResponse>> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TResponse> Salvar(TRequest request)
        {
            var entity = _mapper.Map<TEntity>(request);
            var savedEntity = await _serviceGeneric.Salvar(entity);
            return _mapper.Map<TResponse>(savedEntity);
        }
    }
}
