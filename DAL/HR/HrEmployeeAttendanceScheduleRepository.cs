using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrEmployeeAttendanceScheduleRepository
    {

        private AppDbContext _context;
        public HrEmployeeAttendanceScheduleRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrEmployeeAttendanceScheduleVM EmployeeAttendanceSchedule)
        {
            try
            {
                var _EmployeeAttendanceSchedule = new HrEmployeeAttendanceSchedule()
                {
                    Name = EmployeeAttendanceSchedule.name,
                    EmployeeId = EmployeeAttendanceSchedule.EmployeeId,
                    AttendanceScheduleId = EmployeeAttendanceSchedule.AttendanceScheduleId,
                    AttendancePermissionId = EmployeeAttendanceSchedule.AttendancePermissionId,




                    CreatedByID = EmployeeAttendanceSchedule.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrEmployeeAttendanceSchedule.Add(_EmployeeAttendanceSchedule);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string Update(HrEmployeeAttendanceScheduleVM EmployeeAttendanceSchedule)
        {
            try
            {
                var _EmployeeAttendanceSchedule = _context.HrEmployeeAttendanceSchedule.FirstOrDefault(n => n.Id == EmployeeAttendanceSchedule.Id);
                if (_EmployeeAttendanceSchedule != null)
                {
                    _EmployeeAttendanceSchedule.Name = EmployeeAttendanceSchedule.name;
                    _EmployeeAttendanceSchedule.EmployeeId = EmployeeAttendanceSchedule.EmployeeId;
                    _EmployeeAttendanceSchedule.AttendanceScheduleId = EmployeeAttendanceSchedule.AttendanceScheduleId;
                    _EmployeeAttendanceSchedule.AttendancePermissionId = EmployeeAttendanceSchedule.AttendancePermissionId;



                    _EmployeeAttendanceSchedule.UpdateByID = EmployeeAttendanceSchedule.TransactionUserId;
                    _EmployeeAttendanceSchedule.LastUpdateDate = DateTime.Now;

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

        public string Delete(int EmployeeAttendanceScheduleId)
        {
            try
            {
                var _EmployeeAttendanceSchedule = _context.HrEmployeeAttendanceSchedule.FirstOrDefault(n => n.Id == EmployeeAttendanceScheduleId);
                if (_EmployeeAttendanceSchedule != null)
                {
                    _context.HrEmployeeAttendanceSchedule.Remove(_EmployeeAttendanceSchedule);
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

        public List<HrEmployeeAttendanceScheduleGetVM> GetAll()
            => _context.HrEmployeeAttendanceSchedule.Select(n => new HrEmployeeAttendanceScheduleGetVM
            {
                Id = n.Id,
                name = n.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                EmployeeId = n.EmployeeId,
                EmployeeName = n.Employee.Name,
                AttendancePermissionId = n.AttendancePermissionId,
                AttendancePermissionName = n.AttendancePermission.Name,
                AttendanceScheduleId = n.AttendanceScheduleId,
                AttendanceScheduleName = n.AttendanceSchedule.Name
            }).ToList();

        public HrEmployeeAttendanceScheduleGetVM GetById(int EmployeeAttendanceScheduleId)
            => _context.HrEmployeeAttendanceSchedule.Select(n => new HrEmployeeAttendanceScheduleGetVM
            {
                Id = n.Id,
                name = n.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                EmployeeId = n.EmployeeId,
                EmployeeName = n.Employee.Name,
                AttendancePermissionId = n.AttendancePermissionId,
                AttendancePermissionName = n.AttendancePermission.Name,
                AttendanceScheduleId = n.AttendanceScheduleId,
                AttendanceScheduleName = n.AttendanceSchedule.Name
            }).FirstOrDefault(n => n.Id == EmployeeAttendanceScheduleId);
        public List<HrEmployeeAttendanceScheduleGetVM> Search(HrEmpAttendScheduleSearch searchModel)
        {
            var query = _context.HrEmployeeAttendanceSchedule.AsQueryable();
            if (!string.IsNullOrEmpty(searchModel.EmployeeName))
            {
                query = query.Where(p => p.Employee.Name.Contains(searchModel.EmployeeName));
            }
            if (!string.IsNullOrEmpty(searchModel.name))
            {
                query = query.Where(p => p.Name.Contains(searchModel.name));
            }
            if (!string.IsNullOrEmpty(searchModel.AttendancePermissionName))
            {
                query = query.Where(p => p.AttendancePermission.Name.Contains(searchModel.AttendancePermissionName));
            }
            if (!string.IsNullOrEmpty(searchModel.AttendanceScheduleName))
            {
                query = query.Where(p => p.AttendanceSchedule.Name.Contains(searchModel.AttendanceScheduleName));
            }
            if (searchModel.StartDate.HasValue)
            {
                query = query.Where(p => p.AttendanceSchedule.StartDate >= searchModel.StartDate.Value.Date);
            }
            if (searchModel.EndDate.HasValue)
            {
                query = query.Where(p => p.AttendanceSchedule.StartDate <= searchModel.EndDate.Value.Date);
            }

            var result = query.Select(n => new HrEmployeeAttendanceScheduleGetVM
            {
                Id = n.Id,
                name = n.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                EmployeeId = n.EmployeeId,
                EmployeeName = n.Employee.Name,
                AttendancePermissionId = n.AttendancePermissionId,
                AttendancePermissionName = n.AttendancePermission.Name,
                AttendanceScheduleId = n.AttendanceScheduleId,
                AttendanceScheduleName = n.AttendanceSchedule.Name,
                StartDate = searchModel.StartDate.Value.Date.ToString("dd/MM/yyyy"),
                EndDate = searchModel.EndDate.Value.Date.ToString("dd/MM/yyyy"),
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                Section = n.Employee.Section.Name,


            }).ToList();

            return result;
        }
    }
}
