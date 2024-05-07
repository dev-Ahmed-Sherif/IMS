using DAL;
using DAL.FI.Account;
using Entities.ViewModels.FI.Account;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.FI.Account.FiAccountHierarchyRepository;

namespace Business.FI.Account
{
    public class FiAccountHierarchyService
    {
        public FiAccountHierarchyRepository _FiRepository;
        public FiAccountHierarchyService(FiAccountHierarchyRepository FiAccountHierarchyRepository)
        {
            _FiRepository = FiAccountHierarchyRepository;

        }

        //------------------------------
        // ADD new (FI)_AccountHierarchy
        //------------------------------
        public string Add(FiAccountHierarchyVM ID)
        {
            return _FiRepository.Add(ID);
        }
        //-----------------------------------------------------------------
        // Update (FI)_accountHierarchy { where id == AccountHierarchy.id }
        //-----------------------------------------------------------------
        public string Update(FiAccountHierarchyVM ID)
        {
            return _FiRepository.Update(ID);
        }
        //-----------------------------------------------------------------
        // Dellete (FI)_accountHierarchy { where id == AccountHierarchyID }
        //-----------------------------------------------------------------
        public string Delete(int ID)
        {
            return _FiRepository.Delete(ID);
        }
        //------------------------------
        //Select * (FI)_accountHierarchy 
        //------------------------------
        public List<FiAccountHierarchyGetVM> GetAll()
        {
            return _FiRepository.GetAll();
        }
        //---------------------------------------------------------------
        // Select * (FI)_accountHierarchy where {id = AccountHierarchyID} 
        //---------------------------------------------------------------
        public FiAccountHierarchyGetVM GetById(int ID)
        {
            return _FiRepository.GetById(ID);
        }
        public PaginatedResult<FiAccountHierarchyGetVM> getAllByPagination(int page, int pageSize)
        {
            return _FiRepository.GetAllByPagination(page, pageSize);
        }
    }
}
