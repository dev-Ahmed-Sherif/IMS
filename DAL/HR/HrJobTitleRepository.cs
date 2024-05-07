using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrJobTitleRepository
    {

        private AppDbContext _context;
        public HrJobTitleRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrJobTitleVM JobTitle)
        {
            try
            {
                var _JobTitle = new HrJobTitle()
                {
                    Name = JobTitle.name,
                    CreatedByID = JobTitle.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrJobTitle.Add(_JobTitle);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrJobTitleVM JobTitle)
        {
            try
            {
                var _JobTitle = _context.HrJobTitle.FirstOrDefault(n => n.Id == JobTitle.Id);
                if (_JobTitle != null)
                {
                    _JobTitle.Name = JobTitle.name;

                    _JobTitle.UpdateByID = JobTitle.TransactionUserId;

                    _JobTitle.LastUpdateDate = DateTime.Now;

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

        public string Delete(int ID)
        {
            try
            {
                var _JobTitle = _context.HrJobTitle.FirstOrDefault(n => n.Id == ID);
                if (_JobTitle != null)
                {
                    _context.HrJobTitle.Remove(_JobTitle);
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


        public List<HrJobTitleGetVM> GetAll() => _context.HrJobTitle.Select(n => new HrJobTitleGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public HrJobTitleGetVM GetById(int JobTitleId) => _context.HrJobTitle.Select(n => new HrJobTitleGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).FirstOrDefault(n => n.Id == JobTitleId);

    }
}
