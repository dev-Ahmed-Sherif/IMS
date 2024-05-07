using Entities.Models;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class HrDisciplinaryRepository
    {

        private AppDbContext _context;
        public HrDisciplinaryRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrDisciplinaryVM Disciplinary)
        {
            try
            {
                var _Disciplinary = new HrDisciplinary()
                {
                    Name = Disciplinary.name,
                    CreatedByID = Disciplinary.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrDisciplinary.Add(_Disciplinary);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrDisciplinaryVM Disciplinary)
        {
            try
            {
                var _Disciplinary = _context.HrDisciplinary.FirstOrDefault(n => n.Id == Disciplinary.Id);
                if (_Disciplinary != null)
                {
                    _Disciplinary.Name = Disciplinary.name;
                    _Disciplinary.UpdateByID = Disciplinary.TransactionUserId;

                    _Disciplinary.LastUpdateDate = DateTime.Now;

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

        public string Delete(int DisciplinaryId)
        {
            try
            {
                var _Disciplinary = _context.HrDisciplinary.FirstOrDefault(n => n.Id == DisciplinaryId);
                if (_Disciplinary != null)
                {
                    _context.HrDisciplinary.Remove(_Disciplinary);
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


        public List<HrDisciplinaryGetVM> GetAll()
            => _context.HrDisciplinary.Select(n => new HrDisciplinaryGetVM
            {
                Id = n.Id,
                name = n.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();

        public HrDisciplinaryGetVM GetById(int DisciplinaryId)
            => _context.HrDisciplinary.Select(n => new HrDisciplinaryGetVM
            {
                Id = n.Id,
                name = n.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).FirstOrDefault(n => n.Id == DisciplinaryId);

    }
}
