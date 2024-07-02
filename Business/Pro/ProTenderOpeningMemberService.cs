using AutoMapper;
using DAL;
using DAL.Pro;
using Entities.Models.Pro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pro
{
    public class ProTenderOpeningMemberService : GenericService<ProTenderOpeningMember>
    {
        public ProTenderOpeningMemberService(ProTenderOpeningMemberRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}
