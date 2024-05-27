using Entities.Models.FI.Journal;
using Entities.ViewModels.FI.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.FI.General
{
    public class FiJournalTypeRepository
    {
        private AppDbContext _context;
        public FiJournalTypeRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<FiJournalTypeVM> GetAll()
           => _context.FiJournalTypes.Select(n => new FiJournalTypeVM
           {
               Id = n.Id,
               JournalType = n.JournalType,
           }).ToList();
    }
}
