using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrMillitryStateRepository
    {

        private AppDbContext _context;
        public HrMillitryStateRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrMillitryStateVM MillitryState)
        {
            try
            {
                var _MillitryState = new HrMillitryState()
                {
                    Name = MillitryState.name,

                    CreatedByID = MillitryState.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrMillitryState.Add(_MillitryState);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrMillitryStateVM MillitryState)
        {
            try
            {
                var _MillitryState = _context.HrMillitryState.FirstOrDefault(n => n.Id == MillitryState.Id);
                if (_MillitryState != null)
                {
                    _MillitryState.Name = MillitryState.name;

                    _MillitryState.UpdateByID = MillitryState.TransactionUserId;
                    _MillitryState.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
                }
                else
                {
                    return "nothing to be updated";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string Delete(int MillitryStateId)
        {
            try
            {
                var _MillitryState = _context.HrMillitryState.FirstOrDefault(n => n.Id == MillitryStateId);
                if (_MillitryState != null)
                {
                    _context.HrMillitryState.Remove(_MillitryState);
                    _context.SaveChanges();
                    return "Succeeded";
                }
                else
                {
                    return "nothing to be deleted";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        public List<HrMillitryStateGetVM> GetAll() => _context.HrMillitryState.Select(n => new HrMillitryStateGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public HrMillitryStateGetVM GetById(int MillitryStateId) => _context.HrMillitryState.Select(n => new HrMillitryStateGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).FirstOrDefault(n => n.Id == MillitryStateId);

    }
}

