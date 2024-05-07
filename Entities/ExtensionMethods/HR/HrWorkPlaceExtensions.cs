using Entities.Models.HR;
using Entities.ViewModels.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ExtensionMethods.HR
{
    public static class HrWorkPlaceExtensions
    {
        public static HrWorkPlaceGetVM ToHrWorkPlaceGetVM(this HrWorkPlace model)
        {
            return new HrWorkPlaceGetVM
            {
                Id = model.Id,
                CityStateId = model.CityStateId,
                CityStateName = model.CityState?.Name,
                CreateUserName = model.CreatedBy?.Name,
                Name = model.Name,
                TransactionUserId = model.CreatedByID ?? default,
                UpdateUserName = model.UpdateBy?.Name,
            };
        }
    }
}
