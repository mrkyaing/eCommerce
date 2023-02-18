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
using CMS.API.Service;

namespace CMS.API
{
    public  class HttpTriggerMember
    {
        private readonly IMemberService _memberService;

        public HttpTriggerMember(IMemberService memberService)
        {
            _memberService = memberService;
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
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var input = JsonConvert.DeserializeObject<Member>(requestBody);
                await _memberService.Register(input);
                return new OkObjectResult("register successed");
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
        }
    }
}
