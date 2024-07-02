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
    public class ProVendorsTypesService : GenericService<ProVendorsTypes>
    {
        public ProVendorsTypesService(ProVendorsTypesRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}
