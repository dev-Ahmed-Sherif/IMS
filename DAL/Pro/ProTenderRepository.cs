using Entities.ExtensionMethods;
using Entities.Models.Pro;
using Entities.ViewModels.FI.General;
using Entities.ViewModels.Pro;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities.ExtensionMethods;
using Entities.ExtensionMethods.Pro;

namespace DAL.Pro
{
    public class ProTenderRepository
    {
        private AppDbContext _context;
        public ProTenderRepository(AppDbContext context)
        {
            _context = context;
        }
        //---------------------------------------------
        //add function
        public string Add(ProTenderGeneralVM add)
        {
            
                var _add = new ProTender()
                {

                    Name = add.Name,
                    Description = add.Description,
                    Code = add.Code,
                    Date = add.Date,
                    CityStateId = add.CityStateId,
                    OperationTypeId = add.OperationTypeId,
                    TenderTypeId = add.TenderTypeId,
                    Value = add.Value,
                    PlanTypeId = add.PlanTypeId,
                    Period = add.Period,
                    TORValue = add.TORValue,
                    TenderBondValue = add.TenderBondValue,
                    TechnicalOpeningDate = add.TechnicalOpeningDate,
                    TechnicalSelectionDate = add.TechnicalSelectionDate,
                    FinancialOpeningDate = add.FinancialOpeningDate,
                    FinancialSelectionDate = add.FinancialSelectionDate,
                    EstimatingValue = add.EstimatingValue,
                    AwardValue = add.AwardValue,
                    AwardLetterDate = add.AwardLetterDate,
                    WorkOrderDate = add.WorkOrderDate,
                    DeliveryDate = add.DeliveryDate,
                    CreatedByID = add.TransactionUserId,
                    CreationDate = DateTime.Now


                };
                _context.ProTender.Add(_add);
                _context.SaveChanges();
                return _add.Id.ToString();
            
        }
        //-----------------------------------------------
        //update function
        public string Update(ProTenderVM update)
        {
           
                var _update = _context.ProTender.Single(n => n.Id == update.Id);
               
                    _update.Name = update.Name;
                    _update.Description = update.Description;
                    _update.Code = update.Code;
                    _update.Date = update.Date;
                    _update.CityStateId = update.CityStateId;
                    _update.OperationTypeId = update.OperationTypeId;
                    _update.TenderTypeId = update.TenderTypeId;
                    _update.Value = update.Value;
                    _update.PlanTypeId = update.PlanTypeId;
                    _update.Period = update.Period;
                    _update.TORValue = update.TORValue;
                    _update.TenderBondValue = update.TenderBondValue;
                    _update.TechnicalOpeningDate = update.TechnicalOpeningDate;
                    _update.TechnicalSelectionDate = update.TechnicalSelectionDate;
                    _update.FinancialOpeningDate = update.FinancialOpeningDate;
                    _update.FinancialSelectionDate = update.FinancialSelectionDate;
                    _update.EstimatingValue = update.EstimatingValue;
                    _update.AwardValue = update.AwardValue;
                    _update.AwardLetterDate = update.AwardLetterDate;
                    _update.WorkOrderDate = update.WorkOrderDate;
                    _update.DeliveryDate = update.DeliveryDate;
                    _update.UpdateByID = update.TransactionUserId;
                    _update.CreationDate = DateTime.Now;

                    _context.SaveChanges();
                    return "Succeeded";
              
        }
        //--------------------------------------------
        //delete function

