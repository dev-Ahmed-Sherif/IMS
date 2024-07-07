using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProType;
using System;
using System.Linq;

namespace DAL.Pro
{
    public class ProTypeRepository : GenericRepository<ProType>
    {
        public ProTypeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
