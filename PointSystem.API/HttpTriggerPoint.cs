using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PointSystem.API.Service.Interface;
using PointSystem.API.DomainModels;
using PointSystem.API.Service;

namespace PointSystem.API
{
    public  class HttpTriggerPoint
    {
        private readonly IPointService _pointService;

        public HttpTriggerPoint(IPointService pointService)
        {
            _pointService = pointService;
        }
        [FunctionName("HttpTriggerCalculatePoint")]
        public  async Task<IActionResult> CalculatePoint(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "calculate")] HttpRequest req,
            ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var input = JsonConvert.DeserializeObject<MemberPointModel>(requestBody);
                int points=await _pointService.CalculatePoint(input);
                return new OkObjectResult(new { response = $"{points} point(s) is collected now." });
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
        }
    }
}
