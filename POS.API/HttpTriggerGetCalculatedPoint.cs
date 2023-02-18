using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using MySqlX.XDevAPI;

namespace POS.API
{
    public  class HttpTriggerGetCalculatedPoint
    {
        private readonly HttpClient _client;

        public HttpTriggerGetCalculatedPoint(IHttpClientFactory httpClientFactory)
        {
            this._client = httpClientFactory.CreateClient(); ;
        }
        [FunctionName("HttpTriggerGetCalculatedPoint")]
        public  async Task<IActionResult> ScanQRMember(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "getcalculatedPoint")] HttpRequest req,ILogger log){

            var response = await _client.GetAsync(" http://localhost:7167/api/calculate");
            var message = response.Content.ReadAsStringAsync();
            return new OkObjectResult(message);
        }

    }
}
