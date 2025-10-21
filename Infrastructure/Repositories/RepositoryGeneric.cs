using Domain.Interfaces.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
    {
        protected readonly DataDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryGeneric(DataDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        async Task IRepositoryGeneric<T>.Alterar(T entity)
        {
            _dbSet.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AlterarSomenteNecessario<T>(T entity, object id)
        {
            var original = await _dbSet.FindAsync(id);

            if (original != null)
            {
                var entry = _context.Entry(original);
                entry.CurrentValues.SetValues(entity);

                // Obtém propriedades mapeadas pelo EF
                var mappedProperties = entry.Properties.Select(p => p.Metadata.Name).ToHashSet();

                // Ignora propriedades nulas que estão mapeadas
                foreach (var prop in typeof(T).GetProperties())
                {
                    var value = prop.GetValue(entity);
                    if (value == null && mappedProperties.Contains(prop.Name))
                    {
                        entry.Property(prop.Name).IsModified = false;
                    }
                }

                await _context.SaveChangesAsync();
            }
        }

        async Task<T> IRepositoryGeneric<T>.ConsultarPorId(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        async Task<IEnumerable<T>> IRepositoryGeneric<T>.ConsultarTodos()
        {
            return await _dbSet.ToListAsync();
        }

        async Task IRepositoryGeneric<T>.Excluir(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        Task<IEnumerable<T>> IRepositoryGeneric<T>.Pesquisar(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        async Task<T> IRepositoryGeneric<T>.Salvar(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        async Task<bool> IRepositoryGeneric<T>.Existe(string numeroRecibo)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, "NumeroRecibo");
            var constant = Expression.Constant(numeroRecibo);
            var equality = Expression.Equal(property, constant);
            var lambda = Expression.Lambda<Func<T, bool>>(equality, parameter);
            return await _dbSet.AnyAsync(lambda);
        }
    }
}
