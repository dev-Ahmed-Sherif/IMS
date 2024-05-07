using DAL;
using DAL.TR.Training;
using Entities.ViewModels.TR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.Training.TrTrainingCenterRepository;

namespace Business.TR.Training
{
    public class TrTrainingCenterService
    {
        public TrTrainingCenterRepository _Repository;
        public TrTrainingCenterService(TrTrainingCenterRepository TrTrainingCenterRepository)
        {
            _Repository= TrTrainingCenterRepository;
        }
        public string Add(TrTrainingCenterVM ID)
        {
            return _Repository.Add(ID);
        }

        public string Update(TrTrainingCenterVM ID)
        {
            return _Repository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _Repository.Delete(ID);
        }
        public List<TrTrainingCenterGetVM> GetAll()
        {
            return _Repository.GetAll();
        }
        public TrTrainingCenterGetVM GetById(int ID)
        {
            return _Repository.GetById(ID);
        }
        public PaginatedResult<TrTrainingCenterGetVM> getAllByPagination(int page, int pageSize)
        {
            return _Repository.GetAllByPagination(page, pageSize);
        }
    }
}
