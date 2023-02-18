using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace POS.API
{
    public  class HttpTriggerScanQR
    {
        [FunctionName("HttpTriggerScanQRMember")]
        public  async Task<IActionResult> ScanQRMember(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "scanqr/memberqrcode")] HttpRequest req,ILogger log){
            string memberQR = req.Query["memberqrcode"];
            return new OkObjectResult(new { response = "passed your member QR" });
        }

        [FunctionName("HttpTriggerScanQRCoupon")]
        public  async Task<IActionResult> ScanQRCoupon(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "scanqr/couponqrcode")] HttpRequest req,
           ILogger log)
        {
            string couponQR = req.Query["couponqrcode"];
            return new OkObjectResult(new { response = "passed your Coupon QR" });
        }
    }
}
