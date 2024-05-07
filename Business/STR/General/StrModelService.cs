using DAL;
using DAL.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.STR.General
{
    public class StrModelService
    {
        public StrModelRepository _StrModelRepository;
        public StrModelService(StrModelRepository StrModelRepository)
        {
            _StrModelRepository = StrModelRepository;
        }

        public string Add(StrModelGeneralVM vendor)
        {
            return _StrModelRepository.Add(vendor);
        }

        public string Update(StrModelVM model)
        {
            return _StrModelRepository.Update(model);
        }

        public string Delete(int modelId)
        {
            return _StrModelRepository.Delete(modelId);
        }
        public List<StrModelGetVM> GetAll()
        {
            return _StrModelRepository.GetAll();
        }
        public StrModelGetVM GetById(int modelId)
        {
            return _StrModelRepository.GetById(modelId);
        }
    }
}
