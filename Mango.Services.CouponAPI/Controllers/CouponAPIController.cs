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

        public CouponAPIController(AppDbContext db)
        {
            _db = db;
            _response = new ResponseDTO();
        }

        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                _response.Result = _db.Coupons.ToList();
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
                _response.Result = _db.Coupons.First(c => c.CouponId == couponId);
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
