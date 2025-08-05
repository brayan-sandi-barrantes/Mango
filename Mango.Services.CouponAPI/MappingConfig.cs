using AutoMapper;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.DTO;

namespace Mango.Services.CouponAPI
{
    public class MappingConfig
    {
        public static void Map(IMapperConfigurationExpression exp)
        {
            exp.CreateMap<Coupon, CouponDTO>().ReverseMap();
            exp.CreateMap<CouponDTO, Coupon>().ReverseMap();
        }
    }
}
