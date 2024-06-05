using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public EntityEntry<T> Add(T model)
        {
            model.Id = default;
            return _dbSet.Add(model);
        }
        public void SoftDelete(T model)
        {
            model.IsDeleted = true;
        }
        public void SoftDeleteRange(IEnumerable<T> modelsList)
        {
            foreach (T model in modelsList)
            {
                model.IsDeleted = true;
            }
        }
        public void Delete(T model)
        {
            _dbSet.Remove(model);
        }
        public void DeleteRange(IEnumerable<T> modelsList)
        {
            _dbSet.RemoveRange(modelsList);
        }
        public EntityEntry<T> Update(T model)
        {
            return _dbSet.Update(model);
        }
        public void AddRange(IEnumerable<T> modelsList)
        {
            _dbSet.AddRange(modelsList);
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate = null)
        {
            IQueryable<T> result =
                _dbSet
                .OrderByDescending(e => e.CreationDate);

            if (predicate == null) return result;
            return result.Where(predicate);
        }
        public async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<T?> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }
        public async Task<int> Count(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate == null) return await _dbSet.CountAsync();
            return await _dbSet.CountAsync(predicate);
        }

    }
}
