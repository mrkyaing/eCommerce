using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using POS.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.API.DAO
{
    public class POSDBContext: DbContext
    {
        public POSDBContext(DbContextOptions<POSDBContext> options)
            : base(options)
        { }

        public DbSet<CategoryModel>  Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderItemModel> OrderItems { get; set; }
    }
}
