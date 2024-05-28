using DAL;
using DAL.TR.Excuted;
using Entities.ViewModels.TR.Excuted;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.Excuted.TrExcutedTraineeRepository;

namespace Business.TR.Excuted
{
    public class TrExcutedTraineeService
    {
        public TrExcutedTraineeRepository _TrExcutedTraineeRepository;


        public TrExcutedTraineeService(TrExcutedTraineeRepository TrExcutedTraineeRepository)
        {
            _TrExcutedTraineeRepository = TrExcutedTraineeRepository;

        }

        public string Add(TrExcutedTraineeGeneralVM sTR_Add)
        {
            return _TrExcutedTraineeRepository.Add(sTR_Add);
        }

        public string Update(TrExcutedTraineeVM sTR_Add)
        {
            return _TrExcutedTraineeRepository.Update(sTR_Add);
        }
        public string Delete(int sTR_Add_Id)
        {
            return _TrExcutedTraineeRepository.Delete(sTR_Add_Id);
        }
        public List<TrExcutedTraineeGetVM> GetAll()
        {
            return _TrExcutedTraineeRepository.GetAll();
        }
        public TrExcutedTraineeGetVM GetById(int sTR_AddId)
        {
            return _TrExcutedTraineeRepository.GetById(sTR_AddId);
        }
        public List<TrExcutedTraineeGetVM> GetByHeaderId(int Id)
        {
            return _TrExcutedTraineeRepository.GetByHeaderId(Id);
        }
        public PaginatedResult<TrExcutedTraineeGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            return _TrExcutedTraineeRepository.GetAllByPagination(page, pageSize, HeaderId);
        }
    }
}

