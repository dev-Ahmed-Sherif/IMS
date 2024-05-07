using DAL;
using DAL.FI.Account;
using Entities.ViewModels.FI.Account;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.FI.Account.FiAccountItemRepository;

namespace Business.FI.Account
{
    public class FiAccountItemService
    {
        public FiAccountItemRepository _FiRepository;
        public FiAccountItemService(FiAccountItemRepository FiAccountItemRepository)
        {
            _FiRepository = FiAccountItemRepository;

        }
        //-------------------------
        // ADD new (FI)_AccountItem
        //-------------------------
        public string Add(FiAccountItemVM ID)
        {
            return _FiRepository.Add(ID);
        }

        //-------------------------------------------------------
        // Update (FI)_AccountItem { where id == AccountItem.id }
        //-------------------------------------------------------
        public string Update(FiAccountItemVM ID)
        {
            return _FiRepository.Update(ID);
        }

        //-------------------------------------------------------
        // Dellete (FI)_AccountItem { where id == AccountItemID }
        //-------------------------------------------------------
        public string Delete(int ID)
        {
            return _FiRepository.Delete(ID);
        }

        //-------------------------
        //Select * (FI)_AccountItem 
        //-------------------------
        public List<FiAccountItemGetVM> GetAll()
        {
            return _FiRepository.GetAll();
        }

        //-----------------------------------------------------
        // Select * (FI)_AccountItem where {id = AccountItemID} 
        //-----------------------------------------------------
        public FiAccountItemGetVM GetById(int ID)
        {
            return _FiRepository.GetById(ID);
        }
        public List<FiAccountItemGetVM> GetByName(string accountName)
        {
            return _FiRepository.GetByName(accountName);
        }
        public PaginatedResult<FiAccountItemGetVM> getAllByPagination(int page, int pageSize)
        {
            return _FiRepository.GetAllByPagination(page, pageSize);
        }
    }
}


