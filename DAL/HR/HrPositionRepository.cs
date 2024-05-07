using Entities.Models.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DAL.HR
{
    public class HrPositionRepository
    {
        private AppDbContext _context;
        public HrPositionRepository(AppDbContext context)
        {
            _context = context;
        }

        public string Add(HrPositionVM Position)
        {
            try
            {
                var _Position = new HrPosition()
                {
                    Name = Position.name,

                    CreatedByID = Position.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.HrPosition.Add(_Position);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Update(HrPositionVM Position)
        {
            try
            {
                var _Position = _context.HrPosition.FirstOrDefault(n => n.Id == Position.Id);
                if (_Position != null)
                {
                    _Position.Name = Position.name;

                    _Position.UpdateByID = Position.TransactionUserId;

                    _Position.LastUpdateDate = DateTime.Now;

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

        public string Delete(int PositionId)
        {
            try
            {
                var _Position = _context.HrPosition.FirstOrDefault(n => n.Id == PositionId);
                if (_Position != null)
                {
                    _context.HrPosition.Remove(_Position);
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


        public List<HrPositionGetVM> GetAll() => _context.HrPosition.Select(n => new HrPositionGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public HrPositionGetVM GetById(int PositionId) => _context.HrPosition.Select(n => new HrPositionGetVM { Id = n.Id, name = n.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).FirstOrDefault(n => n.Id == PositionId);



    }
}
