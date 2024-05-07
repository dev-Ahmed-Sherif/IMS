using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrAttendanceMachineRepository
    {

        private AppDbContext _context;
        public HrAttendanceMachineRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrAttendanceMachineVM AttendanceMachine)
        {
            try
            {
                var _AttendanceMachine = new HrAttendanceMachine()
                {
                    Name = AttendanceMachine.name,
                    Serial = AttendanceMachine.Serial,


                    CreatedByID = AttendanceMachine.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrAttendanceMachine.Add(_AttendanceMachine);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrAttendanceMachineVM AttendanceMachine)
        {
            try
            {
                var _AttendanceMachine = _context.HrAttendanceMachine.FirstOrDefault(n => n.Id == AttendanceMachine.Id);
                if (_AttendanceMachine != null)
                {
                    _AttendanceMachine.Name = AttendanceMachine.name;
                    _AttendanceMachine.Serial = AttendanceMachine.Serial;


                    _AttendanceMachine.UpdateByID = AttendanceMachine.TransactionUserId;
                    _AttendanceMachine.LastUpdateDate = DateTime.Now;

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

        public string Delete(int AttendanceMachineId)
        {
            try
            {
                var _AttendanceMachine = _context.HrAttendanceMachine.FirstOrDefault(n => n.Id == AttendanceMachineId);
                if (_AttendanceMachine != null)
                {
                    _context.HrAttendanceMachine.Remove(_AttendanceMachine);
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


        public List<HrAttendanceMachineGetVM> GetAll()
            => _context.HrAttendanceMachine.Select(n => new HrAttendanceMachineGetVM
            {
                Id = n.Id,
                name = n.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                Serial = n.Serial
            }).ToList();

        public HrAttendanceMachineGetVM GetById(int AttendanceMachineId)
            => _context.HrAttendanceMachine.Select(n => new HrAttendanceMachineGetVM
            {
                Id = n.Id,
                name = n.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                Serial = n.Serial
            }).FirstOrDefault(n => n.Id == AttendanceMachineId);

    }
}
