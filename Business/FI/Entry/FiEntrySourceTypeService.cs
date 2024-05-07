using DAL;
using DAL.FI.Entry;
using Entities.ViewModels.FI.Entry;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.FI.Entry.FiEntrySourceTypeRepository;

namespace Business.FI.Entry
{
    public class FiEntrySourceTypeService
    {
        public FiEntrySourceTypeRepository _FiRepository;
        public FiEntrySourceTypeService(FiEntrySourceTypeRepository FiEntrySourceTypeRepository)
        {
            _FiRepository = FiEntrySourceTypeRepository;
        }
        //--------------------------
        // ADD new (FI)_EntryEntrySourceType
        //--------------------------
        public string Add(FiEntrySourceTypeGeneralVM ID)
        {
            return _FiRepository.Add(ID);
        }

        //-------------------------------------------------------
        // Update (FI)_EntryEntrySourceType { where id == EntryDetails.id }
        //-------------------------------------------------------
        public string Update(FiEntrySourceTypeVM ID)
        {
            return _FiRepository.Update(ID);
        }

        //--------------------------------------------------------
        // Dellete (FI)_EntryEntrySourceType{ where id == EntryDetailsID }
        //--------------------------------------------------------
        public string Delete(int ID)
        {
            return _FiRepository.Delete(ID);
        }

        //-------------------------
        //Select * (FI)_EntryEntrySourceType
        //-------------------------
        public List<FiEntrySourceTypeGetVM> GetAll()
        {
            return _FiRepository.GetAll();
        }

        //-----------------------------------------------------
        // Select * (FI)_EntrySourceType where {id = EntryDetailsID} 
        //-----------------------------------------------------
        public FiEntrySourceTypeGetVM GetById(int ID)
        {
            return _FiRepository.GetById(ID);
        }

        public PaginatedResult<FiEntrySourceTypeGetVM> getAllByPagination(int page, int pageSize)
        {
            return _FiRepository.GetAllByPagination(page, pageSize);
        }
    }
}
