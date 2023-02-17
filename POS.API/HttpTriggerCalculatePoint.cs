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
    public  class HttpTriggerCalculatePoint
    {
        [FunctionName("HttpTriggerCalculatePoint")]
        public  async Task<IActionResult> ScanQRMember(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "calculatePoint")] HttpRequest req,ILogger log){

            string name = req.Query["memberqrcode"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

    }
}
