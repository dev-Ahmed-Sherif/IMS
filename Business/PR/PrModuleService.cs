using DAL;
using DAL.PR;
using Entities.ViewModels.PR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.PR
{
    public class PrModuleService
    {
        public PrModuleRepository _PRRepository;
        public PrModuleService(PrModuleRepository PrModuleRepository)
        {
            _PRRepository = PrModuleRepository;
        }

        public string Add(PrModuleVM Module)
        {
            return _PRRepository.Add(Module);
        }

        public string Update(PrModuleVM Module)
        {
            return _PRRepository.Update(Module);
        }

        public string Delete(int ModuleId)
        {
            return _PRRepository.Delete(ModuleId);
        }

        public List<PrModuleGetVM> GetAll()
        {
            return _PRRepository.GetAll();
        }
        public PrModuleGetVM GetById(int ModuleId)
        {
            return _PRRepository.GetById(ModuleId);
        }
    }
}
