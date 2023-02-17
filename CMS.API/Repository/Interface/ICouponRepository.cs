using CMS.API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.API.Repository.Interface
{
    public interface ICouponRepository
    {
        Task CreateAsync(Coupon coupon);
        Task<List<Coupon>> GetAllAsync();
        Task UpdateAsync(Coupon coupon);
        Task DeleteAsync(Coupon coupon);
        Task<Coupon> GetByIdAsync(string id);
    }
}
