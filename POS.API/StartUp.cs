using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using POS.API;
using POS.API.DAO;
using POS.API.Repository.Interface;
using POS.API.Service;
using POS.API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: FunctionsStartup(typeof(StartUp))]
namespace POS.API
{
    public class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string SqlConnection = Environment.GetEnvironmentVariable("POSConnectionString");
            builder.Services.AddDbContext<POSDBContext>(
                options => options.UseSqlServer(SqlConnection));
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICatetoryRepository, CategoryRepository>();
        }

    }
}
