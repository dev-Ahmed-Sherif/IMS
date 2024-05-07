using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrCityStateRepository
    {

        private AppDbContext _context;


        public HrCityStateRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrCityStateVM CityState)
        {
            try
            {
                var _CityState = new HrCityState()
                {
                    Name = CityState.name,
                    CityId = CityState.CityId,
                    CreatedByID = CityState.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrCityState.Add(_CityState);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrCityStateVM CityState)
        {
            try
            {
                var _CityState = _context.HrCityState.FirstOrDefault(n => n.Id == CityState.Id);
                if (_CityState != null)
                {
                    _CityState.Name = CityState.name;
                    _CityState.CityId = CityState.CityId;
                    _CityState.UpdateByID = CityState.TransactionUserId;
                    _CityState.LastUpdateDate = DateTime.Now;

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

        public string Delete(int CityStateId)
        {
            try
            {
                var _CityState = _context.HrCityState.FirstOrDefault(n => n.Id == CityStateId);
                if (_CityState != null)
                {
                    _context.HrCityState.Remove(_CityState);
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


        public List<HrCityStateGetVM> GetAll()
            => _context.HrCityState.Select(n => new HrCityStateGetVM
            {
                Id = n.Id,
                name = n.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                CityId = n.CityId,
                CityName = n.City.Name
            }).ToList();
        public HrCityStateGetVM GetById(int CityStateId)
            => _context.HrCityState.Select(n => new HrCityStateGetVM
            {
                Id = n.Id,
                name = n.Name,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                CityId = n.CityId,
                CityName = n.City.Name
            }).FirstOrDefault(n => n.Id == CityStateId);

    }
}
