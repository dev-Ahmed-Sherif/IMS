using Entities.Models.Cc;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Cc
{
    public class CcEntryDetailsRepository
    {
        private AppDbContext _context;
        public CcEntryDetailsRepository(AppDbContext context)
        {
            _context = context;
        }
        //-------------
        //add function
        //-------------
        public string Add(CcEntryDetailsGeneralVM Add)
        {
             var _Add = new CcEntryDetails()
                {
                    EntryId = Add.EntryId,
                    AccountId = Add.AccountId,
                    ActivityId = Add.ActivityId,
                    CostCenterId = Add.CostCenterId,
                    EquipmentId = Add.EquipmentId,
                    Credit = Add.Credit,
                    Debit = Add.Debit,
                    Qty = Add.Qty,
                    Description = Add.Description,
                    CreatedByID = Add.TransactionUserId,
                    CreationDate = DateTime.Now

                };
                _context.CcEntryDetails.Add(_Add);
                _context.SaveChanges();
                return _Add.Id.ToString();
          
        }
        //-----------------------------------------------
        //update function
        public string Update(CcEntryDetailsVM update)
        {
                var _update = _context.CcEntryDetails.Single(n => n.Id == update.Id);
               
                    _update.EntryId = update.EntryId;
                    _update.AccountId = update.AccountId;
                    _update.ActivityId = update.ActivityId;
                    _update.CostCenterId = update.CostCenterId;
                    _update.EquipmentId = update.EquipmentId;
                    _update.Credit = update.Credit;
                    _update.Debit = update.Debit;
                    _update.Qty = update.Qty;
                    _update.Description = update.Description;
                    _update.UpdateByID = update.TransactionUserId;
                    _update.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
              
        }

        //--------------------------------------
        // Dellet CcEntryDetailsGetVM BY dele_Id
        //--------------------------------------

        public string Delete(int dele_Id)
        {
         
                var _dele = _context.CcEntryDetails.Single(n => n.Id == dele_Id);
              
                    _context.CcEntryDetails.Remove(_dele);
                    _context.SaveChanges();
                    return "Succeeded";
             

        }
        //-----------------------------------
        // Get ALL For => CcEntryDetailsGetVM
        //-----------------------------------
        public List<CcEntryDetailsGetVM> GetAll()
            => _context.CcEntryDetails.Select(n => new CcEntryDetailsGetVM
            {
                Id = n.Id,
                //Entry
                EntryId = n.EntryId,
                EntryNo = n.Entry.No,
                EntryDescription = n.Entry.Description,
                //Account
                AccountId = n.AccountId,
                AccountName = n.Account.Name,
                //Activity
                ActivityId = n.ActivityId,
                ActivityCode = n.Activity.Code,
                ActivityName = n.Activity.Name,
                //Costcenter
                CostCenterId = n.CostCenterId,
                CostCenterCode = n.CostCenter.Code,
                CostCenterName = n.CostCenter.Name,
                //Equipment
                EquipmentId = n.EquipmentId,
                EquipmentCode = n.Equipment.Code,
                EquipmentName = n.Equipment.Name,
                //EntryDetails
                Credit = n.Credit,
                Debit = n.Debit,
                Qty = n.Qty,
                Description = n.Description,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,

            }).ToList();
        //--------------------------------------------
        // Get Data For => CcEntryDetailsGetVM by ID
        //--------------------------------------------
        public CcEntryDetailsGetVM GetById(int itemId)
            => _context.CcEntryDetails.Select(n => new CcEntryDetailsGetVM
            {
                Id = n.Id,
                //Entry
                EntryId = n.EntryId,
                EntryNo = n.Entry.No,
                EntryDescription = n.Entry.Description,
                //Account
                AccountId = n.AccountId,
                AccountName = n.Account.Name,
                //Activity
                ActivityId = n.ActivityId,
                ActivityCode = n.Activity.Code,
                ActivityName = n.Activity.Name,
                //Costcenter
                CostCenterId = n.CostCenterId,
                CostCenterCode = n.CostCenter.Code,
                CostCenterName = n.CostCenter.Name,
                //Equipment
                EquipmentId = n.EquipmentId,
                EquipmentCode = n.Equipment.Code,
                EquipmentName = n.Equipment.Name,
                //EntryDetails
                Credit = n.Credit,
                Debit = n.Debit,
                Qty = n.Qty,
                Description = n.Description,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id,

            }).FirstOrDefault(n => n.Id == itemId);

        //--------------------------------------------
        // Get Header Data For => CcEntry by Header ID
        //--------------------------------------------
        public List<CcEntryDetailsGetVM> GetByHeader(int ID)
           => _context.CcEntryDetails.Where(n => n.EntryId == ID).Select
               (n => new CcEntryDetailsGetVM
               {
                   //-------------------------------------------------------
                   // Get Details Data For => CcEntry ++ CcEntryDetailsGetVM
                   //-------------------------------------------------------

                   Id = n.Id,
                   //Entry
                   EntryId = n.EntryId,
                   EntryNo = n.Entry.No,
                   EntryDescription = n.Entry.Description,
                   //Account
                   AccountId = n.AccountId,
                   AccountName = n.Account.Name,
                   AccountCode = n.Account.Code,
                   //Activity
                   ActivityId = n.ActivityId,
                   ActivityCode = n.Activity.Code,
                   ActivityName = n.Activity.Name,
                   //Costcenter
                   CostCenterId = n.CostCenterId,
                   CostCenterCode = n.CostCenter.Code,
                   CostCenterName = n.CostCenter.Name,
                   //Equipment
                   EquipmentId = n.EquipmentId,
                   EquipmentCode = n.Equipment.Code,
                   EquipmentName = n.Equipment.Name,
                   //EntryDetails
                   Credit = n.Credit,
                   Debit = n.Debit,
                   Qty = n.Qty,
                   Description = n.Description,
                   CreateUserName = n.CreatedBy.Name,
                   TransactionUserId = n.CreatedBy.Id,

                   //-------------------------------
                   // Get Header Data For => CcEntry
                   //-------------------------------

                   HeaderNo = n.Entry.No,
                   HeaderDescription = n.Entry.Description,
                   HeaderDate = n.Entry.Date,
                   HeaderCreditTotal = n.Entry.CreditTotal,
                   HeaderDebitTotal = n.Entry.DebitTotal,
                   HeaderBalance = n.Entry.Balance,



               }).ToList();

        //------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize )} 
        //------------------------------------------------
        public PaginatedResult<CcEntryDetailsGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            var totalCount = _context.CcEntryDetails.Where(n => n.EntryId == HeaderId).Count();
            List<int> fientryD = _context.CcEntryDetails
                .Where(sus => sus.EntryId == HeaderId)
                .Select(sus => sus.EntryId)
                .ToList();
            List<CcEntryDetailsGetVM> Item = _context.CcEntryDetails
                .Where(n => fientryD.Contains(n.EntryId))
                .OrderByDescending(Item => Item.CreationDate)
                .Skip((page) * pageSize)
                .Take(pageSize)
                .Select(n => new CcEntryDetailsGetVM
                {
                    Id = n.Id,
                    //Entry
                    EntryId = n.EntryId,
                    EntryNo = n.Entry.No,
                    EntryDescription = n.Entry.Description,
                    //Account
                    AccountId = n.AccountId,
                    AccountName = n.Account.Name,
                    //Activity
                    ActivityId = n.ActivityId,
                    ActivityCode = n.Activity.Code,
                    ActivityName = n.Activity.Name,
                    //Costcenter
                    CostCenterId = n.CostCenterId,
                    CostCenterCode = n.CostCenter.Code,
                    CostCenterName = n.CostCenter.Name,
                    //Equipment
                    EquipmentId = n.EquipmentId,
                    EquipmentCode = n.Equipment.Code,
                    EquipmentName = n.Equipment.Name,
                    //EntryDetails
                    Credit = n.Credit,
                    Debit = n.Debit,
                    Qty = n.Qty,
                    Description = n.Description,
                    CreateUserName = n.CreatedBy.Name,
                    TransactionUserId = n.CreatedBy.Id,
                })
                .ToList();

            var paginatedResult = new PaginatedResult<CcEntryDetailsGetVM>
            {
                Items = Item,
                TotalItems = totalCount,
                Page = page,
                PageSize = pageSize
            };

            return paginatedResult;
        }
        public class PaginatedResult<T>
        {
            public List<T> Items { get; set; }
            public int TotalItems { get; set; }
            public int Page { get; set; }
            public int PageSize { get; set; }
        }
    }
}
