using Entities.Models.STR.StoreOpen;
using Entities.ViewModels.STR.StoreOpen;

namespace Entities.ExtensionMethods.STR.StoreOpen
{
    public static class StrStoreExtensions
    {
        public static StrStoreGetVM ToStrStoreGetVM(this StrStore n)
        {
            return new StrStoreGetVM
            {
                Id = n.Id,
                Name = n.Name,
                Code = n.Code,
                StorekeeperId = n.StorekeeperId,
                StorekeeperName = n.Storekeeper?.Name,
                CreateUserName = n.CreatedBy?.Name,
                TransactionUserId = n.CreatedBy?.Id ?? default,
                SectionId = n.SectionId,
                Section = n.Section.Name
            };
        }
    }
}
