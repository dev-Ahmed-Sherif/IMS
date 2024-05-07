using DAL;
using DAL.HR;
using Entities.ViewModels.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Business.HR
{
    public class HrWorkPlaceService
    {
        public HrWorkPlaceRepository _hrWorkPlaceRepository;
        public HrWorkPlaceService(HrWorkPlaceRepository hrWorkPlaceRepository)
        {
            _hrWorkPlaceRepository = hrWorkPlaceRepository;
        }
        public string Add(HrWorkPlaceVM ID)
        {
            return _hrWorkPlaceRepository.Add(ID);
        }

        public string Update(HrWorkPlaceVM ID)
        {
            return _hrWorkPlaceRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _hrWorkPlaceRepository.Delete(ID);
        }
        public List<HrWorkPlaceGetVM> GetAll()
        {
            return _hrWorkPlaceRepository.GetAll();
        }
        public HrWorkPlaceGetVM GetById(int ID)
        {
            return _hrWorkPlaceRepository.GetById(ID);
        }

    }
}
