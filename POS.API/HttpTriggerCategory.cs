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
using POS.API.Domain;

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
        public  async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "category/all")] HttpRequest req,
            ILogger log)
        {
            var categories =categoryService.GetAll();
            return new OkObjectResult(categories);
        }

        [FunctionName("HttpTriggerCategoryCreate")]
        public async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "category/post")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<CategoryModel>(requestBody);
            await categoryService.CreateAsync(input);
            
            return new OkObjectResult("successed");
        }
    }
}
