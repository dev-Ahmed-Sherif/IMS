using Entities.Models.HR;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DAL
{
    public class HrEmployeeQualificationRepository
    {

        private AppDbContext _context;
        public HrEmployeeQualificationRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrEmployeeQualificationVM EmployeeQualification)
        {
            try
            {
                var _EmployeeQualification = new HrEmployeeQualification()
                {
                    Date = EmployeeQualification.Date,
                    Attachment = EmployeeQualification.Attachment,
                    QualificationId = EmployeeQualification.QualificationId,
                    QualificationLevelId = EmployeeQualification.QualificationLevelId,
                    SpecializationId = EmployeeQualification.SpecializationId,
                    EmployeeId = EmployeeQualification.EmployeeId,

                    CreatedByID = EmployeeQualification.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrEmployeeQualification.Add(_EmployeeQualification);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrEmployeeQualificationVM EmployeeQualification)
        {
            try
            {
                var _EmployeeQualification = _context.HrEmployeeQualification.FirstOrDefault(n => n.Id == EmployeeQualification.Id);
                if (_EmployeeQualification != null)
                {
                    _EmployeeQualification.Date = EmployeeQualification.Date;
                    _EmployeeQualification.Attachment = EmployeeQualification.Attachment;
                    _EmployeeQualification.QualificationId = EmployeeQualification.QualificationId;
                    _EmployeeQualification.QualificationLevelId = EmployeeQualification.QualificationLevelId;
                    _EmployeeQualification.SpecializationId = EmployeeQualification.SpecializationId;
                    _EmployeeQualification.EmployeeId = EmployeeQualification.EmployeeId;

                    _EmployeeQualification.UpdateByID = EmployeeQualification.TransactionUserId;
                    _EmployeeQualification.LastUpdateDate = DateTime.Now;

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

        public string Delete(int EmployeeQualificationId)
        {
            try
            {
                var _EmployeeQualification = _context.HrEmployeeQualification.FirstOrDefault(n => n.Id == EmployeeQualificationId);
                if (_EmployeeQualification != null)
                {
                    _context.HrEmployeeQualification.Remove(_EmployeeQualification);
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


        public List<HrEmployeeQualificationGetVM> GetAll() => _context.HrEmployeeQualification.Select(n => new HrEmployeeQualificationGetVM { Id = n.Id, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, Date = n.Date, Attachment = n.Attachment, QualificationId = n.QualificationId, QualificationName = n.Qualification.Name, QualificationLevelId = n.QualificationLevelId, QualificationLeveName = n.QualificationLevel.Name, SpecializationId = n.SpecializationId, SpecializationName = n.Specialization.Name, EmployeeId = n.EmployeeId, EmployeeName = n.Employee.Name }).ToList();
        public HrEmployeeQualificationGetVM GetById(int EmployeeQualificationId) => _context.HrEmployeeQualification.Select(n => new HrEmployeeQualificationGetVM { Id = n.Id, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, Date = n.Date, Attachment = n.Attachment, QualificationId = n.QualificationId, QualificationName = n.Qualification.Name, QualificationLevelId = n.QualificationLevelId, QualificationLeveName = n.QualificationLevel.Name, SpecializationId = n.SpecializationId, SpecializationName = n.Specialization.Name, EmployeeId = n.EmployeeId, EmployeeName = n.Employee.Name }).FirstOrDefault(n => n.Id == EmployeeQualificationId);

    }
}
