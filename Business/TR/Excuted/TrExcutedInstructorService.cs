using DAL;
using DAL.TR.Excuted;
using Entities.ViewModels.TR.Excuted;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.Excuted.TrExcutedInstructorRepository;

namespace Business.TR.Excuted
{
    public class TrExcutedInstructorService
    {
        public TrExcutedInstructorRepository _TrExcutedInstructorRepository;


        public TrExcutedInstructorService(TrExcutedInstructorRepository TrExcutedInstructorRepository)
        {
            _TrExcutedInstructorRepository = TrExcutedInstructorRepository;

        }

        public string Add(TrExcutedInstructorGeneralVM sTR_Add)
        {
            return _TrExcutedInstructorRepository.Add(sTR_Add);
        }

        public string Update(TrExcutedInstructorVM sTR_Add)
        {
            return _TrExcutedInstructorRepository.Update(sTR_Add);
        }
        public string Delete(int sTR_Add_Id)
        {
            return _TrExcutedInstructorRepository.Delete(sTR_Add_Id);
        }
        public List<TrExcutedInstructorGetVM> GetAll()
        {
            return _TrExcutedInstructorRepository.GetAll();
        }
        public TrExcutedInstructorGetVM GetById(int sTR_AddId)
        {
            return _TrExcutedInstructorRepository.GetById(sTR_AddId);
        }
        public List<TrExcutedInstructorGetVM> GetByHeaderId(int Id)
        {
            return _TrExcutedInstructorRepository.GetByHeaderId(Id);
        }
        public PaginatedResult<TrExcutedInstructorGetVM> GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            return _TrExcutedInstructorRepository.GetAllByPagination(page, pageSize, HeaderId);
        }
    }
}
