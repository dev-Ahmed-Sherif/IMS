using Entities.Models.FI.Entry;
using Entities.Models.Pro;
using Entities.ViewModels.FI.Entry;
using Entities.ViewModels.Pro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ExtensionMethods.Pro
{
    public static class ProTenderExtension
    {
        public static ProTenderGetVM ToProTenderVM(this ProTender n)
        {
            ProTenderGetVM entry = new()
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
                TransactionUserId = n.CreatedByID.Value
            };
            return entry;


        }

    }
}
