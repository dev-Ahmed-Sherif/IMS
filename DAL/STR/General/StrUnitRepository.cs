using Entities.Models.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.General
{
    public class StrUnitRepository
    {
        private AppDbContext _context;
        public StrUnitRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(StrUnitVM unit)
        {
           
                bool exists = _context.StrUnit.Any(s => s.Name == unit.Name);
                if (exists)
                {
                    return " Name already exists.";
                }
                var _unit = new StrUnit()
                {
                    Name = unit.Name,
                    CreatedByID = unit.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.StrUnit.Add(_unit);
                _context.SaveChanges();
                return "Succeeded";
          
        }

        public string Update(StrUnitVM unit)
        {
          
                bool exists = _context.StrUnit.Any(s => s.Name == unit.Name && s.Id != unit.Id);
                if (exists)
                {
                    return " Name already exists.";
                }
                var _unit = _context.StrUnit.Single(n => n.Id == unit.Id);
              
                    _unit.Name = unit.Name;

                    _unit.UpdateByID = unit.TransactionUserId;
                    _unit.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
                
        }

        public string Delete(int unitId)
        {
            
                var _unit = _context.StrUnit.Single(n => n.Id == unitId);
              
                    _context.StrUnit.Remove(_unit);
                    _context.SaveChanges();
                    return "Succeeded";
               
           
        }

        public List<StrUnitGetVM> GetAll() => _context.StrUnit.Select(n => new StrUnitGetVM { Id = n.Id, Name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public StrUnitGetVM GetById(int unitId) => _context.StrUnit.Select(n => new StrUnitGetVM { Id = n.Id, Name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == unitId);

    }
}
