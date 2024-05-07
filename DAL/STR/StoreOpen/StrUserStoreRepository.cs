using Entities.Models.STR.StoreOpen;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.StoreOpen
{
    public class StrUserStoreRepository
    {
        private AppDbContext _context;
        public StrUserStoreRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(StrUserStoreGeneralVM store)
        {
           
                var _store = new StrUserStore()
                {
                    UserId = store.UserId,
                    StoreId = store.StoreId,
                    CreatedByID = store.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.StrUserStore.Add(_store);
                _context.SaveChanges();
                return "Succeeded";
           
        }

        public string Update(StrUserStoreVM store)
        {
           
                var _store = _context.StrUserStore.Single(n => n.Id == store.Id);
              
                    _store.UserId = store.UserId;
                    _store.StoreId = store.StoreId;
                    _store.UpdateByID = store.TransactionUserId;
                    _store.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
              
          
        }

        public string Delete(int storeId)
        {
            
                var _store = _context.StrUserStore.Single(n => n.Id == storeId);
               
                    _context.StrUserStore.Remove(_store);
                    _context.SaveChanges();
                    return "Succeeded";
               
          
        }

        public List<StrUserStoreGetVM> GetAll() => _context.StrUserStore.Select(n => new StrUserStoreGetVM { Id = n.Id, UserId = n.UserId, StoreId = n.StoreId, StoreName = n.Store.Name, UserName = n.User.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public StrUserStoreGetVM GetById(int storeId) => _context.StrUserStore.Select(n => new StrUserStoreGetVM { Id = n.Id, UserId = n.UserId, StoreId = n.StoreId, StoreName = n.Store.Name, UserName = n.User.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == storeId);

        public List<StrUserStoreGetVM> GetByUser(int UserId)
        {

            var userStoreVMs = _context.StrUserStore
             .Where(us => us.UserId == UserId)
             .Select(us => new StrUserStoreGetVM
             {
                 Id = us.Id,
                 UserName = us.User.Name,
                 StoreName = us.Store.Name,
                 StoreId = us.StoreId,
                 UserId = us.UserId,
                 TransactionUserId = us.CreatedBy.Id

             })
             .ToList();

            return userStoreVMs;
        }
    }
}
