using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PointSystem.API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSystem.API.DAO
{
    public class PointSystemDBContext: DbContext
    {
        protected readonly IConfiguration Configuration;

        public PointSystemDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public PointSystemDBContext(DbContextOptions<PointSystemDBContext> options)
        : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("PointSystemConnectionString"));
        }
        public DbSet<Point>  Points { get; set; }
    }
}
