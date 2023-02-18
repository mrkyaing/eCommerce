using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace POS.API
{
    public  class HttpTriggerCheckCouponAvailable
    {
        private readonly HttpClient _client;

        public HttpTriggerCheckCouponAvailable(IHttpClientFactory httpClientFactory)
        {
            this._client = httpClientFactory.CreateClient();
        }
        [FunctionName("HttpTriggerCheckCouponAvailable")]
        public  async Task<IActionResult> CheckCouponAvailable(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "check/couponavailable")] HttpRequest req,ILogger log){
            string queryCoupon = req.Query["coupon"];
            if (queryCoupon != null)
            {
                int coupon=int.Parse(queryCoupon);
                string uri = "http://localhost:7167/api/calculate";
                var response = await _client.PostAsJsonAsync(uri, coupon);
                if (response.IsSuccessStatusCode)
                {
                    var Points = await response.Content.ReadAsStringAsync();
                    return new OkObjectResult(new { response = $"Total {Points} point(s) is available  for your coupon" });
                }
                else
                {
                    return new OkObjectResult(response.StatusCode + " : Message - " + response.ReasonPhrase);
                }
            }
            return new OkObjectResult("ok");
        }
    }
}
