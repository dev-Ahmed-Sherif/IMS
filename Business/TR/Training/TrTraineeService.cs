using DAL;
using DAL.TR.Training;
using Entities.ViewModels.TR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.Training.TrTraineeRepository;

namespace Business.TR.Training
{
    public class TrTraineeService
    {
        public TrTraineeRepository _Repository;
        public TrTraineeService(TrTraineeRepository TrTraineeRepository)
        {
            _Repository = TrTraineeRepository;
        }
        public string Add(TrTraineeVM ID)
        {
            return _Repository.Add(ID);
        }

        public string Update(TrTraineeVM ID)
        {
            return _Repository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _Repository.Delete(ID);
        }
        public List<TrTraineeGetVM> GetAll()
        {
            return _Repository.GetAll();
        }
        public TrTraineeGetVM GetById(int ID)
        {
            return _Repository.GetById(ID);
        }
        public PaginatedResult<TrTraineeGetVM> getAllByPagination(int page, int pageSize)
        {
            return _Repository.GetAllByPagination(page, pageSize);
        }
    }
}
