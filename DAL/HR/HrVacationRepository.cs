using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrVacationRepository
    {

        private AppDbContext _context;
        public HrVacationRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrVacationVM Vacation)
        {
            try
            {
                var _Vacation = new HrVacation()
                {
                    Name = Vacation.name,

                    CreatedByID = Vacation.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrVacation.Add(_Vacation);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrVacationVM Vacation)
        {
            try
            {
                var _Vacation = _context.HrVacation.FirstOrDefault(n => n.Id == Vacation.Id);
                if (_Vacation != null)
                {
                    _Vacation.Name = Vacation.name;

                    _Vacation.UpdateByID = Vacation.TransactionUserId;

                    _Vacation.LastUpdateDate = DateTime.Now;

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

        public string Delete(int VacationId)
        {
            try
            {
                var _Vacation = _context.HrVacation.FirstOrDefault(n => n.Id == VacationId);
                if (_Vacation != null)
                {
                    _context.HrVacation.Remove(_Vacation);
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


        public List<HrVacationGetVM> GetAll() => _context.HrVacation.Select(n => new HrVacationGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public HrVacationGetVM GetById(int VacationId) => _context.HrVacation.Select(n => new HrVacationGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).FirstOrDefault(n => n.Id == VacationId);

    }
}
