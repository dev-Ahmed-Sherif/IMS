using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Business.HR
{
    public class HrJobTitleService
    {
        public HrJobTitleRepository _HrJobTitleRepository;
        public HrJobTitleService(HrJobTitleRepository HrJobTitleRepository)
        {
            _HrJobTitleRepository = HrJobTitleRepository;
        }
        public string Add(HrJobTitleVM ID)
        {
            return _HrJobTitleRepository.Add(ID);
        }

        public string Update(HrJobTitleVM ID)
        {
            return _HrJobTitleRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrJobTitleRepository.Delete(ID);
        }
        public List<HrJobTitleGetVM> GetAll()
        {
            return _HrJobTitleRepository.GetAll();
        }
        public HrJobTitleGetVM GetById(int ID)
        {
            return _HrJobTitleRepository.GetById(ID);
        }

    }
}
