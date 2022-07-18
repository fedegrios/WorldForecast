using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Dominio.Entities;
using Infrastructure;

namespace Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly DataContext _context;
        private Expression<Func<T, object>> incluir;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate = null, string include ="")
        {
            var contextSet = _context.Set<T>()
                //.AsNoTracking()
                .Where(e => !e.Deleted);

            if (!string.IsNullOrEmpty(include))
                contextSet.Include(include);

            if(predicate != null)
                contextSet.Where(predicate);

            return await _context.Set<T>().ToListAsync();
        }


        public async Task<T> GetByIdAsync(int id, string include = "")
        {

            var contextSet = _context.Set<T>().AsQueryable<T>();
            
            if (string.IsNullOrEmpty(include))
                return await contextSet.FirstOrDefaultAsync(e => e.Id == id);

            //var includeParams = include.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //foreach (var p in includeParams)
                contextSet.Include(include);

            return await contextSet.FirstOrDefaultAsync(e => e.Id == id);
            
        }

        public async Task InsertAsync(T entity)
            => await _context.Set<T>().AddAsync(entity);
        
        public async Task UpdateAsync(T entity)
            => _context.Set<T>().Update(entity);

        public async Task HardDeleteAsync(int id)
        {
            T entity = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

            if (entity == null)
                return;

            _context.Set<T>().Remove(entity);
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

            if (entity == null)
                return;

            entity.Deleted = true;
            _context.Set<T>().Update(entity);
        }

    }
}
