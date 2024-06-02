using DAL.Helpers;
using Entities.Enums;
using Entities.Models;
using Entities.Models.STR.Product;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DAL
{
    public class HrEmployeeAppraisalRepository
    {

        private AppDbContext _context;
        public HrEmployeeAppraisalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Add(HrEmployeeAppraisalVM EmployeeAppraisal)
        {
            string fileName = await FileHelper.UploadFile(EmployeeAppraisal.File, FileHelper.GetDirectoryName(DirectoriesEnum.HrEmployeeAppraisal));
            var _EmployeeAppraisal = new HrEmployeeAppraisal()
                {
                    Appraisal = EmployeeAppraisal.Appraisal,
                    Date = EmployeeAppraisal.Date,
                    EmployeeId = EmployeeAppraisal.EmployeeId,
                    Attachment = fileName,

                    CreatedByID = EmployeeAppraisal.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrEmployeeAppraisal.Add(_EmployeeAppraisal);
                _context.SaveChanges();
                return "Succeeded";
           
        }
        public async Task<string> Update(HrEmployeeAppraisalVM EmployeeAppraisal)
        {
           
                var _EmployeeAppraisal = _context.HrEmployeeAppraisal.Single(n => n.Id == EmployeeAppraisal.Id);
              
                    _EmployeeAppraisal.Appraisal = EmployeeAppraisal.Appraisal;
                    _EmployeeAppraisal.Date = EmployeeAppraisal.Date;
                    _EmployeeAppraisal.EmployeeId = EmployeeAppraisal.EmployeeId;
                    _EmployeeAppraisal.Attachment = await FileHelper.UploadFile(EmployeeAppraisal.File, FileHelper.GetDirectoryName(DirectoriesEnum.HrEmployeeAppraisal));

                    _EmployeeAppraisal.UpdateByID = EmployeeAppraisal.TransactionUserId;

                    _EmployeeAppraisal.LastUpdateDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
           
          
        }

        public string Delete(int EmployeeAppraisalId)
        {
            try
            {
                var _EmployeeAppraisal = _context.HrEmployeeAppraisal.FirstOrDefault(n => n.Id == EmployeeAppraisalId);
                if (_EmployeeAppraisal != null)
                {
                    _context.HrEmployeeAppraisal.Remove(_EmployeeAppraisal);
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


        public List<HrEmployeeAppraisalGetVM> GetAll()
            => _context.HrEmployeeAppraisal.Select(n => new HrEmployeeAppraisalGetVM
            {
                Id = n.Id,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                EmployeeId = n.EmployeeId,
                Date = n.Date,
                EmployeeName = n.Employee.Name,
                Appraisal = n.Appraisal,
                Attachment = n.Attachment
            }).ToList();
        public HrEmployeeAppraisalGetVM GetById(int EmployeeAppraisalId)
            => _context.HrEmployeeAppraisal.Select(n => new HrEmployeeAppraisalGetVM
            {
                Id = n.Id,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                EmployeeId = n.EmployeeId,
                Date = n.Date,
                EmployeeName = n.Employee.Name,
                Appraisal = n.Appraisal,
                Attachment = n.Attachment
            }).FirstOrDefault(n => n.Id == EmployeeAppraisalId);
        public List<HrEmployeeAppraisalGetSearchVM> Search(searchEmpAppr searchModel)
        {

            var query = _context.HrEmployeeAppraisal.AsQueryable();
            if (searchModel.Id.HasValue)
            {
                query = query.Where(p => p.Id == searchModel.Id);
            }
            if (searchModel.EmployeeId.HasValue)
            {
                query = query.Where(p => p.EmployeeId == searchModel.EmployeeId);
            }
            




            if (searchModel.Appraisal.HasValue)
            {
                query = query.Where(p => p.Appraisal == searchModel.Appraisal);
            }

            if (searchModel.Date.HasValue)
            {
                query = query.Where(p => p.Date.Date >= searchModel.Date.Value.Date);
            }
            //if (searchModel.SectionId.HasValue)
            //{
            //    query = query.Where(p => p.Appraisal == searchModel.SectionId);
            //}



            //// Include Employee navigation property
            //query = query.Include(p => p.Employee);

            //// Include Section navigation property within Employee
            //query = query.Include(p => p.Employee.Section);






            var results = query.Select(p => new HrEmployeeAppraisalGetSearchVM
            {
                Id = p.Id,
                Date = p.Date,
                Appraisal = p.Appraisal,
                ShortDate = p.Date.ToString("dd/MM/yyyy"),

                EmployeeId = p.EmployeeId,
                Birth_Date = p.Employee.Birth_Date,
                QualificationLevelId = p.Employee.QualificationLevelId,
                   




                EmployeeName = p.Employee.Name,
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                Section = p.Employee.Section.Name,

            }).ToList();


            return results;


        }
    }
}
