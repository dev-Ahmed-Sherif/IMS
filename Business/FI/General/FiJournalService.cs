using DAL;
using DAL.FI.General;
using Entities.ViewModels.FI.General;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.FI.General.FiJournalRepository;

namespace Business.FI.General
{
    public class FiJournalService
    {
        public FiJournalRepository _FiRepository;
        public FiJournalService(FiJournalRepository FiJournalRepository)
        {
            _FiRepository = FiJournalRepository;
        }
        //--------------------------
        // ADD new (FI)_Journal
        //--------------------------
        public string Add(FiJournalGeneralVM ID)
        {
            return _FiRepository.Add(ID);
        }

        //-------------------------------------------------------
        // Update (FI)_Journal { where id == Journal.id }
        //-------------------------------------------------------
        public string Update(FiJournalVM ID)
        {
            return _FiRepository.Update(ID);
        }

        //--------------------------------------------------------
        // Dellete (FI)_Journal { where id == JournalID }
        //--------------------------------------------------------
        public string Delete(int ID)
        {
            return _FiRepository.Delete(ID);
        }

        //-------------------------
        //Select * (FI)_Journal 
        //-------------------------
        public List<FiJournalGetVM> GetAll(int YearID)
        {
            return _FiRepository.GetAll(YearID);
        }

        //-----------------------------------------------------
        // Select * (FI)_Journal where {id = JournalID} 
        //-----------------------------------------------------
        public FiJournalGetVM GetById(int ID)
        {
            return _FiRepository.GetById(ID);
        }
        public List<FiJournalGetVM> GetByName(string Description)
        {
            return _FiRepository.GetByName(Description);
        }
        public List<FiJournalGetVM> Search(Searchjournal searchModel)
        {
            return _FiRepository.Search(searchModel);
        }
        public PaginatedResult<FiJournalGetVM> getAllByPagination(int page, int pageSize, int YearID)
        {
            return _FiRepository.GetAllByPagination(page, pageSize, YearID);
        }
    }
}
