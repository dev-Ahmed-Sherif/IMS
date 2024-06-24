using AutoMapper;
using Entities.Models.FI.Entry;
using Entities.ViewModels.Cc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Fi
{
    public class FiEntryProfile : Profile
    {
        public FiEntryProfile()
        {
            CreateMap<FiEntry, CcEntryGetVM>()
                .ForMember(dest => dest.FiscalYearId, cfg => cfg.MapFrom(src => src.Journal.FiscalYearId))
                .ForMember(dest => dest.TransactionUserId, cfg => cfg.MapFrom(src => src.CreatedByID))
                .ForMember(dest => dest.CreateUserName, cfg => cfg.MapFrom(src => src.CreatedBy != null ? src.CreatedBy.Name : ""))
                .ForMember(dest => dest.JournalName, cfg => cfg.MapFrom(src => src.Journal.Description));
        }
    }
}
