using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrEmployeeFinancialDegreeRepository
    {

        private AppDbContext _context;
        public HrEmployeeFinancialDegreeRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrEmployeeFinancialDegreeVM EmployeeFinancialDegree)
        {
            try
            {
                var _EmployeeFinancialDegree = new HrEmployeeFinancialDegree()
                {
                    EmployeeId = EmployeeFinancialDegree.EmployeeId,
                    FinancialDegreeId = EmployeeFinancialDegree.FinancialDegreeId,
                    FinancialDegreeDate = EmployeeFinancialDegree.FinancialDegreeDate,
                    CreatedByID = EmployeeFinancialDegree.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrEmployeeFinancialDegree.Add(_EmployeeFinancialDegree);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrEmployeeFinancialDegreeVM EmployeeFinancialDegree)
        {
            try
            {
                var _EmployeeFinancialDegree = _context.HrEmployeeFinancialDegree.FirstOrDefault(n => n.Id == EmployeeFinancialDegree.Id);
                if (_EmployeeFinancialDegree != null)
                {
                    _EmployeeFinancialDegree.EmployeeId = EmployeeFinancialDegree.EmployeeId;
                    _EmployeeFinancialDegree.FinancialDegreeDate = EmployeeFinancialDegree.FinancialDegreeDate;
                    _EmployeeFinancialDegree.FinancialDegreeId = EmployeeFinancialDegree.FinancialDegreeId;

                    _EmployeeFinancialDegree.UpdateByID = EmployeeFinancialDegree.TransactionUserId;

                    _EmployeeFinancialDegree.LastUpdateDate = DateTime.Now;

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

        public string Delete(int EmployeeFinancialDegreeId)
        {
            try
            {
                var _EmployeeFinancialDegree = _context.HrEmployeeFinancialDegree.FirstOrDefault(n => n.Id == EmployeeFinancialDegreeId);
                if (_EmployeeFinancialDegree != null)
                {
                    _context.HrEmployeeFinancialDegree.Remove(_EmployeeFinancialDegree);
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

      //  public HrEmployeeFinancialDegreeGetVM GetById(int EmployeeFinancialDegreeId) => _context.HrEmployeeFinancialDegree.Select(n => new HrEmployeeFinancialDegreeGetVM { Id = n.Id, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, FinancialDegreeId = n.FinancialDegreeId, FinancialDegreeDate = n.FinancialDegreeDate, FinancialDegreeName = n.FinancialDegree.Name, EmployeeId = n.EmployeeId, EmployeeCode = n.Employee.Code, EmployeeName = n.Employee.Name }).FirstOrDefault(n => n.Id == EmployeeFinancialDegreeId);
        public HrEmployeeFinancialDegreeGetVM GetById(int EmployeeFinancialDegreeId) => _context.HrEmployeeFinancialDegree.Select(n => new HrEmployeeFinancialDegreeGetVM { Id = n.Id, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, FinancialDegreeId = n.FinancialDegreeId, FinancialDegreeDate = n.FinancialDegreeDate, FinancialDegreeName = n.FinancialDegree.Name, EmployeeId = n.EmployeeId, EmployeeCode = n.Employee.Code, EmployeeName = n.Employee.Name }).FirstOrDefault(n => n.Id == EmployeeFinancialDegreeId);
        //public List<HrEmployeeFinancialDegreeGetSearchVM> Search(HrEmployeeFinancialDegreeSearch searchModel)
        //{
        //    var query = _context.HrEmployeeFinancialDegree.AsQueryable();

        //    if (searchModel.FinancialDegreeId.HasValue)
        //    {
        //        query = query.Where(p => p.FinancialDegreeId==searchModel.FinancialDegreeId);
        //    }
        //    if (searchModel.EmployeeId.HasValue)
        //    {
        //        query = query.Where(p => p.EmployeeId == searchModel.EmployeeId);
        //    }
         
        //    if (!string.IsNullOrEmpty(searchModel.FinancialDegreeName))
        //    {
        //        query = query.Where(p => p.FinancialDegree.Name.Contains(searchModel.FinancialDegreeName));

        //    }
        //    if (searchModel.QualitativeGroupId.HasValue)
        //    {
        //        query = query.Where(p => p.Employee.Qualification.QualitativeGroup.Id==searchModel.QualitativeGroupId);

        //    }


        //    if (searchModel.FinancialDegreeDate.HasValue)
        //    {
        //        query = query.Where(p => p.FinancialDegreeDate <= searchModel.FinancialDegreeDate.Value.Date);

        //    }
        //    if (!string.IsNullOrEmpty(searchModel.Gender))
        //    {
        //        query = query.Where(p => p.Employee.Gender.Contains(searchModel.Gender));
        //    }
        //    var result = query.Select(n => new HrEmployeeFinancialDegreeGetSearchVM
        //    {
        //        Id = n.Id,
        //        CreateUserName = n.CreatedBy.Name,
        //        TransactionUserId = n.CreatedBy.Id,
        //        FinancialDegreeId = n.FinancialDegreeId,
        //        FinancialDegreeDate = n.FinancialDegreeDate,
        //        FinancialDegreeName = n.FinancialDegree.Name,
        //        EmployeeId = n.EmployeeId,
        //        Gender=n.Employee.Gender,
        //       QualitativeGroupId=n.Employee.Qualification.QualitativeGroup.Id,
        //        QualitativeGroupName = n.Employee.Qualification.QualitativeGroup.Name,
        //        EmployeeName =n.Employee.Name,
        //        EmployeeCode = n.Employee.Code,
        //        FinancialDegreeShortDate = n.FinancialDegreeDate.ToString("dd/MM/yyyy"),
        //        ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
        //        //Section =n.

        //    }).ToList();




        //    return result;

        //}
        public List<HrEmployeeFinancialDegreeGetSearchVM> Search(HrEmployeeFinancialDegreeSearch searchModel)
        {
            var query = _context.HrEmployeeFinancialDegree.AsQueryable();

            if (searchModel.FinancialDegreeId.HasValue)
            {
                query = query.Where(p => p.FinancialDegreeId == searchModel.FinancialDegreeId);
            }
            if (searchModel.EmployeeId.HasValue)
            {
                query = query.Where(p => p.EmployeeId == searchModel.EmployeeId);
            }

            if (!string.IsNullOrEmpty(searchModel.FinancialDegreeName))
            {
                query = query.Where(p => p.FinancialDegree.Name.Contains(searchModel.FinancialDegreeName));
            }

            if (searchModel.FinancialDegreeDate.HasValue)
            {
                query = query.Where(p => p.FinancialDegreeDate <= searchModel.FinancialDegreeDate.Value.Date);
            }

       

            if (!string.IsNullOrEmpty(searchModel.EmployeeName))
            {
                query = query.Where(p => p.Employee.Name.ToString().Equals(searchModel.EmployeeId));
            }



            //var result = query.Select(n => new HrEmployeeFinancialDegreeGetSearchVM
            //{
            //    query = query.Where(p => p.Employee.Gender.Contains(searchModel.Gender));
            //}
          

            var result = query.GroupBy(p => new { p.FinancialDegreeId, 
                p.Employee.Qualification.QualitativeGroupId,
                p.FinancialDegree.Name,
                
                QualitativeGroup = p.Employee.Qualification.QualitativeGroup.Name, 
            empGender=p.Employee.Gender,
            })
                .Select(g => new HrEmployeeFinancialDegreeGetSearchVM
                {
                    FinancialDegreeId = g.Key.FinancialDegreeId,
                    FinancialDegreeName = g.Key.Name,
                    QualitativeGroupName=g.Key.QualitativeGroup,
                    EmployeeCount = g.Count()
                })
                .ToList();

            return result;
        }
    }

}
