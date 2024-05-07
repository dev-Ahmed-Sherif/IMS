using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DAL.HR
{
    public class HrEmployeeAttendancePermissionRepository
    {

        private AppDbContext _context;
        public HrEmployeeAttendancePermissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrEmployeeAttendancePermissionVM EmployeeAttendancePermission)
        {
            try
            {
                var _EmployeeAttendancePermission = new HrEmployeeAttendancePermission()
                {
                    Name = EmployeeAttendancePermission.name,
                    EmployeeId = EmployeeAttendancePermission.EmployeeId,
                    AttendancePermissionId = EmployeeAttendancePermission.AttendancePermissionId,
                    Date = EmployeeAttendancePermission.Date,





                    CreatedByID = EmployeeAttendancePermission.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrEmployeeAttendancePermission.Add(_EmployeeAttendancePermission);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrEmployeeAttendancePermissionVM EmployeeAttendancePermission)
        {
            try
            {
                var _EmployeeAttendancePermission = _context.HrEmployeeAttendancePermission.FirstOrDefault(n => n.Id == EmployeeAttendancePermission.Id);
                if (_EmployeeAttendancePermission != null)
                {
                    _EmployeeAttendancePermission.Name = EmployeeAttendancePermission.name;

                    _EmployeeAttendancePermission.EmployeeId = EmployeeAttendancePermission.EmployeeId;
                    _EmployeeAttendancePermission.AttendancePermissionId = EmployeeAttendancePermission.AttendancePermissionId;
                    _EmployeeAttendancePermission.Date = EmployeeAttendancePermission.Date;




                    _EmployeeAttendancePermission.UpdateByID = EmployeeAttendancePermission.TransactionUserId;
                    _EmployeeAttendancePermission.LastUpdateDate = DateTime.Now;

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

        public string Delete(int EmployeeAttendancePermissionId)
        {
            try
            {
                var _EmployeeAttendancePermission = _context.HrEmployeeAttendancePermission.FirstOrDefault(n => n.Id == EmployeeAttendancePermissionId);
                if (_EmployeeAttendancePermission != null)
                {
                    _context.HrEmployeeAttendancePermission.Remove(_EmployeeAttendancePermission);
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


        public List<HrEmployeeAttendancePermissionGetVM> GetAll()
            => _context.HrEmployeeAttendancePermission.Select(n => new HrEmployeeAttendancePermissionGetVM
            {
                Id = n.Id,
                name = n.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                EmployeeId = n.EmployeeId,
                EmployeeName = n.Employee.Name,
                AttendancePermissionId = n.AttendancePermissionId,
                AttendancePermissionName = n.AttendancePermission.Name,
                Date = n.Date
            }).ToList();

        public HrEmployeeAttendancePermissionGetVM GetById(int EmployeeAttendancePermissionId)
            => _context.HrEmployeeAttendancePermission.Select(n => new HrEmployeeAttendancePermissionGetVM
            {
                Id = n.Id,
                name = n.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                EmployeeId = n.EmployeeId,
                EmployeeName = n.Employee.Name,
                AttendancePermissionId = n.AttendancePermissionId,
                AttendancePermissionName = n.AttendancePermission.Name,
                Date = n.Date
            }).FirstOrDefault(n => n.Id == EmployeeAttendancePermissionId);
        public List<HrEmployeeAttendancePermissionGetSearch> Search(HrEmployeeAttendancePermissionSearch searchModel)
        {
            var query = _context.HrEmployeeAttendancePermission.AsQueryable();
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
            if (searchModel.Date.HasValue)
            {
                query = query.Where(p => p.Date >= searchModel.Date.Value.Date);
            }
            var result = query.Select(n => new HrEmployeeAttendancePermissionGetSearch
            {
                Id = n.Id,
                name = n.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                EmployeeId = n.EmployeeId,
                EmployeeName = n.Employee.Name,
                AttendancePermissionId = n.AttendancePermissionId,
                AttendancePermissionName = n.AttendancePermission.Name,
                Date = n.Date,
                ShortDate = n.Date.ToString("dd/MM/yyyy")

            }).ToList();

            return result;
        }
    }
}
