using Entities;
using Entities.ViewModels;
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
        private readonly UserIdentity _user;
        public UnitOfWork(AppDbContext dbContext, UserIdentity user)
        {
            _dbContext = dbContext;
            _user = user;
        }
        public Task<int> SaveChangesAsync()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreationDate = DateTime.UtcNow;
                        entry.Entity.CreatedByID = _user.Id;
                        //entry.Entity.ConcurrencyToken = Guid.NewGuid();
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastUpdateDate = DateTime.UtcNow;
                        entry.Entity.UpdateByID = _user.Id;
                        //entry.Entity.ConcurrencyToken = Guid.NewGuid();
                        break;
                }

            }
            return _dbContext.SaveChangesAsync();
        }
    }
}
