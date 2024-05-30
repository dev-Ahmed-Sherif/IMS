using Entities.Models;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DAL
{
    public class HrEmployeePositionRepository
    {

        private AppDbContext _context;
        public HrEmployeePositionRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrEmployeePositionVM EmployeePosition)
        {
            try
            {
                var _EmployeePosition = new HrEmployeePosition()
                {
                    Date = EmployeePosition.Date,
                    EmployeeId = EmployeePosition.EmployeeId,
                    PositionId = EmployeePosition.PositionId,
                    WorkPlaceId = EmployeePosition.WorkPlaceId,

                    CreatedByID = EmployeePosition.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrEmployeePosition.Add(_EmployeePosition);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrEmployeePositionVM EmployeePosition)
        {
            try
            {
                var _EmployeePosition = _context.HrEmployeePosition.FirstOrDefault(n => n.Id == EmployeePosition.Id);
                if (_EmployeePosition != null)
                {
                    _EmployeePosition.Date = EmployeePosition.Date;
                    _EmployeePosition.EmployeeId = EmployeePosition.EmployeeId;
                    _EmployeePosition.PositionId = EmployeePosition.PositionId;
                    _EmployeePosition.WorkPlaceId = EmployeePosition.WorkPlaceId;

                    _EmployeePosition.UpdateByID = EmployeePosition.TransactionUserId;

                    _EmployeePosition.LastUpdateDate = DateTime.Now;

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

        public string Delete(int EmployeePositionId)
        {
            try
            {
                var _EmployeePosition = _context.HrEmployeePosition.FirstOrDefault(n => n.Id == EmployeePositionId);
                if (_EmployeePosition != null)
                {
                    _context.HrEmployeePosition.Remove(_EmployeePosition);
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


        public List<HrEmployeePositionGetVM> GetAll() => _context.HrEmployeePosition.Select(n => new HrEmployeePositionGetVM { Id = n.Id, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, Date = n.Date, EmployeeId = n.EmployeeId, EmployeeName = n.Employee.Name, PositionId = n.PositionId, PositionName = n.Position.Name, WorkPlaceId = n.WorkPlaceId, WorkPlaceName = n.WorkPlace.Name }).ToList();
        public HrEmployeePositionGetVM GetById(int EmployeePositionId) => _context.HrEmployeePosition.Select(n => new HrEmployeePositionGetVM { Id = n.Id, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id, Date = n.Date, EmployeeId = n.EmployeeId, EmployeeName = n.Employee.Name, PositionId = n.PositionId, PositionName = n.Position.Name, WorkPlaceId = n.WorkPlaceId, WorkPlaceName = n.WorkPlace.Name }).FirstOrDefault(n => n.Id == EmployeePositionId);
        public List<HrEmployeePositionGetSearchVM> Search(HrEmployeePositionSearch searchModel)
        {
            var query = _context.HrEmployeePosition.AsQueryable();
            if (searchModel.EmployeeId.HasValue)
            {
                query = query.Where(p => p.EmployeeId==searchModel.EmployeeId);
            }
            if (!string.IsNullOrEmpty(searchModel.EmployeeName))
            {
                query = query.Where(p => p.Employee.Name.Contains(searchModel.EmployeeName));
            }
            if (searchModel.PositionId.HasValue)
            {
                query = query.Where(p => p.PositionId == searchModel.PositionId);
            }
            var result = query.Select(n => new HrEmployeePositionGetSearchVM
            {
                Id = n.Id,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,
                Date = n.Date,
                EmployeeId = n.EmployeeId,
                EmployeeName = n.Employee.Name,
                PositionId = n.PositionId,
                PositionName = n.Position.Name,
                WorkPlaceId = n.WorkPlaceId,
                WorkPlaceName = n.WorkPlace.Name,
                ShortDate = n.Date.ToString("dd/MM/yyyy"),
                ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"),
                Section = n.Employee.Section.Name,


            }).ToList();

            return result;
        }
    }
}
