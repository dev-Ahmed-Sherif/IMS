using DAL;
using DAL.TR.General;
using Entities.ViewModels.TR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DAL.TR.General.TrClassRoomRepository;

namespace Business.TR.General
{
    public class TrClassRoomService
    {
        public TrClassRoomRepository _Repository;
        public TrClassRoomService(TrClassRoomRepository TrClassRoomRepository)
        {
            _Repository = TrClassRoomRepository;
        }
        public string Add(TrClassRoomVM ID)
        {
            return _Repository.Add(ID);
        }

        public string Update(TrClassRoomVM ID)
        {
            return _Repository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _Repository.Delete(ID);
        }
        public List<TrClassRoomGetVM> GetAll()
        {
            return _Repository.GetAll();
        }
        public TrClassRoomGetVM GetById(int ID)
        {
            return _Repository.GetById(ID);
        }
        public PaginatedResult<TrClassRoomGetVM> getAllByPagination(int page, int pageSize)
        {
            return _Repository.GetAllByPagination(page, pageSize);
        }
    }
}
