using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PointSystem.API.DomainModels;


namespace PointSystem.API.DAO{
    public class PointSystemDBContext: DbContext{
        protected readonly IConfiguration Configuration;

        public PointSystemDBContext(IConfiguration configuration) {
            Configuration = configuration;
        }
        public PointSystemDBContext(DbContextOptions<PointSystemDBContext> options): base(options){ }
        protected override void OnConfiguring(DbContextOptionsBuilder options)=> options.UseSqlServer(Configuration.GetConnectionString("PointSystemConnectionString"));
        public DbSet<Point>  Points { get; set; }
    }
}
