using CMS.API.DAO;
using CMS.API.DomainModels;
using CMS.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.API.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly CMSDBContext _cMSDBContext;

        public CouponRepository(CMSDBContext cMSDBContext) {
            _cMSDBContext = cMSDBContext;
        }

        public async Task CreateAsync(Coupon coupon)
        {
            await _cMSDBContext.Coupons.AddAsync(coupon);
           await _cMSDBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Coupon coupon)
        {
            _cMSDBContext.Coupons.Remove(coupon);
            await _cMSDBContext.SaveChangesAsync();
        }

        public async Task<List<Coupon>> GetAllAsync()=>await _cMSDBContext.Coupons.ToListAsync();

        public async Task<Coupon> GetByIdAsync(string id)=> await _cMSDBContext.Coupons.Where(x=>x.Id==id).SingleOrDefaultAsync();

        public async Task<List<MemberCoupon>> GetCouponReport()
        {
         return   await _cMSDBContext.MemberCoupons.ToListAsync();
        }
        public async Task UpdateAsync(Coupon coupon)
        {
             _cMSDBContext.Coupons.Update(coupon);
            await _cMSDBContext.SaveChangesAsync();
        }
    }
}
