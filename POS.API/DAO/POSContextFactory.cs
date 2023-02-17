using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.IO;

namespace POS.API.DAO
{
    public class POSContextFactory : IDesignTimeDbContextFactory<POSDBContext>
    {
        public POSDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("local.settings.json")
           .Build();
            var builder = new DbContextOptionsBuilder<POSDBContext>();
            var connectionString = configuration.GetConnectionString("POSConnectionString");
            builder.UseSqlServer(connectionString);
            return new POSDBContext(builder.Options);
        }
    }
}
