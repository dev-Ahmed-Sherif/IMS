using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrCityRepository
    {

        private AppDbContext _context;
        public HrCityRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrCityVM City)
        {
            try
            {
                var _City = new HrCity()
                {
                    Name = City.name,
                    CreatedByID = City.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrCity.Add(_City);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrCityVM City)
        {
            try
            {
                var _City = _context.HrCity.FirstOrDefault(n => n.Id == City.Id);
                if (_City != null)
                {
                    _City.Name = City.name;

                    _City.UpdateByID = City.TransactionUserId;
                    _City.LastUpdateDate = DateTime.Now;

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

        public string Delete(int CityId)
        {
            try
            {
                var _City = _context.HrCity.FirstOrDefault(n => n.Id == CityId);
                if (_City != null)
                {
                    _context.HrCity.Remove(_City);
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

        public List<HrCityGetVM> GetAll()
            => _context.HrCity.Select(n => new HrCityGetVM
            {
                Id = n.Id,
                name = n.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();

        public HrCityGetVM GetById(int CityId)
            => _context.HrCity.Select(n => new HrCityGetVM
            {
                Id = n.Id,
                name = n.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).FirstOrDefault(n => n.Id == CityId);

    }
}
