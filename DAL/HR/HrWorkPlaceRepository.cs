using Entities.ExtensionMethods.HR;
using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.HR
{
    public class HrWorkPlaceRepository
    {

        private AppDbContext _context;
        public HrWorkPlaceRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(HrWorkPlaceVM WorkPlace)
        {
            try
            {
                var _WorkPlace = new HrWorkPlace()
                {
                    Name = WorkPlace.Name,
                    CityStateId = WorkPlace.CityStateId,

                    CreatedByID = WorkPlace.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrWorkPlace.Add(_WorkPlace);
                _context.SaveChanges();
                return _WorkPlace.Id.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrWorkPlaceVM WorkPlace)
        {
            try
            {
                var _WorkPlace = _context.HrWorkPlace.FirstOrDefault(n => n.Id == WorkPlace.Id);
                if (_WorkPlace != null)
                {
                    _WorkPlace.Name = WorkPlace.Name;
                    _WorkPlace.CityStateId = WorkPlace.CityStateId;

                    _WorkPlace.UpdateByID = WorkPlace.TransactionUserId;
                    _WorkPlace.LastUpdateDate = DateTime.Now;

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

        public string Delete(int WorkPlaceId)
        {
            try
            {
                var _WorkPlace = _context.HrWorkPlace.FirstOrDefault(n => n.Id == WorkPlaceId);
                if (_WorkPlace != null)
                {
                    _context.HrWorkPlace.Remove(_WorkPlace);
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
        public List<HrWorkPlaceGetVM> GetAll()
        {
            return _context
                .HrWorkPlace
                .Select(e => e.ToHrWorkPlaceGetVM())
                .ToList();
        }
        public HrWorkPlaceGetVM GetById(int WorkPlaceId)
        {
            return
                _context
                .HrWorkPlace
                .Find(WorkPlaceId)?
                .ToHrWorkPlaceGetVM();
        }

    }
}
