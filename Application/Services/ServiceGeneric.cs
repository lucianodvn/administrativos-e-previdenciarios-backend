using Application.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServiceGeneric<T> : IServiceGeneric<T> where T : class
    {
        private readonly IRepositoryGeneric<T> _repository;

        public ServiceGeneric(IRepositoryGeneric<T> repository)
        {
            _repository = repository;
        }
       public async Task Alterar(T entity)
        {
            _repository.Alterar(entity);
            await Task.CompletedTask;
        }

        public async Task<T> ConsultarPorId(object id)
        {
          return await _repository.ConsultarPorId(id);
        }

        public async Task<IEnumerable<T>> ConsultarTodos()
        {
            return await _repository.ConsultarTodos();
        }

        public async Task Excluir(T entity)
        {
            _repository.Excluir(entity);
            await Task.CompletedTask;
        }

        public async Task<T> Salvar(T entity)
        {
           return await _repository.Salvar(entity);
        }

        public async Task<bool> Existe(string numeroRecibo)
        {
            var existe = await _repository.Existe(numeroRecibo);
            if (existe)
            {
                throw new Exception("Número de recibo já existe.");
            }
            return existe;
        }
    }
}
