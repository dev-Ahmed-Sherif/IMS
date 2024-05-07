using DAL;
using DAL.FI.Entry;
using Entities.ViewModels.FI.Entry;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.FI.Entry.FiEntrySourceRepository;

namespace Business.FI.Entry
{
    public class FiEntrySourceService
    {
        public FiEntrySourceRepository _FiRepository;
        public FiEntrySourceService(FiEntrySourceRepository FiEntrySourceRepository)
        {
            _FiRepository = FiEntrySourceRepository;
        }
        //--------------------------
        // ADD new (FI)_EntryEntrySource
        //--------------------------
        public string Add(FiEntrySourceGeneralVM ID)
        {
            return _FiRepository.Add(ID);
        }

        //-------------------------------------------------------
        // Update (FI)_EntryEntrySource { where id == EntryDetails.id }
        //-------------------------------------------------------
        public string Update(FiEntrySourceVM ID)
        {
            return _FiRepository.Update(ID);
        }

        //--------------------------------------------------------
        // Dellete (FI)_EntryEntrySource{ where id == EntryDetailsID }
        //--------------------------------------------------------
        public string Delete(int ID)
        {
            return _FiRepository.Delete(ID);
        }

        //-------------------------
        //Select * (FI)_EntryEntrySource
        //-------------------------
        public List<FiEntrySourceGetVM> GetAll()
        {
            return _FiRepository.GetAll();
        }

        //-----------------------------------------------------
        // Select * (FI)_EntrySource where {id = EntryDetailsID} 
        //-----------------------------------------------------
        public FiEntrySourceGetVM GetById(int ID)
        {
            return _FiRepository.GetById(ID);
        }

        public PaginatedResult<FiEntrySourceGetVM> getAllByPagination(int page, int pageSize)
        {
            return _FiRepository.GetAllByPagination(page, pageSize);
        }
    }
}
