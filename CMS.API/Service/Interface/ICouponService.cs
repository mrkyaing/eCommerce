using CMS.API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.API.Service.Interface
{
    public interface ICouponService
    {
        Task CreateAsync(Coupon coupon);
        Task<List<Coupon>> GetAllAsync();
        Task UpdateAsync(Coupon coupon);
        Task DeleteAsync(string Id);
        Task<Coupon> GetByIdAsync(string id);
        Task<List<MemberCouponModel>> GetCouponUsedReport();
    }
}