        public string Delete(int ID)
        {
            try
            {
                var _Row = _context.ProTender.FirstOrDefault(n => n.Id == ID);
                if (_Row != null)
                {
                    _context.ProTender.Remove(_Row);
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
        //----------------------------------------------------
        //get function
        public List<ProTenderGetVM> GetAll() => _context.ProTender
           .Select(n => new ProTenderGetVM
           {
               Id = n.Id,
               Name = n.Name,
               Description = n.Description,
               Code = n.Code,
               Date = n.Date,
               CityStateId = n.CityStateId,
               CityStateName = n.CityState.Name,
               OperationTypeId = n.OperationTypeId,
               OperationTypeName = n.OperationType.Name,
               OperationTypeCode = n.OperationType.Code,
               TenderTypeId = n.TenderTypeId,
               TenderTypeName = n.TenderType.Name,
               TenderTypeCode = n.TenderType.Code,
               Value = n.Value,
               PlanTypeId = n.PlanTypeId,
               PlanTypeName = n.PlanType.Name,
               PlanTypeCode = n.PlanType.Code,
               Period = n.Period,
               TORValue = n.TORValue,
               TenderBondValue = n.TenderBondValue,
               TechnicalOpeningDate = n.TechnicalOpeningDate,
               TechnicalSelectionDate = n.TechnicalSelectionDate,
               FinancialOpeningDate = n.FinancialOpeningDate,
               FinancialSelectionDate = n.FinancialSelectionDate,
               EstimatingValue = n.EstimatingValue,
               AwardValue = n.AwardValue,
               AwardLetterDate = n.AwardLetterDate,
               WorkOrderDate = n.WorkOrderDate,
               DeliveryDate = n.DeliveryDate,

               CreateUserName = n.CreatedBy.Name,
               TransactionUserId = n.CreatedBy.Id
           }).ToList();
        public ProTenderGetVM GetById(int itemId) => _context.ProTender
          .Select(n => new ProTenderGetVM
          {
              Id = n.Id,
              Name = n.Name,
              Description = n.Description,
              Code = n.Code,
              Date = n.Date,
              CityStateId = n.CityStateId,
              CityStateName = n.CityState.Name,
              OperationTypeId = n.OperationTypeId,
              OperationTypeName = n.OperationType.Name,
              OperationTypeCode = n.OperationType.Code,
              TenderTypeId = n.TenderTypeId,
              TenderTypeName = n.TenderType.Name,
              TenderTypeCode = n.TenderType.Code,
              Value = n.Value,
              PlanTypeId = n.PlanTypeId,
              PlanTypeName = n.PlanType.Name,
              PlanTypeCode = n.PlanType.Code,
              Period = n.Period,
              TORValue = n.TORValue,
              TenderBondValue = n.TenderBondValue,
              TechnicalOpeningDate = n.TechnicalOpeningDate,
              TechnicalSelectionDate = n.TechnicalSelectionDate,
              FinancialOpeningDate = n.FinancialOpeningDate,
              FinancialSelectionDate = n.FinancialSelectionDate,
              EstimatingValue = n.EstimatingValue,
              AwardValue = n.AwardValue,
              AwardLetterDate = n.AwardLetterDate,
              WorkOrderDate = n.WorkOrderDate,
              DeliveryDate = n.DeliveryDate,

              CreateUserName = n.CreatedBy.Name,
              TransactionUserId = n.CreatedBy.Id
          }).FirstOrDefault(n => n.Id == itemId);

        //-------------------------------------------------
        //search function

        public List<ProTenderGetVM> Search(ProSearchGeneral searchModel)
        {
            var query = _context.ProTender.AsQueryable();
            if (searchModel.Id.HasValue)
            {
                query = query.Where(p => p.Id == searchModel.Id);
            }
            if (searchModel.Date.HasValue)
            {
                query = query.Where(p => p.Date == searchModel.Date);
            }
            if (searchModel.CityStateId.HasValue)
            {
                query = query.Where(p => p.CityStateId == searchModel.CityStateId);
            }

            if (searchModel.OperationTypeId.HasValue)
            {
                query = query.Where(p => p.OperationTypeId == searchModel.OperationTypeId);
            }
            if (searchModel.TenderTypeId.HasValue)
            {
                query = query.Where(p => p.TenderTypeId == searchModel.TenderTypeId);
            }
            if (searchModel.PlanTypeId.HasValue)
            {
                query = query.Where(p => p.PlanTypeId == searchModel.PlanTypeId);
            }
            if (searchModel.Value.HasValue)
            {
                query = query.Where(p => p.Value == searchModel.Value);
            }
            if (searchModel.TORValue.HasValue)
            {
                query = query.Where(p => p.TORValue == searchModel.TORValue);
            }
            if (searchModel.TenderBondValue.HasValue)
            {
                query = query.Where(p => p.TenderBondValue == searchModel.TenderBondValue);
            }
            if (searchModel.TechnicalOpeningDate.HasValue)
            {
                query = query.Where(p => p.TechnicalOpeningDate == searchModel.TechnicalOpeningDate);
            }
            if (searchModel.TechnicalSelectionDate.HasValue)
            {
                query = query.Where(p => p.TechnicalSelectionDate == searchModel.TechnicalSelectionDate);
            }
            if (searchModel.FinancialOpeningDate.HasValue)
            {
                query = query.Where(p => p.FinancialOpeningDate == searchModel.FinancialOpeningDate);
            }
            if (searchModel.FinancialSelectionDate.HasValue)
            {
                query = query.Where(p => p.FinancialSelectionDate == searchModel.FinancialSelectionDate);
            }
            if (searchModel.EstimatingValue.HasValue)
            {
                query = query.Where(p => p.EstimatingValue == searchModel.EstimatingValue);
            }
            if (searchModel.AwardValue.HasValue)
            {
                query = query.Where(p => p.AwardValue == searchModel.AwardValue);
            }
            if (searchModel.AwardLetterDate.HasValue)
            {
                query = query.Where(p => p.AwardLetterDate == searchModel.AwardLetterDate);
            }

            if (searchModel.WorkOrderDate.HasValue)
            {
                query = query.Where(p => p.WorkOrderDate == searchModel.WorkOrderDate);
            }
            if (searchModel.DeliveryDate.HasValue)
            {
                query = query.Where(p => p.DeliveryDate == searchModel.DeliveryDate);
            }
            if (!string.IsNullOrEmpty(searchModel.Name))
            {
                query = query.Where(p => p.Name.Contains(searchModel.Name));
            }
            if (!string.IsNullOrEmpty(searchModel.Code))
            {
                query = query.Where(p => p.Code == searchModel.Code);
            }
            if (!string.IsNullOrEmpty(searchModel.Period))
            {
                query = query.Where(p => p.Period == searchModel.Period);
            }

            var results = query.Select(n => new ProTenderGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Code = n.Code,
                Date = n.Date,
                CityStateId = n.CityStateId,
                OperationTypeId = n.OperationTypeId,
                TenderTypeId = n.TenderTypeId,
                Value = n.Value,
                PlanTypeId = n.PlanTypeId,
                Period = n.Period,
                TORValue = n.TORValue,
                TenderBondValue = n.TenderBondValue,
                TechnicalOpeningDate = n.TechnicalOpeningDate,
                TechnicalSelectionDate = n.TechnicalSelectionDate,
                FinancialOpeningDate = n.FinancialOpeningDate,
                FinancialSelectionDate = n.FinancialSelectionDate,
                EstimatingValue = n.EstimatingValue,
                AwardValue = n.AwardValue,
                AwardLetterDate = n.AwardLetterDate,
                WorkOrderDate = n.WorkOrderDate,
                DeliveryDate = n.DeliveryDate,
                CreateUserName = n.CreatedBy.Name,
                TransactionUserId = n.CreatedBy.Id
            }).ToList();


            return results;

        }

        //------------------------------------------
        //autocode function
        public string GetLastNo()
        {
            int maxNo = _context.ProTenderType
             .Select(item => item.Code).DefaultIfEmpty()
             .Max();
            if (maxNo == 0)
            {
                maxNo = 1;
            }
            else
            {

                maxNo = maxNo + 1;

            }
            return maxNo.ToString();


        }

        public PaginatedResult<ProTenderGetVM> GetAllByPagination(int page, int pageSize)
        {
            var totalCount = _context.ProTender;
            var Item = _context.ProTender
                .OrderByDescending(Item => Item.CreationDate);
                
            return Item.ToPaginatedResult(page, pageSize, e => e.ToProTenderVM());
        }

    }
}
