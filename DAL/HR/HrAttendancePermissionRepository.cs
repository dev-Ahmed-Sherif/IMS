using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrAttendancePermissionRepository
    {

        private AppDbContext _context;
        public HrAttendancePermissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrAttendancePermissionVM AttendancePermission)
        {
            try
            {
                var _AttendancePermission = new HrAttendancePermission()
                {
                    Name = AttendancePermission.name,




                    CreatedByID = AttendancePermission.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrAttendancePermission.Add(_AttendancePermission);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string Update(HrAttendancePermissionVM AttendancePermission)
        {
            try
            {
                var _AttendancePermission = _context.HrAttendancePermission.FirstOrDefault(n => n.Id == AttendancePermission.Id);
                if (_AttendancePermission != null)
                {
                    _AttendancePermission.Name = AttendancePermission.name;




                    _AttendancePermission.UpdateByID = AttendancePermission.TransactionUserId;
                    _AttendancePermission.LastUpdateDate = DateTime.Now;

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

        public string Delete(int AttendancePermissionId)
        {
            try
            {
                var _AttendancePermission = _context.HrAttendancePermission.FirstOrDefault(n => n.Id == AttendancePermissionId);
                if (_AttendancePermission != null)
                {
                    _context.HrAttendancePermission.Remove(_AttendancePermission);
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

        public List<HrAttendancePermissionGetVM> GetAll()
            => _context.HrAttendancePermission.Select(n => new HrAttendancePermissionGetVM
            {
                Id = n.Id,
                name = n.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();

        public HrAttendancePermissionGetVM GetById(int AttendancePermissionId)
            => _context.HrAttendancePermission.Select(n => new HrAttendancePermissionGetVM
            {
                Id = n.Id,
                name = n.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).FirstOrDefault(n => n.Id == AttendancePermissionId);

    }
}
