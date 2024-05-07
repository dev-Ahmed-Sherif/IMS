using DAL;
using DAL.TR.Excuted;
using Entities.ViewModels.TR.Excuted;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.Excuted.TrExcutedRepository;

namespace Business.TR.Excuted
{
    public class TrExcutedService
    {
        public TrExcutedRepository _TrExcutedRepository;
        public TrExcutedService(TrExcutedRepository TrExcutedRepository)
        {
            _TrExcutedRepository = TrExcutedRepository;
        }
        public string Add(TrExcutedGeneralVM ID)
        {
            return _TrExcutedRepository.Add(ID);
        }

        public string Update(TrExcutedVM ID)
        {
            return _TrExcutedRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _TrExcutedRepository.Delete(ID);
        }
        public List<TrExcutedGetVM> GetAll()
        {
            return _TrExcutedRepository.GetAll();
        }
        public TrExcutedGetVM GetById(int ID)
        {
            return _TrExcutedRepository.GetById(ID);
        }
        public PaginatedResult<TrExcutedGetVM> GetAllByPagination(int page, int pageSize)
        {
            return _TrExcutedRepository.GetAllByPagination(page, pageSize);
        }
    }
}
