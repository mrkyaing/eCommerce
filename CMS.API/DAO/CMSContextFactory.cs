using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.API.DAO
{
    public class CMSContextFactory : IDesignTimeDbContextFactory<CMSDBContext>
    {
        public CMSDBContext CreateDbContext(string[] args)
        {       
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("local.settings.json")
           .Build();
            var builder = new DbContextOptionsBuilder<CMSDBContext>();
            var connectionString = configuration.GetConnectionString("CMSConnectionString");
            builder.UseSqlServer(connectionString);
            return new CMSDBContext(builder.Options);
        }
    }
}
