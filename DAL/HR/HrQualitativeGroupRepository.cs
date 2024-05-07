using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrQualitativeGroupRepository
    {

        private AppDbContext _context;
        public HrQualitativeGroupRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrQualitativeGroupVM QualitativeGroup)
        {
            try
            {
                var _QualitativeGroup = new HrQualitativeGroup()
                {
                    Name = QualitativeGroup.name,

                    CreatedByID = QualitativeGroup.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrQualitativeGroup.Add(_QualitativeGroup);

                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrQualitativeGroupVM QualitativeGroup)
        {
            try
            {
                var _QualitativeGroup = _context.HrQualitativeGroup.FirstOrDefault(n => n.Id == QualitativeGroup.Id);
                if (_QualitativeGroup != null)
                {
                    _QualitativeGroup.Name = QualitativeGroup.name;

                    _QualitativeGroup.UpdateByID = QualitativeGroup.TransactionUserId;

                    _QualitativeGroup.LastUpdateDate = DateTime.Now;

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

        public string Delete(int QualitativeGroupId)
        {
            try
            {
                var _QualitativeGroup = _context.HrQualitativeGroup.FirstOrDefault(n => n.Id == QualitativeGroupId);
                if (_QualitativeGroup != null)
                {
                    _context.HrQualitativeGroup.Remove(_QualitativeGroup);
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


        public List<HrQualitativeGroupGetVM> GetAll() => _context.HrQualitativeGroup.Select(n => new HrQualitativeGroupGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public HrQualitativeGroupGetVM GetById(int QualitativeGroupId) => _context.HrQualitativeGroup.Select(n => new HrQualitativeGroupGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).FirstOrDefault(n => n.Id == QualitativeGroupId);

    }
}
