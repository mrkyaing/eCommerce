using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using PointSystem.API.DAO;
using PointSystem.API.Repository;
using PointSystem.API.Repository.Interface;
using PointSystem.API.Service;
using PointSystem.API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: FunctionsStartup(typeof(PointSystem.API.StartUp))]
namespace PointSystem.API
{
    public class StartUp : FunctionsStartup
    {
       
        private readonly string connectionString = Environment.GetEnvironmentVariable("PointSystemConnectionString");
      
        public override void Configure(IFunctionsHostBuilder builder)
        {
           
            builder.Services.AddDbContext<PointSystemDBContext>(
                options => options.UseSqlServer(connectionString));

           builder.Services.AddScoped<IPointRepository, PointRepository>();
           builder.Services.AddScoped<IPointService, PointService>();
           //builder.Services.AddScoped<IProductRepository, ProductRepository>();
        }
       
    }
}
