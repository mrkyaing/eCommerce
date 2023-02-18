using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Newtonsoft.Json;
using POS.API.Domain;
using POS.API.Service;
using System.IO;
using System;

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
        public  async Task<IActionResult> GetCalculatedPoint(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "getcalculatedPoint")] HttpRequest req,ILogger log){ 
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                string uri ="http://localhost:7167/api/calculate";
                var input = JsonConvert.DeserializeObject<MemberPointModel>(requestBody);
                var response = await _client.PostAsJsonAsync(uri,input);
                if (response.IsSuccessStatusCode)
                {
                    var Points = await response.Content.ReadAsStringAsync();
                    return new OkObjectResult("You got " +Points);
                }                 
                else
                {
                    return new OkObjectResult(response.StatusCode + " : Message - " + response.ReasonPhrase);
                }
                
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
        }

    }
}
