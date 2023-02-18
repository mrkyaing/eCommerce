using CMS.API.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CMS.API.DAO
{
    public class CMSDBContext: DbContext
    {
        protected readonly IConfiguration Configuration;

        public CMSDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public CMSDBContext(DbContextOptions<CMSDBContext> options): base(options){ }
        protected override void OnConfiguring(DbContextOptionsBuilder options)=>options.UseSqlServer(Configuration.GetConnectionString("CMSConnectionString"));

        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }       
       public DbSet<MemberCoupon> MemberCoupons { get; set; }
    }
}
