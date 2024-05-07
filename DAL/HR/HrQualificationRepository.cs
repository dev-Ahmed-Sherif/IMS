using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DAL.HR
{
    public class HrQualificationRepository
    {

        private AppDbContext _context;
        public HrQualificationRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrQualificationVM Qualification)
        {
            try
            {
                var _Qualification = new HrQualification()
                {
                    Name = Qualification.name,
                    QualitativeGroupId = Qualification.QualitativeGroupId,

                    CreatedByID = Qualification.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrQualification.Add(_Qualification);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrQualificationVM Qualification)
        {
            try
            {
                var _Qualification = _context.HrQualification.FirstOrDefault(n => n.Id == Qualification.Id);
                if (_Qualification != null)
                {
                    _Qualification.Name = Qualification.name;
                    _Qualification.QualitativeGroupId = Qualification.QualitativeGroupId;


                    _Qualification.UpdateByID = Qualification.TransactionUserId;

                    _Qualification.LastUpdateDate = DateTime.Now;

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

        public string Delete(int QualificationId)
        {
            try
            {
                var _Qualification = _context.HrQualification.FirstOrDefault(n => n.Id == QualificationId);
                if (_Qualification != null)
                {
                    _context.HrQualification.Remove(_Qualification);
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


        public List<HrQualificationGetVM> GetAll() => _context.HrQualification.Select(n => new HrQualificationGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, QualitativeGroupId = n.QualitativeGroupId, QualitativeGroupName = n.QualitativeGroup.Name }).ToList();
        public HrQualificationGetVM GetById(int QualificationId) => _context.HrQualification.Select(n => new HrQualificationGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, QualitativeGroupId = n.QualitativeGroupId, QualitativeGroupName = n.QualitativeGroup.Name }).FirstOrDefault(n => n.Id == QualificationId);

    }
}
