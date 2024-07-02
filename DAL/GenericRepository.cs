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
        public virtual void Add(T model)
        {
            model.Id = default;
            _dbSet.Add(model);
        }
        public virtual void SoftDelete(T model)
        {
            model.IsDeleted = true;
        }
        public virtual void SoftDeleteRange(IEnumerable<T> modelsList)
        {
            foreach (T model in modelsList)
            {
                model.IsDeleted = true;
            }
        }
        public virtual void Delete(T model)
        {
            _dbSet.Remove(model);
        }
        public virtual void DeleteRange(IEnumerable<T> modelsList)
        {
            _dbSet.RemoveRange(modelsList);
        }
        public virtual void Update(T model)
        {
            _dbSet.Update(model);
        }
        public virtual void AddRange(IEnumerable<T> modelsList)
        {
            _dbSet.AddRange(modelsList);
        }
        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> result =
                _dbSet
                .OrderByDescending(e => e.CreationDate);
            return result;
        }
        public virtual async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

    }
}
