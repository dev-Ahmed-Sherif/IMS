using AutoMapper;
using DAL;
using DAL.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderOpeningMemberViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pro
{
    public class ProTenderOpeningMemberService : GenericService<ProTenderOpeningMember>
    {
        private new readonly ProTenderOpeningMemberRepository _repository;
        public ProTenderOpeningMemberService(ProTenderOpeningMemberRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }
        public IQueryable<ProTenderOpeningMember> GetFiltered(ProTenderOpeningMemberFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
