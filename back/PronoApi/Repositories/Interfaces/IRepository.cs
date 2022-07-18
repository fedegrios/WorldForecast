using System.Linq.Expressions;
using Dominio.Entities;

namespace Repositories.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(int id, string include ="");
        
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate =null, string include = "");

        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task HardDeleteAsync(int id);
    }
}
