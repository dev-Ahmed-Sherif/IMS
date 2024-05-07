using DAL;
using DAL.TR.Instructor;
using Entities.ViewModels.TR.Instructor;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.Instructor.TrInstructorRepository;

namespace Business.TR.Instructor
{
    public class TrInstructorService
    {
        public TrInstructorRepository _Repository;
        public TrInstructorDataRepository _TrInstructorDataRepository;

        public TrInstructorService
            (TrInstructorRepository TrInstructorRepository,
            TrInstructorDataRepository TrInstructorDataRepository)
        {
            _Repository = TrInstructorRepository;
            _TrInstructorDataRepository = TrInstructorDataRepository;
        }

        public string Add(TrInstructorGeneralVM sTR_Add)
        {


            return _Repository.Add(sTR_Add);
        }

        public string Update(TrInstructorVM sTR_Add)
        {
            return _Repository.Update(sTR_Add);
        }
        public string Delete(int sTR_Add_Id)
        {
            return _Repository.Delete(sTR_Add_Id);
        }
        public List<TrInstructorGetVM> GetAll()
        {
            return _Repository.GetAll();
        }
        public TrInstructorGetVM GetById(int sTR_AddId)
        {
            return _Repository.GetById(sTR_AddId);
        }
        public PaginatedResult<TrInstructorGetVM> getAllByPagination(int page, int pageSize)
        {
            return _Repository.GetAllByPagination(page, pageSize);
        }
    }
}
