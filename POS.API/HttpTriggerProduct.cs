using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using POS.API.Service.Interface;
using POS.API.Domain;

namespace POS.API
{
    public  class HttpTriggerProduct
    {
        private readonly IProductService productService;

        public HttpTriggerProduct(IProductService productService)
        {
            this.productService = productService;
        }
        [FunctionName("HttpTriggerProductGet")]
        public  async Task<IActionResult> GetProducts(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "product")] HttpRequest req,
            ILogger log)
        {
            var products =await productService.GetAllAsync();
            return new OkObjectResult(products);
        }

        [FunctionName("HttpTriggerProductCreate")]
        public async Task<IActionResult> Create(
           [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "product")] HttpRequest req,
           ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var input = JsonConvert.DeserializeObject<ProductModel>(requestBody);
                await productService.CreateAsync(input);
                return new OkObjectResult(new { response = "Successed create process." });
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
        }
    }
}
