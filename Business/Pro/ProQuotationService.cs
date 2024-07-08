using DAL;
using DAL.Pro;
using Entities.ExtensionMethods;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderDetailsViewModels;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.ViewModels.Pro.ProQuotationViewModels;
using AutoMapper;
using Entities.Helpers;

namespace Business.Pro
{
    public class ProQuotationService : GenericService<ProQuotation>
    {
        new readonly ProQuotationRepository _repository;
        public ProQuotationService(ProQuotationRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public IQueryable<ProQuotation> GetFiltered(ProQuotationFilter filter)
        {
            return _repository.Filter(filter);
        }
        public async Task<int> Add(ProQuotationInputVM input)
        {
            ProQuotation model = _mapper.Map<ProQuotation>(input);
            if (input.Attachment != null)
            {
                model.AttachmentUrl = await FileHelper.UploadFile(input.Attachment);
            }
            else
            {
                model.AttachmentUrl = string.Empty;
            }
            await base.Add(model);
            return model.Id;
        }
    }
}
