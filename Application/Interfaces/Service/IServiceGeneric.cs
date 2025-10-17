namespace Application.Interfaces.Service
{
    public interface IServiceGeneric<T> where T : class
    {
        Task<T> ConsultarPorId(object id);
        Task<IEnumerable<T>> ConsultarTodos();
        Task<T> Salvar(T entity);
        Task Alterar(T entity);
        Task AlterarSomenteNecessario<T>(T entity, object id);
        Task Excluir(T entity);
        Task<bool> Existe(string numeroRecibo);
    }
}
