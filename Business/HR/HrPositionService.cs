using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Business.HR
{
    public class HrPositionService
    {
        public HrPositionRepository _HrPositionRepository;
        public HrPositionService(HrPositionRepository HrPositionRepository)
        {
            _HrPositionRepository = HrPositionRepository;
        }
        public string Add(HrPositionVM ID)
        {
            return _HrPositionRepository.Add(ID);
        }

        public string Update(HrPositionVM ID)
        {
            return _HrPositionRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _HrPositionRepository.Delete(ID);
        }
        public List<HrPositionGetVM> GetAll()
        {
            return _HrPositionRepository.GetAll();
        }
        public HrPositionGetVM GetById(int ID)
        {
            return _HrPositionRepository.GetById(ID);
        }

    }
}
