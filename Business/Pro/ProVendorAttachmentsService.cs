using AutoMapper;
using DAL;
using DAL.Migrations;
using DAL.Pro;
using Entities.Helpers;
using Entities.Models.Pro;
using Entities.ViewModels.Pro;
using Entities.ViewModels.Pro.ProTenderVendorReqViewModels;
using Entities.ViewModels.Pro.ProVendorAttachments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Pro
{
    public class ProVendorAttachmentService : GenericService<ProVendorAttachment>
    {
        public new ProVendorAttachmentRepository _repository;

        public ProVendorAttachmentService(ProVendorAttachmentRepository repository, UnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
        }
        public IQueryable<ProVendorAttachment> GetFiltered(ProVendorAttachmentFilter filter)
        {
            return _repository.Filter(filter);
        }
        public async Task<int> Add(ProVendorAttachmentInputVM input)
        {
            ProVendorAttachment model = _mapper.Map<ProVendorAttachment>(input);

            if (input.File != null)
            {
                model.FileUrl = await FileHelper.UploadFile(input.File);
            }
            else
            {
                model.FileUrl = string.Empty;
            }
            await base.Add(model);
            return model.Id;
        }
        public async Task<int?> Update(int id, ProVendorAttachmentInputVM input)
        {
            ProVendorAttachment? model = _repository.GetById(id);
            if (model == null) return null;
            if (input.File != null)
            {
                model.FileUrl = await FileHelper.UploadFile(input.File);
            }
            else
            {
                model.FileUrl = string.Empty;
            }
            await base.Update(model);
            return model.Id;
        }
    }
}
