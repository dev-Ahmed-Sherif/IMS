using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL.HR
{
    public class HrEmployeeAttendanceRepository
    {

        private AppDbContext _context;
        public HrEmployeeAttendanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrEmployeeAttendanceVM EmployeeAttendance)
        {
            // TimeZoneInfo targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
               TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            DateTime Attendance = EmployeeAttendance.Attendance.ToUniversalTime();
            DateTime Departure = EmployeeAttendance.Departure.ToUniversalTime();
            try
            {
                var _EmployeeAttendance = new HrEmployeeAttendance()
                {
                    AttendanceMachineId = EmployeeAttendance.AttendanceMachineId,
                    EmployeeId = EmployeeAttendance.EmployeeId,
                    Date = ConvertToLocalTime(EmployeeAttendance.Date, localTimeZone),
                 //   Attendance = ConvertToLocalTime(EmployeeAttendance.Attendance, localTimeZone),
                  //  Departure = ConvertToLocalTime(EmployeeAttendance.Departure, localTimeZone),
                  Attendance=Attendance,
                  Departure=Departure,
                    CreatedByID = EmployeeAttendance.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrEmployeeAttendance.Add(_EmployeeAttendance);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        //public static DateTime ConvertToLocalTime(DateTime utcDateTime)
        // {
        //     // Get the local time zone
        //     TimeZoneInfo localTimeZone = TimeZoneInfo.Local;

        //     // Convert the UTC time to local time
        //     DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, localTimeZone);

        //     return localDateTime;
        // }
        public static DateTime ConvertToLocalTime(DateTime utcDateTime, TimeZoneInfo targetTimeZone)
        {
            // Convert the UTC time to the target time zone
            DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, targetTimeZone);

            return localDateTime;
        }
        public string Update(HrEmployeeAttendanceVM EmployeeAttendance)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            DateTime Attendance = EmployeeAttendance.Attendance.ToUniversalTime();
            DateTime Departure = EmployeeAttendance.Departure.ToUniversalTime();
            try
            {
                var _EmployeeAttendance = _context.HrEmployeeAttendance.FirstOrDefault(n => n.Id == EmployeeAttendance.Id);
                if (_EmployeeAttendance != null)
                {
                    _EmployeeAttendance.AttendanceMachineId = EmployeeAttendance.AttendanceMachineId;
                    _EmployeeAttendance.EmployeeId = EmployeeAttendance.EmployeeId;
                     _EmployeeAttendance.Date = ConvertToLocalTime(EmployeeAttendance.Date, localTimeZone);
                    //_EmployeeAttendance.Attendance = ConvertToLocalTime(EmployeeAttendance.Attendance, localTimeZone);
                    //_EmployeeAttendance.Departure = ConvertToLocalTime(EmployeeAttendance.Departure, localTimeZone);
                    _EmployeeAttendance.Attendance = EmployeeAttendance.Attendance;
                    _EmployeeAttendance.Departure = EmployeeAttendance.Departure;
                    _EmployeeAttendance.UpdateByID = EmployeeAttendance.TransactionUserId;
                    _EmployeeAttendance.LastUpdateDate = DateTime.Now;

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

        public string Delete(int EmployeeAttendanceId)
        {
            try
            {
                var _EmployeeAttendance = _context.HrEmployeeAttendance.FirstOrDefault(n => n.Id == EmployeeAttendanceId);
                if (_EmployeeAttendance != null)
                {
                    _context.HrEmployeeAttendance.Remove(_EmployeeAttendance);
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

        //public List<HrEmployeeAttendanceGetVM> GetAll()

        //    => _context.HrEmployeeAttendance.Select(n => new HrEmployeeAttendanceGetVM
        //    {

        //        Id = n.Id,
        //        CreateUserName = n.CreatedBy.Name,
        //        TransactionUserId = n.CreatedBy.Id,
        //        AttendanceMachineId = n.AttendanceMachineId,
        //        AttendanceMachineName = n.AttendanceMachine.Name,
        //        EmployeeId = n.EmployeeId,
        //        EmployeeName = n.Employee.Name,
        //        Date = ConvertToLocalTime(n.Date),
        //        Attendance = ConvertToLocalTime(n.Attendance),
        //        Departure = ConvertToLocalTime(n.Departure)
        //    }).ToList();
        public List<HrEmployeeAttendanceGetVM> GetAll()
        {
            TimeZoneInfo targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");



            return _context.HrEmployeeAttendance.Select(n => new HrEmployeeAttendanceGetVM
            {
                Id = n.Id,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                AttendanceMachineId = n.AttendanceMachineId,
                AttendanceMachineName = n.AttendanceMachine.Name,
                EmployeeId = n.EmployeeId,
                EmployeeName = n.Employee.Name,
                Date = ConvertToLocalTime(n.Date, targetTimeZone).AddHours(+4),
                Attendance = ConvertToLocalTime(n.Attendance, targetTimeZone).AddHours(+4),
                Departure = ConvertToLocalTime(n.Departure, targetTimeZone).AddHours(+4)
            }).ToList();
        }
        public HrEmployeeAttendanceGetVM GetById(int EmployeeAttendanceId)
        {
            TimeZoneInfo targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            return _context.HrEmployeeAttendance.Select(n => new HrEmployeeAttendanceGetVM
            {
                 
                Id = n.Id,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                AttendanceMachineId = n.AttendanceMachineId,
                AttendanceMachineName = n.AttendanceMachine.Name,
                EmployeeId = n.EmployeeId,
                EmployeeName = n.Employee.Name,
                Date = ConvertToLocalTime(n.Date, targetTimeZone).AddHours(+4),
                Attendance = ConvertToLocalTime(n.Attendance, targetTimeZone).AddHours(+4),
                Departure = ConvertToLocalTime(n.Departure, targetTimeZone).AddHours(+4)
            }).FirstOrDefault(n => n.Id == EmployeeAttendanceId);
}
      
        public List<HrEmployeeAttendanceGetSearchVM> Search(HrEmployeeAttendanceSearch searchModel)
        {
          
            var query = _context.HrEmployeeAttendance.AsQueryable();
            if (searchModel.id.HasValue)
            {
                query = query.Where(p => p.Id == searchModel.id);
            }
            if (searchModel.Date.HasValue)
            {
                query = query.Where(p => p.Date >= searchModel.Date.Value.Date);
            }
            if (searchModel.Attendance.HasValue)
            {
                query = query.Where(p => p.Attendance >= searchModel.Attendance.Value.Date);
            }
            if (searchModel.Departure.HasValue)
            {
                query = query.Where(p => p.Departure >= searchModel.Departure.Value.Date);
            }
            if (searchModel.EmployeeId.HasValue)
            {
                query = query.Where(p => p.EmployeeId==searchModel.EmployeeId);
            }
            if (searchModel.AttendanceMachineId.HasValue)
            {
                query = query.Where(p => p.AttendanceMachineId==searchModel.AttendanceMachineId);
            }
            if (searchModel.StartDate.HasValue)
            {
                query = query.Where(p => p.Date >= searchModel.StartDate.Value.Date);
            }
            if (searchModel.EndDate.HasValue)
            {
                query = query.Where(p => p.Date <= searchModel.EndDate.Value.Date);
            }


            var result = query.Select(n => new HrEmployeeAttendanceGetSearchVM
            {
                Id = n.Id,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                AttendanceMachineId = n.AttendanceMachineId,
                AttendanceMachineName = n.AttendanceMachine.Name??"",
                EmployeeId = n.EmployeeId,
                EmployeeName = n.Employee.Name??"",
                Date =n.Date ,
                Attendance = n.Attendance ,
                Departure = n.Departure,
                ShortDate = n.Date.ToString("dd/MM/yyyy"),
                ShortAttendance = n.Attendance.ToString("HH:mm:ss"),
                ShortDeparture = n.Departure.ToString("HH:mm:ss"),
                StartDate = searchModel.StartDate.Value.Date.ToString("dd/MM/yyyy"),
                EndDate = searchModel.EndDate.Value.Date.ToString("dd/MM/yyyy"),
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                Section = n.Employee.SectionId!=null?n.Employee.Section.Name:"",
                
                UpdateUserName=n.UpdateByID!=null?n.UpdateBy.Name:"",
            }).ToList();
            return result;
        }
    }
}
