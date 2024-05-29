using Entities.ViewModels.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.HR
{
    public class HrBankRepository
    {

        private AppDbContext _context;
        public HrBankRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<HrBankVM> GetAll() => _context.HrBank.Select(n => new HrBankVM
    {
        id = n.Id,
        Name = n.Name,
        Code = n.Code,
        
    }).ToList();
    }
}
