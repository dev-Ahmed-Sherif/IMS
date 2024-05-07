using DAL;
using DAL.Fa;
using Entities.ViewModels.Fa;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.Fa.FaFixedAssetRepository;

namespace Business.Fa
{
    public class FaFixedAssetService
    {
        public FaFixedAssetRepository _FaFixedAssetRepository;
        public FaFixedAssetService(FaFixedAssetRepository FaFixedAssetRepository)
        {
            _FaFixedAssetRepository = FaFixedAssetRepository;
        }
        public string Add(FaFixedAssetGeneralVM vtype)
        {
            return _FaFixedAssetRepository.Add(vtype);
        }
        public string Update(FaFixedAssetVM type)
        {
            return _FaFixedAssetRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _FaFixedAssetRepository.Delete(typeId);
        }
        public List<FaFixedAssetGetVM> GetAll()
        {
            return _FaFixedAssetRepository.GetAll();
        }
        public FaFixedAssetGetVM GetById(int typeId)
        {
            return _FaFixedAssetRepository.GetById(typeId);
        }
        public string GetLastNo(int CategoryFirstId, int CategorySecondId, int CategoryThirdId)
        {
            return _FaFixedAssetRepository.GetLastNo(CategoryFirstId, CategorySecondId, CategoryThirdId);
        }
        public List<FaFixedAssetGetVM> Search(SearchGeneral searchModel)
        {
            return _FaFixedAssetRepository.Search(searchModel);
        }
        public PaginatedResult<FaFixedAssetGetVM> GetAllByPagination(int page, int pageSize)
        {
            return _FaFixedAssetRepository.GetAllByPagination(page, pageSize);
        }
    }

}
