using Entities.ViewModels.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.HR
{
    public class HrPayMethodRepository
    {
        private AppDbContext _context;
        public HrPayMethodRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<HrPayMethodVM> GetAll() => _context.HrPayMethod.Select(n => new HrPayMethodVM
        {
            id = n.Id,
            Name = n.Name,

        }).ToList();
    }
}
