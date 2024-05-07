using Entities.Models;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DAL
{
    public class HrEmployeeAppraisalRepository
    {

        private AppDbContext _context;
        public HrEmployeeAppraisalRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrEmployeeAppraisalVM EmployeeAppraisal)
        {
            try
            {
                var _EmployeeAppraisal = new HrEmployeeAppraisal()
                {
                    Appraisal = EmployeeAppraisal.Appraisal,
                    Date = EmployeeAppraisal.Date,
                    EmployeeId = EmployeeAppraisal.EmployeeId,
                    Attachment = EmployeeAppraisal.Attachment,

                    CreatedByID = EmployeeAppraisal.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrEmployeeAppraisal.Add(_EmployeeAppraisal);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrEmployeeAppraisalVM EmployeeAppraisal)
        {
            try
            {
                var _EmployeeAppraisal = _context.HrEmployeeAppraisal.FirstOrDefault(n => n.Id == EmployeeAppraisal.Id);
                if (_EmployeeAppraisal != null)
                {
                    _EmployeeAppraisal.Appraisal = EmployeeAppraisal.Appraisal;
                    _EmployeeAppraisal.Date = EmployeeAppraisal.Date;
                    _EmployeeAppraisal.EmployeeId = EmployeeAppraisal.EmployeeId;
                    _EmployeeAppraisal.Attachment = EmployeeAppraisal.Attachment;

                    _EmployeeAppraisal.UpdateByID = EmployeeAppraisal.TransactionUserId;

                    _EmployeeAppraisal.LastUpdateDate = DateTime.Now;

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






            var results = query.Select(p => new HrEmployeeAppraisalGetSearchVM
            {
                Id = p.Id,
                Date = p.Date,
                Appraisal = p.Appraisal,
                ShortDate = p.Date.ToString("dd/MM/yyyy"),

                EmployeeId = p.EmployeeId,

                EmployeeName = p.Employee.Name,


            }).ToList();


            return results;


        }
    }
}
