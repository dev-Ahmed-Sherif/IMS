using DAL;
using DAL.FI.Entry;
using Entities.ViewModels.FI.Entry;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.FI.Entry.FiEntryDetailsRepository;

namespace Business.FI.Entry
{
    public class FiEntryDetailsService
    {
        public FiEntryDetailsRepository _FiRepository;
        public FiEntryDetailsService(FiEntryDetailsRepository FiEntryDetailsRepository)
        {
            _FiRepository = FiEntryDetailsRepository;
        }
        //--------------------------
        // ADD new (FI)_EntryDetails
        //--------------------------
        public string Add(FiEntryDetailsGeneralVM ID)
        {
            return _FiRepository.Add(ID);
        }

        //-------------------------------------------------------
        // Update (FI)_EntryDetails { where id == EntryDetails.id }
        //-------------------------------------------------------
        public string Update(FiEntryDetailsVM ID)
        {
            return _FiRepository.Update(ID);
        }

        //--------------------------------------------------------
        // Dellete (FI)_EntryDetails { where id == EntryDetailsID }
        //--------------------------------------------------------
        public string Delete(int ID)
        {
            return _FiRepository.Delete(ID);
        }

        //-------------------------
        //Select * (FI)_EntryDetails 
        //-------------------------
        public List<FiEntryDetailsGetVM> GetAll()
        {
            return _FiRepository.GetAll();
        }

        //-----------------------------------------------------
        // Select * (FI)_EntryDetails where {id = EntryDetailsID} 
        //-----------------------------------------------------
        public FiEntryDetailsGetVM GetById(int ID)
        {
            return _FiRepository.GetById(ID);
        }
        public List<FiEntryDetailsGetVM> Search(searchFiEntry searchModel)
        {
            return _FiRepository.Search(searchModel);
        }
        public List<FiEntryDetailsGetVM> GetByHeader(int HeaderID)
        {
            return _FiRepository.GetByHeader(HeaderID);
        }
        public PaginatedResult<FiEntryDetailsGetVM> getAllByPagination(int page, int pageSize, int HeaderId)
        {
            return _FiRepository.GetAllByPagination(page, pageSize, HeaderId);
        }
    }
}
