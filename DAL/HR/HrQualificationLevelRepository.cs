using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrQualificationLevelRepository
    {

        private AppDbContext _context;
        public HrQualificationLevelRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrQualificationLevelVM QualificationLevel)
        {
            try
            {
                var _QualificationLevel = new HrQualificationLevel()
                {
                    Name = QualificationLevel.name,

                    CreatedByID = QualificationLevel.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrQualificationLevel.Add(_QualificationLevel);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrQualificationLevelVM QualificationLevel)
        {
            try
            {
                var _QualificationLevel = _context.HrQualificationLevel.FirstOrDefault(n => n.Id == QualificationLevel.Id);
                if (_QualificationLevel != null)
                {
                    _QualificationLevel.Name = QualificationLevel.name;

                    _QualificationLevel.UpdateByID = QualificationLevel.TransactionUserId;

                    _QualificationLevel.LastUpdateDate = DateTime.Now;

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

        public string Delete(int QualificationLevelId)
        {
            try
            {
                var _QualificationLevel = _context.HrQualificationLevel.FirstOrDefault(n => n.Id == QualificationLevelId);
                if (_QualificationLevel != null)
                {
                    _context.HrQualificationLevel.Remove(_QualificationLevel);
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


        public List<HrQualificationLevelGetVM> GetAll() => _context.HrQualificationLevel.Select(n => new HrQualificationLevelGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public HrQualificationLevelGetVM GetById(int QualificationLevelId) => _context.HrQualificationLevel.Select(n => new HrQualificationLevelGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).FirstOrDefault(n => n.Id == QualificationLevelId);

    }
}

