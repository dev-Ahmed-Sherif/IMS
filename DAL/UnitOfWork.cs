using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork
    {
        //Nazem ⬇
        //Unify the scope of repositories
        //Repositories should be added here
        private readonly AppDbContext _dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<int> SaveChangesAsync()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreationDate = DateTime.UtcNow;
                        //entry.Entity.CreatedByUserId = userId ?? Guid.Empty;
                        //entry.Entity.ConcurrencyToken = Guid.NewGuid();
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastUpdateDate = DateTime.UtcNow;
                        //entry.Entity.UpdatedByUserId = userId ?? Guid.Empty;
                        //entry.Entity.ConcurrencyToken = Guid.NewGuid();
                        break;
                }

            }
            return _dbContext.SaveChangesAsync();
        }
    }
}
