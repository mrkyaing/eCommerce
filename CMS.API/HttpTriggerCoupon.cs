using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CMS.API.Service.Interface;
using CMS.API.DomainModels;
using CMS.API.Service;

namespace CMS.API
{
    public  class HttpTriggerCoupon
    {
        private readonly ICouponService couponService;

        public HttpTriggerCoupon(ICouponService couponService)
        {
            this.couponService = couponService;
        }
        [FunctionName("HttpTriggerCouponCreate")]
        public  async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "coupon")] HttpRequest req,
            ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var input = JsonConvert.DeserializeObject<Coupon>(requestBody);
                await couponService.CreateAsync(input);
                return new OkObjectResult("successed");
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
        }
        [FunctionName("HttpTriggerCouponGet")]
        public async Task<IActionResult> GetAll(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "coupon/all")] HttpRequest req,
           ILogger log)
        {
            var items =await couponService.GetAllAsync();
            return new OkObjectResult(items);
        }
        [FunctionName("HttpTriggerCouponUpdate")]
        public async Task<IActionResult> Update(
           [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "coupon")] HttpRequest req,
           ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var input = JsonConvert.DeserializeObject<Coupon>(requestBody);
                await couponService.UpdateAsync(input);
                return new OkObjectResult("updated successed");
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
        }

        [FunctionName("HttpTriggerCouponDelete")]
        public async Task<IActionResult> Delete(
          [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "coupon/id/{id}")] HttpRequest req,string id,
          ILogger log)
        {
            try
            {
                var item=await couponService.GetByIdAsync(id);
                if (item == null) return new NotFoundObjectResult($"{id} not found in server.");
                await couponService.DeleteAsync(id);
                return new OkObjectResult("delete successed");
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
        }
    }
}
