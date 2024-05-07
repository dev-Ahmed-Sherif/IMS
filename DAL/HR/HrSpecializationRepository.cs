using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DAL.HR
{
    public class HrSpecializationRepository
    {

        private AppDbContext _context;
        public HrSpecializationRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrSpecializationVM Specialization)
        {
            try
            {
                var _Specialization = new HrSpecialization()
                {
                    Name = Specialization.name,
                    QualificationId = Specialization.QualificationId,

                    CreatedByID = Specialization.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrSpecialization.Add(_Specialization);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrSpecializationVM Specialization)
        {
            try
            {
                var _Specialization = _context.HrSpecialization.FirstOrDefault(n => n.Id == Specialization.Id);
                if (_Specialization != null)
                {
                    _Specialization.Name = Specialization.name;
                    _Specialization.QualificationId = Specialization.QualificationId;


                    _Specialization.UpdateByID = Specialization.TransactionUserId;

                    _Specialization.LastUpdateDate = DateTime.Now;

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

        public string Delete(int SpecializationId)
        {
            try
            {
                var _Specialization = _context.HrSpecialization.FirstOrDefault(n => n.Id == SpecializationId);
                if (_Specialization != null)
                {
                    _context.HrSpecialization.Remove(_Specialization);
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


        public List<HrSpecializationGetVM> GetAll() => _context.HrSpecialization.Select(n => new HrSpecializationGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, QualificationId = n.QualificationId, QualificationName = n.Qualification.Name }).ToList();
        public HrSpecializationGetVM GetById(int SpecializationId) => _context.HrSpecialization.Select(n => new HrSpecializationGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, QualificationId = n.QualificationId, QualificationName = n.Qualification.Name }).FirstOrDefault(n => n.Id == SpecializationId);

    }
}
