using DAL.HR;
using Entities.ViewModels.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.HR
{
    public class HrBankService
    {
        public HrBankRepository _HrBankRepository;
        public HrBankService(HrBankRepository HrBankRepository)
        {
            _HrBankRepository = HrBankRepository;
        }
        public List<HrBankVM> GetAll()
        {
            return _HrBankRepository.GetAll();
        }
    }
}
