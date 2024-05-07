using DAL;
using DAL.FI.Account;
using Entities.ViewModels.FI.Account;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.FI.Account.FiAccountParentRepository;

namespace Business.FI.Account
{
    public class FiAccountParentService
    {
        public FiAccountParentRepository _FiRepository;
        public FiAccountParentService(FiAccountParentRepository FiAccountParentRepository)
        {
            _FiRepository = FiAccountParentRepository;

        }

        //---------------------------
        // ADD new (FI)_AccountParent
        //---------------------------
        public string Add(FiAccountParentVM ID)
        {
            return _FiRepository.Add(ID);
        }
        //-----------------------------------------------------------
        // Update (FI)_AccountParent { where id == AccountParent.id }
        //-----------------------------------------------------------
        public string Update(FiAccountParentVM ID)
        {
            return _FiRepository.Update(ID);
        }
        //-----------------------------------------------------------
        // Dellete (FI)_AccountParent { where id == AccountParentID }
        //-----------------------------------------------------------
        public string Delete(int ID)
        {
            return _FiRepository.Delete(ID);
        }
        //---------------------------
        //Select * (FI)_AccountParent 
        //---------------------------
        public List<FiAccountParentGetVM> GetAll()
        {
            return _FiRepository.GetAll();
        }
        //---------------------------------------------------------
        // Select * (FI)_AccountParent where {id = AccountParentID} 
        //---------------------------------------------------------
        public FiAccountParentGetVM GetById(int ID)
        {
            return _FiRepository.GetById(ID);
        }
        //----------------------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //----------------------------------------------------------
        public PaginatedResult<FiAccountParentGetVM> GetAllByPagination(int page, int pageSize)
        {
            return _FiRepository.GetAllByPagination(page, pageSize);
        }
    }
}
