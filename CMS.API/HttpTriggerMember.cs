using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CMS.API.Service.Interface;
using CMS.API.DomainModels;

namespace CMS.API
{
    public  class HttpTriggerMember
    {
        private readonly IMemberService _memberService;
        private readonly IUserService _userService;

        public HttpTriggerMember(IMemberService memberService,IUserService userService)
        {
            _memberService = memberService;
            this._userService = userService;
        }
        [FunctionName("HttpTriggerMemberGet")]
        public  async Task<IActionResult> GetAll(
            [HttpTrigger(AuthorizationLevel.Anonymous ,"get", Route = "member")] HttpRequest req,
            ILogger log)
        {
            var members =await _memberService.GetList();
            return new OkObjectResult(members);
        }
        [FunctionName("HttpTriggerMemberGetById")]
        public  async Task<IActionResult> GetById(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get",Route = "member/id/{id}")] HttpRequest req,string id,
           ILogger log)
        {
            var member = await _memberService.GetById(id);
            if(member == null)
            {
                return new NotFoundObjectResult($" NOT FOUND your requested id {id}");
            }
            return new OkObjectResult(member);
        }
        [FunctionName("HttpTriggerMemberRegister")]
        public  async Task<IActionResult> Register(
           [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "member/register")] HttpRequest req,
           ILogger log)
        {
            try
            {
                User user = null ;
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var input = JsonConvert.DeserializeObject<Member>(requestBody);
               if( await _memberService.Register(input))
                {
                   user= await _userService.Create(input);                
                }
                 return new OkObjectResult(new { response = $"Member register successed ,you can login into system with DEFAULT PASSWORD!!" });
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
        }
    }
}
