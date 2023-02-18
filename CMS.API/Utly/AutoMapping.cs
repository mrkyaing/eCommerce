using AutoMapper;
using CMS.API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.API.Utly
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Member, MemberModel>(); // means you want to map from User to UserDTO
            CreateMap<MemberCoupon, MemberCouponModel>()
                .ForMember(dest=>dest.CouponCode,src=>src.MapFrom(src=>src.Coupon.Code))
                .ForMember(dest => dest.CouponName, src => src.MapFrom(src => src.Coupon.Name))
                .ForMember(dest => dest.MemberCode, src => src.MapFrom(src => src.Member.Code))
                .ForMember(dest => dest.CouponCode, src => src.MapFrom(src => src.Coupon.Code));
        }
    }
}
