using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrSeveranceReasonRepository
    {

        private AppDbContext _context;
        public HrSeveranceReasonRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrSeveranceReasonVM SeveranceReason)
        {
            try
            {
                var _SeveranceReason = new HrSeveranceReason()
                {
                    Name = SeveranceReason.name,

                    CreatedByID = SeveranceReason.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrSeveranceReason.Add(_SeveranceReason);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrSeveranceReasonVM SeveranceReason)
        {
            try
            {
                var _SeveranceReason = _context.HrSeveranceReason.FirstOrDefault(n => n.Id == SeveranceReason.Id);
                if (_SeveranceReason != null)
                {
                    _SeveranceReason.Name = SeveranceReason.name;

                    _SeveranceReason.UpdateByID = SeveranceReason.TransactionUserId;
                    _SeveranceReason.LastUpdateDate = DateTime.Now;

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

        public string Delete(int SeveranceReasonId)
        {
            try
            {
                var _SeveranceReason = _context.HrSeveranceReason.FirstOrDefault(n => n.Id == SeveranceReasonId);
                if (_SeveranceReason != null)
                {
                    _context.HrSeveranceReason.Remove(_SeveranceReason);
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


        public List<HrSeveranceReasonGetVM> GetAll() => _context.HrSeveranceReason.Select(n => new HrSeveranceReasonGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public HrSeveranceReasonGetVM GetById(int SeveranceReasonId) => _context.HrSeveranceReason.Select(n => new HrSeveranceReasonGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).FirstOrDefault(n => n.Id == SeveranceReasonId);

    }
}
