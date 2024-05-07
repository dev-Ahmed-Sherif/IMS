using DAL;
using DAL.Cc;
using Entities.ViewModels.Cc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.Cc.CcEquipmentRepository;

namespace Business.Cc
{
    public class CcEquipmentService
    {
        public CcEquipmentRepository _CcEquipmentRepository;
        public CcEquipmentService(CcEquipmentRepository CcEquipmentRepository)
        {
            _CcEquipmentRepository = CcEquipmentRepository;
        }
        public string Add(CcEquipmentGeneralVM vtype)
        {
            return _CcEquipmentRepository.Add(vtype);
        }
        public string Update(CcEquipmentVM type)
        {
            return _CcEquipmentRepository.Update(type);
        }
        public string Delete(int typeId)
        {
            return _CcEquipmentRepository.Delete(typeId);
        }
        public List<CcEquipmentGetVM> GetAll()
        {
            return _CcEquipmentRepository.GetAll();
        }
        public CcEquipmentGetVM GetById(int typeId)
        {
            return _CcEquipmentRepository.GetById(typeId);
        }
        public PaginatedResult<CcEquipmentGetVM> getAllByPagination(int page, int pageSize)
        {
            return _CcEquipmentRepository.GetAllByPagination(page, pageSize);
        }
    }
}
