using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DAL.HR
{
    public class HrHolidayRepository
    {

        private AppDbContext _context;
        public HrHolidayRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrHolidayVM Holiday)
        {
            try
            {
                var _Holiday = new HrHoliday()
                {
                    Name = Holiday.name,
                    CreatedByID = Holiday.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrHoliday.Add(_Holiday);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrHolidayVM Holiday)
        {
            try
            {
                var _Holiday = _context.HrHoliday.FirstOrDefault(n => n.Id == Holiday.Id);
                if (_Holiday != null)
                {
                    _Holiday.Name = Holiday.name;

                    _Holiday.UpdateByID = Holiday.TransactionUserId;
                    _Holiday.LastUpdateDate = DateTime.Now;

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

        public string Delete(int HolidayId)
        {
            try
            {
                var _Holiday = _context.HrHoliday.FirstOrDefault(n => n.Id == HolidayId);
                if (_Holiday != null)
                {
                    _context.HrHoliday.Remove(_Holiday);
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


        public List<HrHolidayGetVM> GetAll() => _context.HrHoliday.Select(n => new HrHolidayGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public HrHolidayGetVM GetById(int HolidayId) => _context.HrHoliday.Select(n => new HrHolidayGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).FirstOrDefault(n => n.Id == HolidayId);

    }
}
