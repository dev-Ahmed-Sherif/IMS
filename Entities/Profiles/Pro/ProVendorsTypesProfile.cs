using AutoMapper;
using Entities.Models.Pro;
using Entities.ViewModels.Pro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Profiles.Pro
{
    public class ProVendorsTypesProfile : Profile
    {
        public ProVendorsTypesProfile()
        {
            CreateMap<ProVendorsTypesGeneralVM, ProVendorsTypes>();
            CreateMap<ProVendorsTypes, ProVendorsTypesGetVM>();
        }
    }
}
