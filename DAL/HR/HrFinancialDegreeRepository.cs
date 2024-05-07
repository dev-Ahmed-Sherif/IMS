using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrFinancialDegreeRepository
    {

        private AppDbContext _context;
        public HrFinancialDegreeRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrFinancialDegreeVM FinancialDegree)
        {
            try
            {
                var _FinancialDegree = new HrFinancialDegree()
                {
                    Name = FinancialDegree.name,
                    NoYear = FinancialDegree.NoYear,

                    CreatedByID = FinancialDegree.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrFinancialDegree.Add(_FinancialDegree);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrFinancialDegreeVM FinancialDegree)
        {
            try
            {
                var _FinancialDegree = _context.HrFinancialDegree.FirstOrDefault(n => n.Id == FinancialDegree.Id);
                if (_FinancialDegree != null)
                {
                    _FinancialDegree.Name = FinancialDegree.name;
                    _FinancialDegree.NoYear = FinancialDegree.NoYear;


                    _FinancialDegree.UpdateByID = FinancialDegree.TransactionUserId;

                    _FinancialDegree.LastUpdateDate = DateTime.Now;

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

        public string Delete(int FinancialDegreeId)
        {
            try
            {
                var _FinancialDegree = _context.HrFinancialDegree.FirstOrDefault(n => n.Id == FinancialDegreeId);
                if (_FinancialDegree != null)
                {
                    _context.HrFinancialDegree.Remove(_FinancialDegree);
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


        public List<HrFinancialDegreeGetVM> GetAll() => _context.HrFinancialDegree.Select(n => new HrFinancialDegreeGetVM { Id = n.Id, name = n.Name, NoYear = n.NoYear, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public HrFinancialDegreeGetVM GetById(int FinancialDegreeId) => _context.HrFinancialDegree.Select(n => new HrFinancialDegreeGetVM { Id = n.Id, name = n.Name, NoYear = n.NoYear, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).FirstOrDefault(n => n.Id == FinancialDegreeId);

    }
}
