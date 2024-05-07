using DAL;
using DAL.FI.Account;
using Entities.ViewModels.FI.Account;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.FI.Account.FiAccountItemCategoryRepository;

namespace Business.FI.Account
{
    public class FiAccountItemCategoryService
    {
        public FiAccountItemCategoryRepository _FiRepository;
        public FiAccountItemCategoryService(FiAccountItemCategoryRepository FiAccountItemCategoryRepository)
        {
            _FiRepository = FiAccountItemCategoryRepository;

        }
        //-------------------------
        // ADD new (FI)_AccountItem
        //-------------------------
        public string Add(FiAccountItemCategoryVM ID)
        {
            return _FiRepository.Add(ID);
        }

        //-------------------------------------------------------
        // Update (FI)_AccountItem { where id == AccountItem.id }
        //-------------------------------------------------------
        public string Update(FiAccountItemCategoryVM ID)
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
        public List<FiAccountItemCategoryGetVM> GetAll()
        {
            return _FiRepository.GetAll();
        }

        //-----------------------------------------------------
        // Select * (FI)_AccountItem where {id = AccountItemID} 
        //-----------------------------------------------------
        public FiAccountItemCategoryGetVM GetById(int ID)
        {
            return _FiRepository.GetById(ID);
        }
        public PaginatedResult<FiAccountItemCategoryGetVM> getAllByPagination(int page, int pageSize)
        {
            return _FiRepository.GetAllByPagination(page, pageSize);
        }
    }

}
