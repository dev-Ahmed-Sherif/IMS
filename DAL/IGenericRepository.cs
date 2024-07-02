using Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        void Add(T model);
        void AddRange(IEnumerable<T> modelsList);
        void SoftDelete(T model);
        IQueryable<T> GetAll(Expression<Func<T, bool>>? predicate = null);
        Task<T?> GetById(int id);
    }
}