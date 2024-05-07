using Entities.Models.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.General
{
    public class StrPlatoonRepository
    {
        private AppDbContext _context;
        public StrPlatoonRepository(AppDbContext context)
        {
            _context = context;
        }
        public string GetLastNo(int GradeId)
        {
            try
            {
                string maxNo = _context.StrPlatoon
                .Where(item => item.GradeId == GradeId)
                .Select(item => item.Code)
                .Max();

                if (maxNo == null)
                {
                    maxNo = "0";
                }
                int intmaxNo = int.Parse(maxNo);

                intmaxNo = intmaxNo + 1;

                maxNo = intmaxNo.ToString();
                if (maxNo.Length == 1)
                {
                    maxNo = "0" + intmaxNo;
                }
                //if (maxNo.Length == 2)
                //{
                //    maxNo = "0" + intmaxNo;
                //}

                return maxNo.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            // string maxNo = _context.StrItem.Select(n => new StrItem { No = n.No }).MaxAsync(n => n.GroupId == GroupId);
            //var maxNo = from item in StrItem where( item=> item.GroupId == GroupId ) select item.No;

        }
        public string Add(StrPlatoonVM platoon)
        {
           
                bool exists = _context.StrPlatoon.Any(s => s.Name == platoon.Name);
                if (exists)
                {
                    return " Name already exists.";
                }
                var _platoon = new StrPlatoon()
                {
                    Name = platoon.Name,
                    Code = platoon.Code,
                    GradeId = platoon.GradeId,
                    CreatedByID = platoon.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.StrPlatoon.Add(_platoon);
                _context.SaveChanges();
                return "Succeeded";
           
        }

        public string Update(StrPlatoonVM platoon)
        {

            bool exists = _context.StrPlatoon.Any(s => s.Name == platoon.Name && s.Id != platoon.Id);
            if (exists)
            {
                return " Name already exists.";
            }
            var _platoon = _context.StrPlatoon.Single(n => n.Id == platoon.Id);
            if (_platoon == null) return "nothing to be updated";


            _platoon.Name = platoon.Name;
            _platoon.Code = platoon.Code;
            _platoon.GradeId = platoon.GradeId;
            _platoon.UpdateByID = platoon.TransactionUserId;
            _platoon.LastUpdateDate = DateTime.Now;

            _context.SaveChanges();
            return "Succeeded";

        }

        public string Delete(int platoonId)
        {
            
                var _platoon = _context.StrPlatoon.Single(n => n.Id == platoonId);
              
                    _context.StrPlatoon.Remove(_platoon);
                    _context.SaveChanges();
                    return "Succeeded";
               
           
        }

        public List<StrPlatoonGetVM> GetAll() => _context.StrPlatoon.Select(n => new StrPlatoonGetVM { Id = n.Id, Name = n.Name, Code = n.Code, GradeId = n.GradeId, GradeName = n.STR_Grade.Name, CommodityId = n.STR_Grade.STR_Commodity.Id, CommodityName = n.STR_Grade.STR_Commodity.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public StrPlatoonGetVM GetById(int groupId) => _context.StrPlatoon.Select(n => new StrPlatoonGetVM { Id = n.Id, Name = n.Name, Code = n.Code, GradeId = n.GradeId, GradeName = n.STR_Grade.Name, CommodityName = n.STR_Grade.STR_Commodity.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == groupId);
        public PlatoonWithGroupsVM GetWithGroups(int platoonId)
        {
            var _platoonWithGroups = _context.StrPlatoon.Where(n => n.Id == platoonId).Select(StrPlatoon => new PlatoonWithGroupsVM()
            {
                Name = StrPlatoon.Name,
                Code = StrPlatoon.Code,
                Platoon_Group = _context.StrGroup.Select(n => new StrGroupVM()
                {
                    Code = n.Code,
                    Name = n.Name,
                    PlatoonId = n.PlatoonId,


                }).ToList()

            }).Single();
            return _platoonWithGroups;
        }
    }
}
