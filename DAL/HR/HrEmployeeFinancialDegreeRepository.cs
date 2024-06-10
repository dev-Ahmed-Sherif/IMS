using Entities.Models.HR;
using Entities.ReportViewModels;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using static Entities.ReportViewModels.HrEmployeeQualitativeGroupVM;

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
        public List<HrEmployeeFinancialDegreeGetVM> GetAll() => _context.HrEmployeeFinancialDegree.Select(n => new HrEmployeeFinancialDegreeGetVM { Id = n.Id, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, FinancialDegreeId = n.FinancialDegreeId, FinancialDegreeDate = n.FinancialDegreeDate, FinancialDegreeName = n.FinancialDegree.Name, EmployeeId = n.EmployeeId, EmployeeCode = n.Employee.Code, EmployeeName = n.Employee.Name }).ToList();

        //  public HrEmployeeFinancialDegreeGetVM GetById(int EmployeeFinancialDegreeId) => _context.HrEmployeeFinancialDegree.Select(n => new HrEmployeeFinancialDegreeGetVM { Id = n.Id, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, FinancialDegreeId = n.FinancialDegreeId, FinancialDegreeDate = n.FinancialDegreeDate, FinancialDegreeName = n.FinancialDegree.Name, EmployeeId = n.EmployeeId, EmployeeCode = n.Employee.Code, EmployeeName = n.Employee.Name }).FirstOrDefault(n => n.Id == EmployeeFinancialDegreeId);
        public HrEmployeeFinancialDegreeGetVM GetById(int EmployeeFinancialDegreeId) => _context.HrEmployeeFinancialDegree.Select(n => new HrEmployeeFinancialDegreeGetVM { Id = n.Id, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, FinancialDegreeId = n.FinancialDegreeId, FinancialDegreeDate = n.FinancialDegreeDate, FinancialDegreeName = n.FinancialDegree.Name, EmployeeId = n.EmployeeId, EmployeeCode = n.Employee.Code, EmployeeName = n.Employee.Name }).FirstOrDefault(n => n.Id == EmployeeFinancialDegreeId);
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
            if (searchModel.QualitativeGroupId.HasValue)
            {
                query = query.Where(p => p.Employee.Qualification.QualitativeGroup.Id == searchModel.QualitativeGroupId);

            }


            if (searchModel.FinancialDegreeDate.HasValue)
            {
                query = query.Where(p => p.FinancialDegreeDate <= searchModel.FinancialDegreeDate.Value.Date);

            }
            if (!string.IsNullOrEmpty(searchModel.Gender))
            {
                query = query.Where(p => p.Employee.Gender.Contains(searchModel.Gender));
            }
            var result = query.Select(n => new HrEmployeeFinancialDegreeGetSearchVM
            {
                Id = n.Id,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                FinancialDegreeId = n.FinancialDegreeId,
                FinancialDegreeDate = n.FinancialDegreeDate,
                FinancialDegreeName = n.FinancialDegree.Name,
                EmployeeId = n.EmployeeId,
                Gender = n.Employee.Gender,
                QualitativeGroupId = n.Employee.Qualification.QualitativeGroup.Id,
                QualitativeGroupName = n.Employee.Qualification.QualitativeGroup.Name,
                EmployeeName = n.Employee.Name,
                EmployeeCode = n.Employee.Code,
                FinancialDegreeShortDate = n.FinancialDegreeDate.ToString("dd/MM/yyyy"),
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                //Section =n.

            }).ToList();




            return result;

        }
        //public List<HrEmployeeFinancialDegreeGetSearchVM> Searchgroup(HrEmployeeFinancialDegreeSearch searchModel)
        //{
        //    var query = _context.HrEmployee.AsQueryable();

        //    if (searchModel.FinancialDegreeId.HasValue)
        //    {
        //        query = query.Where(p => p.FinancialDegreeId == searchModel.FinancialDegreeId);
        //    }
        //    if (searchModel.EmployeeId.HasValue)
        //    {
        //        query = query.Where(p => p.Id == searchModel.EmployeeId);
        //    }

        //    if (!string.IsNullOrEmpty(searchModel.FinancialDegreeName))
        //    {
        //        query = query.Where(p => p.FinancialDegree.Name.Contains(searchModel.FinancialDegreeName));
        //    }

        //    if (searchModel.FinancialDegreeDate.HasValue)
        //    {
        //        query = query.Where(p => p.FinancialDegreeDate <= searchModel.FinancialDegreeDate.Value.Date);
        //    }



        //    if (!string.IsNullOrEmpty(searchModel.EmployeeName))
        //    {
        //        query = query.Where(p => p.Name.ToString().Equals(searchModel.EmployeeId));
        //    }



        //    //var result = query.Select(n => new HrEmployeeFinancialDegreeGetSearchVM
        //    //{
        //    //    query = query.Where(p => p.Employee.Gender.Contains(searchModel.Gender));
        //    //}


        //    var result = query.GroupBy(p => new { p.FinancialDegreeId,
        //        p.Qualification.QualitativeGroupId,
        //        p.FinancialDegree.Name,

        //        QualitativeGroup = p.Qualification.QualitativeGroup.Name,
        //        empGender = p.Gender,

        //    })
        //        .Select(g => new HrEmployeeFinancialDegreeGetSearchVM
        //        {
        //            FinancialDegreeId = g.Key.FinancialDegreeId,
        //            FinancialDegreeName = g.Key.Name,
        //            QualitativeGroupId = g.Key.QualitativeGroupId,
        //            QualitativeGroupName = g.First().Qualification.QualitativeGroup.Name,
        //            //QualitativeGroupName = g.Key.QualitativeGroup,
        //            EmployeeCount = g.Count(),
        //           TotalEmployeeCount =query.Count(),
        //        })
        //        .ToList();

        //    return result;
        //}
        public List<HrEmployeeQualitativeGroupVM> Searchgroup(HrEmployeeFinancialDegreeSearch searchModel)
        {
            var hrEmployees = _context.HrEmployee.AsQueryable();

            if (searchModel.FinancialDegreeId.HasValue)
            {
                hrEmployees = hrEmployees.Where(p => p.FinancialDegreeId == searchModel.FinancialDegreeId);
            }
            if (searchModel.EmployeeId.HasValue)
            {
                hrEmployees = hrEmployees.Where(p => p.Id == searchModel.EmployeeId);
            }

            if (!string.IsNullOrEmpty(searchModel.FinancialDegreeName))
            {
                hrEmployees = hrEmployees.Where(p => p.FinancialDegree.Name.Contains(searchModel.FinancialDegreeName));
            }

            if (searchModel.FinancialDegreeDate.HasValue)
            {
                hrEmployees = hrEmployees.Where(p => p.FinancialDegreeDate <= searchModel.FinancialDegreeDate.Value.Date);
            }



            if (!string.IsNullOrEmpty(searchModel.EmployeeName))
            {
                hrEmployees = hrEmployees.Where(p => p.Name.ToString().Equals(searchModel.EmployeeId));
            }



            //var result = query.Select(n => new HrEmployeeFinancialDegreeGetSearchVM
            //{
            //    query = query.Where(p => p.Employee.Gender.Contains(searchModel.Gender));
            //}


            //var result = query.GroupBy(p => new
            //{
            //    p.FinancialDegreeId,
            //    p.Qualification.QualitativeGroupId,
            //    p.FinancialDegree.Name,

            //    QualitativeGroup = p.Qualification.QualitativeGroup.Name,
            //    empGender = p.Gender,

            //})

            HashSet<HrQualitativeGroup> qualitativeGroups = hrEmployees.Select(e => e.Qualification.QualitativeGroup).ToHashSet();
            List<HrEmployeeQualitativeGroupVM> resultGroups = qualitativeGroups.Select(e => new HrEmployeeQualitativeGroupVM
            {
                QualitativeGroupId = e.Id,
                QualitativeGroupName = e.Name,
            }).ToList();
            var qualifications = hrEmployees.Select(e => e.Qualification).ToHashSet();
            foreach (var qualification in qualifications)
            {
                foreach (var group in resultGroups)
                {
                    if (qualification.QualitativeGroupId.Equals(group.QualitativeGroupId))
                    {
                        foreach (var e in qualification.Employees)
                        {
                            if (group.EmployeesFinancialDegrees.Any(q => q.FinancialDegreeId == e.FinancialDegreeId)) continue;
                            group.EmployeesFinancialDegrees.Add(new EmployeesFinancialDegreesReportVM
                            {
                                FinancialDegreeId = e.FinancialDegreeId,
                                FinancialDegreeName = e.FinancialDegree.Name,
                                EmployeeCount = e.FinancialDegree.Employees.Count,
                            });
                        }
                    }
                    group.ReportDate = DateTime.Now.ToShortDateString();
                }
            }









            //foreach (var degree in degrees)
            //{
            //    foreach (var group in resultGroups)
            //    {
            //        group.EmployeesFinancialDegrees.Add(new EmployeesFinancialDegreesReportVM
            //        {
            //            FinancialDegreeId = degree.Id,
            //            FinancialDegreeName = degree.Name,
            //            EmployeeCount = degree.Employees.Count,
            //        });
            //        group.ReportDate = DateTime.Now.ToShortDateString();
            //    }
            //}
            //var qualifications = new HashSet<HrQualification>();
            //foreach (var qualification in qualitativeGroups.SelectMany(e => e.HrQualifications))
            //{
            //    qualifications.Add(qualification);
            //}
            //foreach (var employee in query)
            //{
            //    foreach (var group in resultGroups)
            //    {
            //        if (employee.FinancialDegreeId == group.fi)
            //        {
            //            resultGroups.Select(e => e.EmployeesFinancialDegrees).Append
            //        }
            //    }
            //}
            return resultGroups;
            //var result = query
            //.Take(5)
            //.Select(e => new HrEmployeeQualitativeGroupVM
            //{
            //    QualitativeGroupId = e.Qualification.QualitativeGroupId,
            //    QualitativeGroupName = e.Qualification.QualitativeGroup.Name,
            //    EmployeesFinancialDegrees = query.Select(i => new EmployeesFinancialDegreesReportVM
            //    {
            //        EmployeeCount = query.Count(),
            //        FinancialDegreeId = i.FinancialDegreeId,
            //        FinancialDegreeName = e.FinancialDegree.Name,
            //        ReportDate = DateTime.Now.ToShortDateString(),
            //    }).ToList()
            //})
            ////.Select(g => new HrEmployeeFinancialDegreeGetSearchVM
            ////{
            ////    FinancialDegreeId = g.Key.FinancialDegreeId,
            ////    FinancialDegreeName = g.Key.Name,
            ////    QualitativeGroupId = g.Key.QualitativeGroupId,
            ////    QualitativeGroupName = g.Key.QualitativeGroup,
            ////    EmployeeCount = g.Count(),
            ////    TotalEmployeeCount = query.Count(),
            ////})
            //.ToList();

            //return result;
        }
    }

}
