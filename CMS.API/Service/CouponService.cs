using CMS.API.DomainModels;
using CMS.API.Repository.Interface;
using CMS.API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.API.Service
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;

        public CouponService(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }
        public async Task CreateAsync(Coupon coupon)
        {
            coupon.Id = Guid.NewGuid().ToString();
            coupon.QRCode =coupon.Name.Substring(0)+coupon.Name.Substring(coupon.Name.Length-1)+DateTime.Now.ToString("yyyyMMDD HH:MM:ss");
            await _couponRepository.CreateAsync(coupon);
        }

        public async Task DeleteAsync(string Id)
        {
            var coupon=await GetByIdAsync(Id);
            if(coupon == null)
            {
                return;
            }
           await _couponRepository.DeleteAsync(coupon);
        }

        public async Task<List<Coupon>> GetAllAsync()=> await _couponRepository.GetAllAsync();
        

        public async Task<Coupon> GetByIdAsync(string id)
        {
           return await _couponRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Coupon coupon)
        {
            await _couponRepository.UpdateAsync(coupon);
        }
    }
}
