using DAL.Helpers;
using Entities.Enums;
using Entities.Models;
using Entities.Models.HR;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DAL
{
    public class HrEmployeeQualificationRepository
    {

        private AppDbContext _context;
        public HrEmployeeQualificationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Add(HrEmployeeQualificationVM EmployeeQualification)
        {

            string fileName = await FileHelper.UploadFile(EmployeeQualification.File, FileHelper.GetDirectoryName(DirectoriesEnum.HrEmployeeQualification));
            var _EmployeeQualification = new HrEmployeeQualification()
            {
                Date = EmployeeQualification.Date,
                Attachment = fileName,
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
        public async Task<string> Update(HrEmployeeQualificationVM EmployeeQualification)
        {
            try
            {
                var _EmployeeQualification = _context.HrEmployeeQualification.FirstOrDefault(n => n.Id == EmployeeQualification.Id);
                if (_EmployeeQualification != null)
                {
                    _EmployeeQualification.Date = EmployeeQualification.Date;
                    _EmployeeQualification.Attachment = await FileHelper.UploadFile(EmployeeQualification.File, FileHelper.GetDirectoryName(DirectoriesEnum.HrEmployeeQualification));
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
        public List<HrEmployeeQualificationGetSearch> Search(HrEmployeeQualificationSearch searchModel)
        {
            var query = _context.HrEmployeeQualification.AsQueryable();
            if (!string.IsNullOrEmpty(searchModel.Attachment))
            {
                query = query.Where(p => p.Attachment.Contains(searchModel.Attachment));
            }
            if (!string.IsNullOrEmpty(searchModel.QualificationId))
            {
                query = query.Where(p => p.QualificationId.ToString().Contains(searchModel.QualificationId));
            }
            if (!string.IsNullOrEmpty(searchModel.QualificationLevelId))
            {
                query = query.Where(p => p.QualificationLevelId.ToString().Contains(searchModel.QualificationLevelId));
            }
            if (!string.IsNullOrEmpty(searchModel.SpecializationId))
            {
                query = query.Where(p => p.SpecializationId.ToString().Contains(searchModel.SpecializationId));
            }
            if (!string.IsNullOrEmpty(searchModel.EmployeeId))
            {
                query = query.Where(p => p.EmployeeId.ToString().Contains(searchModel.EmployeeId));
            }
            //if (!string.IsNullOrEmpty(searchModel.TransactionUserId))
            //{
            //    query = query.Where(p => p.TransactionUserId.Tostring().Contains(searchModel.TransactionUserId));
            //}

            if (!string.IsNullOrEmpty(searchModel.CreateUserName))
            {
                query = query.Where(p => p.CreatedBy.Name.Contains(searchModel.CreateUserName));
            }
            if (!string.IsNullOrEmpty(searchModel.UpdateUserName))
            {
                query = query.Where(p => p.UpdateBy.Name.Contains(searchModel.UpdateUserName));
            }
            if (!string.IsNullOrEmpty(searchModel.QualificationName))
            {
                query = query.Where(p => p.Qualification.Name.Contains(searchModel.QualificationName));
            }
            if (!string.IsNullOrEmpty(searchModel.QualificationLeveName))
            {
                query = query.Where(p => p.QualificationLevel.Name.Contains(searchModel.QualificationLeveName));
            }
            if (!string.IsNullOrEmpty(searchModel.SpecializationName))
            {
                query = query.Where(p => p.Specialization.Name.Contains(searchModel.SpecializationName));
            }
            if (!string.IsNullOrEmpty(searchModel.EmployeeName))
            {
                query = query.Where(p => p.Employee.Name.Contains(searchModel.EmployeeName));
            }

            if (!string.IsNullOrEmpty(searchModel.EmployeeId))
            {
                query = query.Where(p => p.EmployeeId.ToString().Contains(searchModel.EmployeeId));
            }
            if (searchModel.Date.HasValue)
            {
                query = query.Where(p => p.Date >= searchModel.Date.Value.Date);
            }



            var result = query.Select(n => new HrEmployeeQualificationGetSearch
            {
                Id = n.Id,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                //ShortDate = n.Date.ToString("dd/MM/yyyy"),
                Attachment = n.Attachment,
                QualificationId = n.QualificationId,
                QualificationName = n.Qualification.Name,
                QualificationLevelId = n.QualificationLevelId,
                QualificationLeveName = n.QualificationLevel.Name,
                SpecializationId = n.SpecializationId,
                SpecializationName = n.Specialization.Name,
                EmployeeId = n.EmployeeId,
                EmployeeName = n.Employee.Name,
                ShortDate = n.Date.ToString("dd/MM/yyyy"),
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                Section = n.Employee.Section.Name,


            }).ToList();

            return result;
        }
    }
}
