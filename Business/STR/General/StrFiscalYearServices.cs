using DAL;
using DAL.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.STR.General
{
    public class StrFiscalYearServices
    {
        public StrFiscalYearRepository _StrFiscalYearRepository;
        public StrFiscalYearServices(StrFiscalYearRepository StrFiscalYearRepository)
        {
            _StrFiscalYearRepository = StrFiscalYearRepository;
        }
        public string Add(StrFiscalYearGeneralVM year)
        {
            return _StrFiscalYearRepository.Add(year);
        }
        public string Update(StrFiscalYearVM year)
        {
            return _StrFiscalYearRepository.Update(year);
        }
        public string Delete(int yearId)
        {
            return _StrFiscalYearRepository.Delete(yearId);
        }
        public List<FiscalYearGetVM> GetAll()
        {
            return _StrFiscalYearRepository.GetAll();
        }
        public FiscalYearGetVM GetById(int yearId)
        {
            return _StrFiscalYearRepository.GetById(yearId);
        }
        public FiscalYearData GetLast()
        {
            return _StrFiscalYearRepository.GetLast();

        }
    }
}
