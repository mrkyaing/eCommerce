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
using CMS.API.Utly;

namespace CMS.API
{
    public  class HttpTriggerReports
    {
        private readonly ICouponService couponService;

        public HttpTriggerReports(ICouponService couponService)
        {
            this.couponService = couponService;
        }
        [FunctionName("HttpTriggerReportsCoupon")]
        public  async Task<IActionResult> GetCouponList(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "reports/coupons")] HttpRequest req,
            ILogger log){
            try{
                // Check if we have authentication info.
                ValidateJWT auth = new ValidateJWT(req);
                if (!auth.IsValid)
                    return new UnauthorizedResult(); // No authentication.           
                var usedMemberCoupons = couponService.GetCouponUsedReport();
                return new OkObjectResult(usedMemberCoupons);
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
        }

        [FunctionName("HttpTriggerReportsExchangePoint")]
        public async Task<IActionResult> ExchangePoint(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "reports/exchangepoints")] HttpRequest req,
            ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var input = JsonConvert.DeserializeObject<Coupon>(requestBody);
                await couponService.CreateAsync(input);
                return new OkObjectResult(new { response = "Successed exchange points process." });
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
        }
    }
}
