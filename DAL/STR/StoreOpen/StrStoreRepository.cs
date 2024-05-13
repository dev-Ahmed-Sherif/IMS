using Entities.ExtensionMethods.STR.StoreOpen;
using Entities.Models.PR;
using Entities.Models.STR.StoreOpen;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.StoreOpen
{
    public class StrStoreRepository
    {
        private AppDbContext _context;
        public StrStoreRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(StrStoreVM store)
        {
            bool exists = _context.StrStore.Any(s => s.Name == store.Name);
            if (exists)
            {
                return " Name already exists.";
            }
                var _store = new StrStore()
                {
                    Name = store.Name,
                    Code = store.SectionId.HasValue ? GetLastNo(store.SectionId.Value) : default,
                    StorekeeperId = store.StorekeeperId,
                    SectionId = store.SectionId,
                    CreatedByID = store.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.StrStore.Add(_store);
                _context.SaveChanges();
                return "Succeeded";
          
        }

        public string Update(StrStoreVM store)
        {
            bool exists = _context.StrStore.Any(s => s.Name == store.Name && s.Id != store.Id);
            if (exists)
            {
                return " Name already exists.";
            }
            var _store = _context.StrStore.Single(n => n.Id == store.Id);
               
                    _store.Name = store.Name;
                    _store.StorekeeperId = store.StorekeeperId;
                    _store.Code = store.Code;
                    _store.SectionId = store.SectionId;
                    _store.UpdateByID = store.TransactionUserId;
                    _store.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
              
          
        }

        public string Delete(int storeId)
        {
           
                var _store = _context.StrStore.Single(n => n.Id == storeId);
               
                    _context.StrStore.Remove(_store);
                    _context.SaveChanges();
                    return "Succeeded";
               
            
        }

         public List<StrStoreGetVM> GetAll() => _context.StrStore.Select(n => n.ToStrStoreGetVM()).ToList();
        public List<StrStoreGetVM> Search(StoreSearch search)
        {
           var query = _context.StrStore.AsQueryable();
            if (search.Id.HasValue)
            {
                query = query.Where(p => p.Id == search.Id);
            }
            if (search.Code.HasValue)
            {
                query = query.Where(p => p.Code== search.Code);
            }
            if (!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(e => e.Name.Contains(search.Name));
            }
            if (search.Code.HasValue)
            {
                query = query.Where(p => p.Code == search.Code);
            }
            if (search.StorekeeperId.HasValue)
            {
                query = query.Where(p => p.StorekeeperId == search.StorekeeperId);
            }
            if (search.SectionId.HasValue)
            {
                query = query.Where(p => p.SectionId == search.SectionId);
            }
            List<StrStoreGetVM> results;
            results =
                query
                .Select(p => p.ToStrStoreGetVM())
                .ToList();
            return results;
        }
         



        
        public StrStoreGetVM GetById(int storeId) => _context.StrStore.Select(n => new StrStoreGetVM
        {
            Id = n.Id,
            Name = n.Name,
            Code = n.Code,
            StorekeeperId = n.StorekeeperId,
            StorekeeperName = n.Storekeeper.Name,

            CreateUserName = n.CreatedBy.Name,
            TransactionUserId = n.CreatedBy.Id,
            Section = n.Section.Name,
        }).Single(n => n.Id == storeId);
        public int GetLastNo(int sectionId)
        {
            int maxNo = _context.StrStore
                .Where(s => s.SectionId == sectionId)
                .Select(item => item.Code).DefaultIfEmpty()
                .Max();

            return maxNo == 0 ? 1 : ++maxNo;

            // string maxNo = _context.StrItem.Select(n => new StrItem { No = n.No }).MaxAsync(n => n.GroupId == GroupId);
            //var maxNo = from item in StrItem where( item=> item.GroupId == GroupId ) select item.No;

        }
       
    }
}
