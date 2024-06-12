using DAL;
using DAL.Pro;
using Entities.ViewModels.FI.General;
using Entities.ViewModels.Pro;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Business.Pro
{
    public class ProTenderService
    {
        public ProTenderRepository _ProTenderRepository;
        public ProTenderService(ProTenderRepository ProTenderRepository)
        {
            _ProTenderRepository = ProTenderRepository;
        }
        public string Add(ProTenderGeneralVM vtype)
        {
            return _ProTenderRepository.Add(vtype);
        }
        public string Update(ProTenderVM type)
        {
            return _ProTenderRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _ProTenderRepository.Delete(typeId);
        }
        public List<ProTenderGetVM> GetAll()
        {
            return _ProTenderRepository.GetAll();
        }
        public ProTenderGetVM GetById(int typeId)
        {
            return _ProTenderRepository.GetById(typeId);
        }
        public List<ProTenderGetVM> Search(ProSearchGeneral searchModel)
        {
            return _ProTenderRepository.Search(searchModel);
        }
        public string GetLastNo()
        {
            return _ProTenderRepository.GetLastNo();
        }
        public PaginatedResult<ProTenderGetVM> getAllByPagination(int page, int pageSize)
        {
            return _ProTenderRepository.GetAllByPagination(page, pageSize);
        }
    }
}
