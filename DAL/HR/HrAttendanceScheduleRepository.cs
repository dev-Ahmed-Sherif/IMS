using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrAttendanceScheduleRepository
    {

        private AppDbContext _context;
        public HrAttendanceScheduleRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(HrAttendanceScheduleVM AttendanceSchedule)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            try
            {
                var _AttendanceSchedule = new HrAttendanceSchedule()
                {
                    Name = AttendanceSchedule.name,
                    StartDate = AttendanceSchedule.StartDate,
                    EndDate = AttendanceSchedule.EndDate,
                    WrkHours = AttendanceSchedule.WrkHours,
                    AttendanceTime = ConvertToLocalTime(AttendanceSchedule.AttendanceTime, localTimeZone),
                    AttendanceAllowance = AttendanceSchedule.AttendanceAllowance,
                    DepartureAllowance = AttendanceSchedule.DepartureAllowance,
                    CreatedByID = AttendanceSchedule.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrAttendanceSchedule.Add(_AttendanceSchedule);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public static DateTime ConvertToLocalTime(DateTime utcDateTime, TimeZoneInfo targetTimeZone)
        {
            // Convert the UTC time to the target time zone
            DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, targetTimeZone);

            return localDateTime;
        }
        public string Update(HrAttendanceScheduleVM AttendanceSchedule)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            try
            {
                var _AttendanceSchedule = _context.HrAttendanceSchedule.FirstOrDefault(n => n.Id == AttendanceSchedule.Id);
                if (_AttendanceSchedule != null)
                {
                    _AttendanceSchedule.Name = AttendanceSchedule.name;
                    _AttendanceSchedule.StartDate = AttendanceSchedule.StartDate;
                    _AttendanceSchedule.EndDate = AttendanceSchedule.EndDate;
                    _AttendanceSchedule.WrkHours = AttendanceSchedule.WrkHours;
                    _AttendanceSchedule.AttendanceTime = AttendanceSchedule.AttendanceTime;
                    _AttendanceSchedule.AttendanceTime = ConvertToLocalTime(AttendanceSchedule.AttendanceTime,localTimeZone);
                    _AttendanceSchedule.DepartureAllowance = AttendanceSchedule.DepartureAllowance;
                    _AttendanceSchedule.AttendanceAllowance = AttendanceSchedule.AttendanceAllowance;
                    _AttendanceSchedule.UpdateByID = AttendanceSchedule.TransactionUserId;
                    _AttendanceSchedule.LastUpdateDate = DateTime.Now;

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
        public string Delete(int AttendanceScheduleId)
        {
            try
            {
                var _AttendanceSchedule = _context.HrAttendanceSchedule.FirstOrDefault(n => n.Id == AttendanceScheduleId);
                if (_AttendanceSchedule != null)
                {
                    _context.HrAttendanceSchedule.Remove(_AttendanceSchedule);
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
        //public List<HrAttendanceScheduleGetVM> GetAll()
        //    => _context.HrAttendanceSchedule.Select(n => new HrAttendanceScheduleGetVM
        //    {
        //        Id = n.Id,
        //        name = n.Name,
        //        CreateUserName = n.CreatedBy.Name,
        //        TransactionUserId = n.CreatedBy.Id,
        //        WrkHours = n.WrkHours,
        //        StartDate = n.StartDate,
        //        EndDate = n.EndDate,
        //        AttendanceTime = n.AttendanceTime,
        //        AttendanceAllowance = n.AttendanceAllowance,
        //        DepartureAllowance = n.DepartureAllowance
        //    }).ToList();
        public List<HrAttendanceScheduleGetVM> GetAll()
        {
            TimeZoneInfo targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");



            return _context.HrAttendanceSchedule.Select(n => new HrAttendanceScheduleGetVM
            {
                       Id = n.Id,
                      name = n.Name,
                        CreateUserName = n.CreatedBy.Name,
                       TransactionUserId = n.CreatedBy.Id,
                       WrkHours = n.WrkHours,
                        StartDate = n.StartDate,
                       EndDate = n.EndDate,
                       AttendanceTime = ConvertToLocalTime(n.AttendanceTime, targetTimeZone).AddHours(+4),
                       AttendanceAllowance = n.AttendanceAllowance,
                       DepartureAllowance = n.DepartureAllowance
            }).ToList();
        }
     
        public HrAttendanceScheduleGetVM GetById(int AttendanceScheduleId)
        {
            TimeZoneInfo targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            return _context.HrAttendanceSchedule.Select(n => new HrAttendanceScheduleGetVM
            {

                Id = n.Id,
                name = n.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                WrkHours = n.WrkHours,
                StartDate = n.StartDate,
                EndDate = n.EndDate,
                AttendanceTime = ConvertToLocalTime(n.AttendanceTime, targetTimeZone).AddHours(+4),
                AttendanceAllowance = n.AttendanceAllowance,
                DepartureAllowance = n.DepartureAllowance
            }).FirstOrDefault(n => n.Id == AttendanceScheduleId);
        }

    }
}
