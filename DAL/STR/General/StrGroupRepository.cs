using Entities.Models.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.STR.General
{
    //Book services class
    public class StrGroupRepository
    {
        private AppDbContext _context;

        //Hussein: constructor
        public StrGroupRepository(AppDbContext context)
        {
            _context = context;
        }
        public string GetLastNo(int PlatoonId)
        {

            try
            {
                string maxNo = _context.StrGroup
                 .Where(item => item.PlatoonId == PlatoonId)
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


                return maxNo;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            // string maxNo = _context.StrItem.Select(n => new StrItem { No = n.No }).MaxAsync(n => n.GroupId == GroupId);
            //var maxNo = from item in StrItem where( item=> item.GroupId == GroupId ) select item.No;

        }

        public string Add(StrGroupVM group)
        {
          
                bool exists = _context.StrGroup.Any(s => s.Name == group.Name);
                if (exists)
                {
                    return " Name already exists.";
                }
                var _group = new StrGroup()
                {
                    Name = group.Name,
                    Code = group.Code,
                    PlatoonId = group.PlatoonId,
                    CreatedByID = group.TransactionUserId,
                    CreationDate = DateTime.Now
                };
                _context.StrGroup.Add(_group);
                _context.SaveChanges();
                return "Succeeded";
            
        }


        public string Update(StrGroupVM group)
        {

            bool exists = _context.StrGroup.Any(s => s.Name == group.Name && s.Id != group.Id);
            if (exists)
            {
                return " Name already exists.";
            }
            var _group = _context.StrGroup.Single(n => n.Id == group.Id);
            
                _group.Name = group.Name;
                _group.Code = group.Code;
                _group.PlatoonId = group.PlatoonId;
                // _group.STR_Platoon.Name = group.PlatoonName;
                _group.UpdateByID = group.TransactionUserId;
                _group.LastUpdateDate = DateTime.Now;

                _context.SaveChanges();
                return "Succeeded";
           

        }

        public string Delete(int groupId)
        {
                var _group = _context.StrGroup.Single(n => n.Id == groupId);
              
                    _context.StrGroup.Remove(_group);
                    _context.SaveChanges();
                    return "Succeeded";
            
          
        }

        public List<StrGroupGetVM> GetAll() => _context.StrGroup.Select(n => new StrGroupGetVM { Id = n.Id, Name = n.Name, Code = n.Code, PlatoonId = n.PlatoonId, PlatoonName = n.STR_Platoon.Name, GradeId = n.STR_Platoon.STR_Grade.Id, GradeName = n.STR_Platoon.STR_Grade.Name, CommodityId = n.STR_Platoon.STR_Grade.STR_Commodity.Id, CommodityName = n.STR_Platoon.STR_Grade.STR_Commodity.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).ToList();
        public StrGroupGetVM GetById(int groupId) => _context.StrGroup.Select(n => new StrGroupGetVM { Id = n.Id, Name = n.Name, Code = n.Code, PlatoonId = n.PlatoonId, PlatoonName = n.STR_Platoon.Name, GradeId = n.STR_Platoon.STR_Grade.Id, GradeName = n.STR_Platoon.STR_Grade.Name, CommodityId = n.STR_Platoon.STR_Grade.STR_Commodity.Id, CommodityName = n.STR_Platoon.STR_Grade.STR_Commodity.Name, CreateUserName = n.CreatedBy.Name, TransactionUserId = n.CreatedBy.Id }).Single(n => n.Id == groupId);
    }
}
