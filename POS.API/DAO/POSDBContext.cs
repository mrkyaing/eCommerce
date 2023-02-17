﻿using Microsoft.EntityFrameworkCore;
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
        protected readonly IConfiguration Configuration;

        public POSDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("POSConnectionString"));
        }

        public DbSet<CategoryModel>  Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderItemModel> OrderItems { get; set; }
    }
}
