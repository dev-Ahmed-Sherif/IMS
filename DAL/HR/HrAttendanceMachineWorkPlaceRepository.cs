using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrAttendanceMachineWorkPlaceRepository
    {

        private AppDbContext _context;
        public HrAttendanceMachineWorkPlaceRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrAttendanceMachineWorkPlaceVM AttendanceMachineWorkPlace)
        {
            try
            {
                var _AttendanceMachineWorkPlace = new HrAttendanceMachineWorkPlace()
                {
                    Name = AttendanceMachineWorkPlace.name,
                    Date = AttendanceMachineWorkPlace.Date,
                    AttendanceMachineId = AttendanceMachineWorkPlace.AttendanceMachineId,
                    WorkPlaceId = AttendanceMachineWorkPlace.WorkPlaceId,


                    CreatedByID = AttendanceMachineWorkPlace.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrAttendanceMachineWorkPlace.Add(_AttendanceMachineWorkPlace);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrAttendanceMachineWorkPlaceVM AttendanceMachineWorkPlace)
        {
            try
            {
                var _AttendanceMachineWorkPlace = _context.HrAttendanceMachineWorkPlace.FirstOrDefault(n => n.Id == AttendanceMachineWorkPlace.Id);
                if (_AttendanceMachineWorkPlace != null)
                {
                    _AttendanceMachineWorkPlace.Name = AttendanceMachineWorkPlace.name;
                    _AttendanceMachineWorkPlace.Date = AttendanceMachineWorkPlace.Date;
                    _AttendanceMachineWorkPlace.AttendanceMachineId = AttendanceMachineWorkPlace.AttendanceMachineId;
                    _AttendanceMachineWorkPlace.WorkPlaceId = AttendanceMachineWorkPlace.WorkPlaceId;




                    _AttendanceMachineWorkPlace.UpdateByID = AttendanceMachineWorkPlace.TransactionUserId;
                    _AttendanceMachineWorkPlace.LastUpdateDate = DateTime.Now;

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

        public string Delete(int AttendanceMachineWorkPlaceId)
        {
            try
            {
                var _AttendanceMachineWorkPlace = _context.HrAttendanceMachineWorkPlace.FirstOrDefault(n => n.Id == AttendanceMachineWorkPlaceId);
                if (_AttendanceMachineWorkPlace != null)
                {
                    _context.HrAttendanceMachineWorkPlace.Remove(_AttendanceMachineWorkPlace);
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


        public List<HrAttendanceMachineWorkPlaceGetVM> GetAll()
            => _context.HrAttendanceMachineWorkPlace.Select(n => new HrAttendanceMachineWorkPlaceGetVM
            {
                Id = n.Id,
                name = n.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                Date = n.Date,
                AttendanceMachineId = n.AttendanceMachineId,
                AttendanceMachineName = n.AttendanceMachine.Name,
                WorkPlaceId = n.WorkPlaceId,
                WorkPlaceName = n.WorkPlace.Name
            }).ToList();

        public HrAttendanceMachineWorkPlaceGetVM GetById(int AttendanceMachineWorkPlaceId)
            => _context.HrAttendanceMachineWorkPlace.Select(n => new HrAttendanceMachineWorkPlaceGetVM
            {
                Id = n.Id,
                name = n.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                Date = n.Date,
                AttendanceMachineId = n.AttendanceMachineId,
                AttendanceMachineName = n.AttendanceMachine.Name,
                WorkPlaceId = n.WorkPlaceId,
                WorkPlaceName = n.WorkPlace.Name
            }).FirstOrDefault(n => n.Id == AttendanceMachineWorkPlaceId);

    }
}
