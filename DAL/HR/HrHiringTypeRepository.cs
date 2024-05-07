using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DAL.HR
{
    public class HrHiringTypeRepository
    {

        private AppDbContext _context;
        public HrHiringTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrHiringTypeVM HiringType)
        {
            try
            {
                var _HiringType = new HrHiringType()
                {
                    Name = HiringType.name,
                    CreatedByID = HiringType.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrHiringType.Add(_HiringType);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrHiringTypeVM HiringType)
        {
            try
            {
                var _HiringType = _context.HrHiringType.FirstOrDefault(n => n.Id == HiringType.Id);
                if (_HiringType != null)
                {
                    _HiringType.Name = HiringType.name;

                    _HiringType.UpdateByID = HiringType.TransactionUserId;
                    _HiringType.LastUpdateDate = DateTime.Now;

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

        public string Delete(int HiringTypeId)
        {
            try
            {
                var _HiringType = _context.HrHiringType.FirstOrDefault(n => n.Id == HiringTypeId);
                if (_HiringType != null)
                {
                    _context.HrHiringType.Remove(_HiringType);
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


        public List<HrHiringTypeGetVM> GetAll() => _context.HrHiringType.Select(n => new HrHiringTypeGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public HrHiringTypeGetVM GetById(int HiringTypeId) => _context.HrHiringType.Select(n => new HrHiringTypeGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).FirstOrDefault(n => n.Id == HiringTypeId);

    }
}
