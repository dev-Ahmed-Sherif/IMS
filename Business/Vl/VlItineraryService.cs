using AutoMapper;
using DAL.VL;
using DAL;
using Entities.Models.VL;
using Entities.ViewModels.VL.VlItineraryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Vl
{
   public class VlItineraryService : GenericService<VlItinerary>
    {
        new readonly VlItineraryRepository _repository;
        public VlItineraryService(VlItineraryRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public IQueryable<VlItinerary> GetFiltered(VlItineraryFilter filter)
        {
            return _repository.Filter(filter);
        }
    }
}
