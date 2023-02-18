using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CMS.API.Utly;
using CMS.API.DomainModels;
using CMS.API.Repository.Interface;
using CMS.API.Service.Interface;

namespace CMS.API
{
    public  class HttpTriggerUser
    {
        private readonly IUserService _userService;

        public HttpTriggerUser(IUserService userService)
        {
            this._userService = userService;
        }
        [FunctionName("HttpTriggerUser")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "user/auth")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            User userCredential = JsonConvert.DeserializeObject<User>(requestBody);
            bool authenticated =await _userService.Login(userCredential);
            if (!authenticated)
                return await Task.FromResult(new UnauthorizedResult()).ConfigureAwait(false);
            else
            {
                var generateJWTToken = new GenerateJWTToken();
                string token = generateJWTToken.IssuingJWT(userCredential.Email);
                return await Task.FromResult(new OkObjectResult(new { token = $"{token}" })).ConfigureAwait(false);
            }
        }
    }
}
