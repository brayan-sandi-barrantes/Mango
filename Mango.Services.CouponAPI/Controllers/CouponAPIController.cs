using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDTO _response;
        private readonly IMapper _mapper;

        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDTO();
        }

        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                _response.Result = _mapper.Map<IEnumerable<CouponDTO>>(_db.Coupons.ToList());
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = $"Error retrieving data: {ex.Message}";
            }
            return _response;
        }

        [HttpGet]
        [Route("{couponId:int}")]
        public ResponseDTO Get(int couponId)
        {
            try
            {
                _response.Result = _mapper.Map<CouponDTO>(_db.Coupons.First(c => c.CouponId == couponId));
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = $"Error retrieving data: {ex.Message}";
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDTO Get(string code)
        {
            try
            {
                _response.Result = _mapper.Map<CouponDTO>(_db.Coupons.First(c => c.CouponCode.ToLower() == code.ToLower()));
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = $"Error retrieving data: {ex.Message}";
            }
            return _response;
        }

        [HttpPost]
        public ResponseDTO Create([FromBody] CouponDTO coupon)
        {
            try
            {
                Coupon newCoupon = _mapper.Map<Coupon>(coupon);
                _db.Coupons.Add(newCoupon);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDTO>(newCoupon);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = $"Error retrieving data: {ex.Message}";
            }
            return _response;
        }

        [HttpPut]
        public ResponseDTO Update([FromBody] CouponDTO coupon)
        {
            try
            {
                Coupon couponToUpdate = _mapper.Map<Coupon>(coupon);
                _db.Coupons.Update(couponToUpdate);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDTO>(couponToUpdate);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = $"Error retrieving data: {ex.Message}";
            }
            return _response;
        }

        [HttpDelete]
        public ResponseDTO Delete(int id)
        {
            try
            {
                Coupon couponToDelete = _db.Coupons.First(u => u.CouponId == id);
                _db.Coupons.Remove(couponToDelete);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = $"Error retrieving data: {ex.Message}";
            }
            return _response;
        }
    }
}
