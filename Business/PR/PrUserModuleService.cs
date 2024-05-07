using DAL;
using DAL.PR;
using Entities.ViewModels.PR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.PR
{
    public class PrUserModuleService
    {
        public PrUserModuleRepository _PRRepository;

        public PrUserModuleService(PrUserModuleRepository PrUserModuleRepository)
        {
            _PRRepository = PrUserModuleRepository;
        }

        public string Add(PrUserModuleVM userModule)
        {
            return _PRRepository.Add(userModule);
        }


        public string Update(PrUserModuleVM userModule)
        {
            return _PRRepository.Update(userModule);
        }

        public string Delete(int userModuleId)
        {
            return _PRRepository.Delete(userModuleId);
        }

        public List<PrUserModuleGetVM> GetAll()
        {
            return _PRRepository.GetAll();
        }
        public PrUserModuleGetVM GetById(int userModuleId)
        {
            return _PRRepository.GetById(userModuleId);
        }
    }
}
