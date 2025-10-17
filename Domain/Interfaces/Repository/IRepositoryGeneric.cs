using System.Linq.Expressions;

namespace Domain.Interfaces.Repository
{
    public interface IRepositoryGeneric<T> where T : class
    {
        Task<T> ConsultarPorId(object id);
        Task<IEnumerable<T>> ConsultarTodos();
        Task<IEnumerable<T>> Pesquisar(Expression<Func<T, bool>> predicate);
        Task<T> Salvar(T entity);
        Task Alterar(T entity);
        Task AlterarSomenteNecessario<T>(T entity, object id);
        Task Excluir(T entity);
        Task<bool> Existe(string numeroRecibo);
    }
}
