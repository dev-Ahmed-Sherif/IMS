using AutoMapper;
using DAL;
using DAL.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProQuotationViewModels;
using Entities.ViewModels.Pro.ProTenderCommitteeMemberViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pro
{
    public class ProTenderCommitteeMemberService : GenericService<ProTenderCommitteeMember>
    {
        public new ProTenderCommitteeMemberRepository _repository;
        public ProTenderCommitteeMemberService(ProTenderCommitteeMemberRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }
        public IQueryable<ProTenderCommitteeMember> GetFiltered(ProTenderCommitteeMemberFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
