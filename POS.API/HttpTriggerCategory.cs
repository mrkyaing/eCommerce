using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using POS.API.Service.Interface;
using POS.API.Service;

namespace POS.API
{
    public  class HttpTriggerCategory
    {
        private readonly ICategoryService categoryService;

        public HttpTriggerCategory(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [FunctionName("HttpTriggerCategory")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "category/all")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var categories = categoryService.GetAllAsync();
            return new OkObjectResult(categories);
        }
    }
}
