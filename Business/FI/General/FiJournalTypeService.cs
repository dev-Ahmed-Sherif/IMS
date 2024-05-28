using DAL.FI.General;
using Entities.ViewModels.FI.General;
using System;
using System.Collections.Generic;


namespace Business.FI.General
{
    public class FiJournalTypeService
    {
        public FiJournalTypeRepository _FiRepository;
        public FiJournalTypeService(FiJournalTypeRepository FiJournalTypeRepository)
        {
            _FiRepository = FiJournalTypeRepository;
        }
        public List<FiJournalTypeVM> GetAll()
        {
            return _FiRepository.GetAll();
        }
    }
}
