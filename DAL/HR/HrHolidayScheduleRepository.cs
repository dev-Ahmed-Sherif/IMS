using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrHolidayScheduleRepository
    {

        private AppDbContext _context;
        public HrHolidayScheduleRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrHolidayScheduleVM HolidaySchedule)
        {
            try
            {
                var _HolidaySchedule = new HrHolidaySchedule()
                {
                    Name = HolidaySchedule.name,
                    Year = HolidaySchedule.year,
                    HolidayId = HolidaySchedule.HolidayId,
                    StartDate = HolidaySchedule.StartDate,
                    EndDate = HolidaySchedule.EndDate,



                    CreatedByID = HolidaySchedule.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrHolidaySchedule.Add(_HolidaySchedule);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrHolidayScheduleVM HolidaySchedule)
        {
            try
            {
                var _HolidaySchedule = _context.HrHolidaySchedule.FirstOrDefault(n => n.Id == HolidaySchedule.Id);
                if (_HolidaySchedule != null)
                {
                    _HolidaySchedule.Name = HolidaySchedule.name;
                    _HolidaySchedule.Year = HolidaySchedule.year;
                    _HolidaySchedule.HolidayId = HolidaySchedule.HolidayId;
                    _HolidaySchedule.StartDate = HolidaySchedule.StartDate;
                    _HolidaySchedule.EndDate = HolidaySchedule.EndDate;



                    _HolidaySchedule.UpdateByID = HolidaySchedule.TransactionUserId;
                    _HolidaySchedule.LastUpdateDate = DateTime.Now;

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

        public string Delete(int HolidayScheduleId)
        {
            try
            {
                var _HolidaySchedule = _context.HrHolidaySchedule.FirstOrDefault(n => n.Id == HolidayScheduleId);
                if (_HolidaySchedule != null)
                {
                    _context.HrHolidaySchedule.Remove(_HolidaySchedule);
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


        public List<HrHolidayScheduleGetVM> GetAll() => _context.HrHolidaySchedule.Select(n => new HrHolidayScheduleGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, year = n.Year, HolidayId = n.HolidayId, HolidayName = n.Holiday.Name, StartDate = n.StartDate, EndDate = n.EndDate }).ToList();
        public HrHolidayScheduleGetVM GetById(int HolidayScheduleId) => _context.HrHolidaySchedule.Select(n => new HrHolidayScheduleGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, year = n.Year, HolidayId = n.HolidayId, HolidayName = n.Holiday.Name, StartDate = n.StartDate, EndDate = n.EndDate }).FirstOrDefault(n => n.Id == HolidayScheduleId);

    }
}
