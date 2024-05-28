using DAL.HR;
using Entities.ViewModels.HR;
using System.Collections.Generic;

namespace Business.HR
{
    public class HrPayMethodService
    {
        public HrPayMethodRepository _HrPayMethodRepository;
        public HrPayMethodService(HrPayMethodRepository HrPayMethodRepository)
        {
            _HrPayMethodRepository = HrPayMethodRepository;
        }
        public List<HrPayMethodVM> GetAll()
        {
            return _HrPayMethodRepository.GetAll();
        }
    }
}
