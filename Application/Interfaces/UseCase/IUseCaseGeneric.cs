namespace Application.Interfaces.UseCase
{
    public interface IUseCaseGeneric<TRequest, TResponse>
    {
        Task<TResponse> ConsultarPorId(int id);
        Task<IEnumerable<TResponse>> ConsultarTodos();
        Task<TResponse> Salvar(TRequest request);
        Task Alterar(int id, TRequest request);
        Task<bool> Excluir(int id);
        Task<bool> Existe(string numeroRecibo);
        Task AlterarSomenteNecessario<T>(T entity, object id);
    }
}
