using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSystem.API.DAO
{
    public class PointSystemContextFactory: IDesignTimeDbContextFactory<PointSystemDBContext>
    {
        public PointSystemDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("local.settings.json")
           .Build();
            var builder = new DbContextOptionsBuilder<PointSystemDBContext>();
            var connectionString = configuration.GetConnectionString("PointSystemConnectionString");
            builder.UseSqlServer(connectionString);
            return new PointSystemDBContext(builder.Options);
        }
    }
}
