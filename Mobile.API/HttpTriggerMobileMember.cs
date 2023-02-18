using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using Mobile.API.DomainModels;

namespace Mobile.API
{
    public  class HttpTriggerMobileMember
    {
        private readonly HttpClient _client;
        public HttpTriggerMobileMember(IHttpClientFactory httpClientFactory)
        {
            this._client = httpClientFactory.CreateClient();
        }

        [FunctionName("HttpTriggerMobileMember")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "mobile/member/register")] HttpRequest req,
            ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                string uri = " http://localhost:7161/api/member/register";
                var input = JsonConvert.DeserializeObject<MemberModel>(requestBody);
                var response = await _client.PostAsJsonAsync(uri, input);
                if (response.IsSuccessStatusCode)
                {
                    var Points = await response.Content.ReadAsStringAsync();
                    return new OkObjectResult(Points);
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
