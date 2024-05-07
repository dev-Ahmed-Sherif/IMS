using Entities.ExtensionMethods;
using Entities.Models.SE;
using Entities.ViewModels.SE;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.SE
{
    public class ImsSectionRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<ImsSection> _dbSet;
        public ImsSectionRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.ImsSection;
        }
        public async Task<List<ImsSectionGeneralVM>> GetAllAsync()
        {
            return await _dbSet.Select(e => e.ToImsSectioGeneralVM()).ToListAsync();
        }
    }
}
