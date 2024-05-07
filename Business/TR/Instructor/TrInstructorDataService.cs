using DAL;
using DAL.TR.Instructor;
using Entities.ViewModels.TR.Instructor;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.Instructor.TrInstructorDataRepository;
namespace Business.TR.Instructor
{
    public class TrInstructorDataService
    {

        public TrInstructorDataRepository _Repository;


        public TrInstructorDataService(TrInstructorDataRepository TrInstructorDataRepository)
        {
            _Repository = TrInstructorDataRepository;

        }

        public string Add(TrInstructorDataGeneralVM sTR_Add)
        {
            return _Repository.Add(sTR_Add);
        }

        public string Update(TrInstructorDataVM sTR_Add)
        {
            return _Repository.Update(sTR_Add);
        }
        public string Delete(int sTR_Add_Id)
        {
            return _Repository.Delete(sTR_Add_Id);
        }
        public List<TrInstructorDataGetVM> GetAll()
        {
            return _Repository.GetAll();
        }
        public TrInstructorDataGetVM GetById(int sTR_AddId)
        {
            return _Repository.GetById(sTR_AddId);
        }
        public PaginatedResult<TrInstructorDataGetVM> getAllByPagination(int page, int pageSize)
        {
            return _Repository.GetAllByPagination(page, pageSize);
        }
    }
}
