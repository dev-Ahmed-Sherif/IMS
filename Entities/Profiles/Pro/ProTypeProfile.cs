using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Pro
{
    public class ProTypeProfile : Profile
    {
        public ProTypeProfile()
        {
            CreateMap<ProType, ProTypeOutputVM>();
            CreateMap<ProTypeInputVM, ProType>();
        }
    }
}
