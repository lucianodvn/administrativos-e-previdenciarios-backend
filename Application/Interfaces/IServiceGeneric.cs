using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IServiceGeneric<T> where T : class
    {
        Task<T> ConsultarPorId(object id);
        Task<IEnumerable<T>> ConsultarTodos();
        Task<T> Salvar(T entity);
        Task Alterar(T entity);
        Task Excluir(T entity);
    }
}
