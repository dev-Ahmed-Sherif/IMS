using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderComitteeMemberViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Pro
{
    public class ProTenderCommitteeMemberProfile : Profile
    {
        public ProTenderCommitteeMemberProfile()
        {
            CreateMap<ProTenderCommitteeMemberInputVM, ProTenderCommitteeMember>();
            CreateMap<ProTenderCommitteeMember, ProTenderCommitteeMemberOutputVM>();
        }

    }
}
