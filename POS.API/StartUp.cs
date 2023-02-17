using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using POS.API;
using POS.API.DAO;
using POS.API.Repository.Interface;
using POS.API.Service;
using POS.API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: FunctionsStartup(typeof(POS.API.StartUp))]
namespace POS.API
{
    public class StartUp : FunctionsStartup
    {
       
        private readonly string connectionString = Environment.GetEnvironmentVariable("POSConnectionString");
      
        public override void Configure(IFunctionsHostBuilder builder)
        {
           
            builder.Services.AddDbContext<POSDBContext>(
                options => options.UseSqlServer(connectionString));

         

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICatetoryRepository, CategoryRepository>();
        }
       
    }
}
