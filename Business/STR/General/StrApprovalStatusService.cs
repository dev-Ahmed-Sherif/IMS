using DAL;
using DAL.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Business.STR.General
{
    public class StrApprovalStatusService
    {
        public StrApprovalStatusRepository _StrApprovalStatusRepository;
        public StrApprovalStatusService(StrApprovalStatusRepository StrApprovalStatusRepository)
        {
            _StrApprovalStatusRepository = StrApprovalStatusRepository;
        }
        public string Add(StrApprovalStatusVM ID)
        {
            return _StrApprovalStatusRepository.Add(ID);
        }

        public string Update(StrApprovalStatusVM ID)
        {
            return _StrApprovalStatusRepository.Update(ID);
        }

        public string Delete(int ID)
        {
            return _StrApprovalStatusRepository.Delete(ID);
        }
        public List<StrApprovalStatusGetVM> GetAll()
        {
            return _StrApprovalStatusRepository.GetAll();
        }
        public StrApprovalStatusGetVM GetById(int ID)
        {
            return _StrApprovalStatusRepository.GetById(ID);
        }

    }
}
