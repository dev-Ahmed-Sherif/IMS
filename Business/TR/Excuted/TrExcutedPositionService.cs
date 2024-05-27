using DAL;
using DAL.TR.Excuted;
using Entities.ViewModels.TR.Excuted;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.Excuted.TrExcutedPositionRepository;

namespace Business.TR.Excuted
{
    public class TrExcutedPositionService
    {
        public TrExcutedPositionRepository _TrExcutedPositionRepository;


        public TrExcutedPositionService(TrExcutedPositionRepository TrExcutedPositionRepository)
        {
            _TrExcutedPositionRepository = TrExcutedPositionRepository;

        }

        public string Add(TrExcutedPositionGeneralVM sTR_Add)
        {
            return _TrExcutedPositionRepository.Add(sTR_Add);
        }

        public string Update(TrExcutedPositionVM sTR_Add)
        {
            return _TrExcutedPositionRepository.Update(sTR_Add);
        }
        public string Delete(int sTR_Add_Id)
        {
            return _TrExcutedPositionRepository.Delete(sTR_Add_Id);
        }
        public List<TrExcutedPositionGetVM> GetAll()
        {
            return _TrExcutedPositionRepository.GetAll();
        }
        public TrExcutedPositionGetVM GetById(int sTR_AddId)
        {
            return _TrExcutedPositionRepository.GetById(sTR_AddId);
        }
        public List<TrExcutedPositionGetVM> GetByHeaderId(int Id)
        {
            return _TrExcutedPositionRepository.GetByHeaderId(Id);
        }
        public PaginatedResult<TrExcutedPositionGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            return _TrExcutedPositionRepository.GetAllByPagination(page, pageSize, HeaderId);
        }
    }
}
