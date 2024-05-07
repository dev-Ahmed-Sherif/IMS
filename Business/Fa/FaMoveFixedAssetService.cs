using DAL;
using DAL.Fa;
using Entities.ViewModels.Fa;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.Fa.FaMoveFixedAssetRepository;
namespace Business.Fa
{
    public class FaMoveFixedAssetService
    {
        public FaMoveFixedAssetRepository _FaMoveFixedAssetRepository;
        public FaMoveFixedAssetService(FaMoveFixedAssetRepository FaMoveFixedAssetRepository)
        {
            _FaMoveFixedAssetRepository = FaMoveFixedAssetRepository;
        }
        public string Add(FaMoveFixedAssetGeneralVM vtype)
        {
            return _FaMoveFixedAssetRepository.Add(vtype);
        }
        public string Update(FaMoveFixedAssetVM type)
        {
            return _FaMoveFixedAssetRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _FaMoveFixedAssetRepository.Delete(typeId);
        }
        public List<FaMoveFixedAssetGetVM> GetAll()
        {
            return _FaMoveFixedAssetRepository.GetAll();
        }
        public FaMoveFixedAssetGetVM GetById(int itemId)
        {
            return _FaMoveFixedAssetRepository.GetById(itemId);
        }

        public List<FaMoveFixedAssetGetVM> Search(SearchGeneralMove searchModel)
        {
            return _FaMoveFixedAssetRepository.Search(searchModel);
        }
        public PaginatedResult<FaMoveFixedAssetGetVM> GetAllByPagination(int page, int pageSize)
        {
            return _FaMoveFixedAssetRepository.GetAllByPagination(page, pageSize);
        }

    }
}
