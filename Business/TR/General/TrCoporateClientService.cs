using DAL;
using DAL.TR.General;
using Entities.ViewModels.TR.General;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.General.TrCoporateClientRepository;

namespace Business.TR.General
{
    public class TrCoporateClientService
    {

        public TrCoporateClientRepository _Repository;


        public TrCoporateClientService(TrCoporateClientRepository TrCoporateClientRepository)
        {
            _Repository = TrCoporateClientRepository;

        }

        public string Add(TrCorporateCLientGeneralVM sTR_Add)
        {
            return _Repository.Add(sTR_Add);
        }

        public string Update(TrCorporateCLientVM sTR_Add)
        {
            return _Repository.Update(sTR_Add);
        }
        public string Delete(int sTR_Add_Id)
        {
            return _Repository.Delete(sTR_Add_Id);
        }
        public List<TrCorporateCLientGetVM> GetAll()
        {
            return _Repository.GetAll();
        }
        public TrCorporateCLientGetVM GetById(int sTR_AddId)
        {
            return _Repository.GetById(sTR_AddId);
        }
        public PaginatedResult<TrCorporateCLientGetVM> getAllByPagination(int page, int pageSize)
        {
            return _Repository.GetAllByPagination(page, pageSize);
        }
    }
}
