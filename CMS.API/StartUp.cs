using AutoMapper;
using CMS.API.DAO;
using CMS.API.Repository;
using CMS.API.Repository.Interface;
using CMS.API.Service;
using CMS.API.Service.Interface;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: FunctionsStartup(typeof(CMS.API.StartUp))]
namespace CMS.API
{
    public class StartUp : FunctionsStartup
    {
       
        private readonly string connectionString = Environment.GetEnvironmentVariable("CMSConnectionString");
      
        public override void Configure(IFunctionsHostBuilder builder)
        {
           
            builder.Services.AddDbContext<CMSDBContext>(
                options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<ICouponService, CouponService>();
            builder.Services.AddScoped<ICouponRepository, CouponRepository>();
            builder.Services.AddScoped<IMemberRepository, MemberRepository>();
            builder.Services.AddScoped<IMemberService, MemberService>();
            builder.Services.AddAutoMapper(typeof(StartUp));
        }
    }
}
