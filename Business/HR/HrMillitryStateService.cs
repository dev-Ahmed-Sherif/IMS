using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrMillitryStateService
    {
        public HrMillitryStateRepository _HrMillitryStateRepository;
        public HrMillitryStateService(HrMillitryStateRepository HrMillitryStateRepository)
        {
            _HrMillitryStateRepository = HrMillitryStateRepository;
        }
        public string Add(HrMillitryStateVM ID)
        {
            return _HrMillitryStateRepository.Add(ID);
        }

        public string Update(HrMillitryStateVM ID)
        {
            return _HrMillitryStateRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrMillitryStateRepository.Delete(ID);
        }
        public List<HrMillitryStateGetVM> GetAll()
        {
            return _HrMillitryStateRepository.GetAll();
        }
        public HrMillitryStateGetVM GetById(int ID)
        {
            return _HrMillitryStateRepository.GetById(ID);
        }

    }

}