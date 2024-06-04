using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderSellerReqViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Pro
{
    public class ProTenderSellerReqRepository : GenericRepository<ProTenderSellerReq>
    {
        public ProTenderSellerReqRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        //public IQueryable<ProTenderSellerReq> Filter(ProTenderSellerReqFilter filter)
        //{
        //    IQueryable<ProTenderSellerReq> result = GetAll();
        //    if (filter.TenderId.HasValue)
        //    {
        //        result = result.Where(e => e.TenderId == filter.TenderId);
        //    }
        //    if (!string.IsNullOrEmpty(filter.Item))
        //    {
        //        result = result.Where(e => e.Item.Contains(filter.Item));
        //    }
        //    if (filter.MinQty.HasValue)
        //    {
        //        result = result.Where(e => e.Qty >= filter.MinQty);
        //    }
        //    if (filter.MaxQty.HasValue)
        //    {
        //        result = result.Where(e => e.Qty <= filter.MaxQty);
        //    }
        //    if (filter.MinPrice.HasValue)
        //    {
        //        result = result.Where(e => e.Price >= filter.MinPrice);
        //    }
        //    if (filter.MaxPrice.HasValue)
        //    {
        //        result = result.Where(e => e.Price <= filter.MaxPrice);
        //    }
        //    return result;
        //}
    }
}
