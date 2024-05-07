using DAL;
using DAL.SE;
using Entities.ViewModels.SE;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.SE
{
    public class ImsSectionService
    {
        private ImsSectionRepository _msSectionRepository;
        public ImsSectionService(ImsSectionRepository ImsSectionRepository)
        {
            _msSectionRepository = ImsSectionRepository;
        }

        public async Task<List<ImsSectionGeneralVM>> GetAllAsync()
        {
            return await _msSectionRepository.GetAllAsync();
        }
    }
}
