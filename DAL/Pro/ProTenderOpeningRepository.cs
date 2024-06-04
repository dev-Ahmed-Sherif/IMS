using Entities.Models.Pro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Pro
{
    public class ProTenderOpeningRepository : GenericRepository<ProTenderDetails>
    {
        public ProTenderOpeningRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
