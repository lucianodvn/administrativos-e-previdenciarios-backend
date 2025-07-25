using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepositoryGeneric<T> where T : class
    {
        Task<T> ConsultarPorId (object id);
        Task<IEnumerable<T>> ConsultarTodos();
        Task<IEnumerable<T>> Pesquisar(Expression<Func<T, bool>> predicate);
        Task<T> Salvar(T entity);
        Task Alterar(T entity);
        void Excluir(T entity);
    }
}
