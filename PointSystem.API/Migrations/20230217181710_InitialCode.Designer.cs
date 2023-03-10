// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PointSystem.API.DAO;

#nullable disable

namespace PointSystem.API.Migrations
{
    [DbContext(typeof(PointSystemDBContext))]
    [Migration("20230217181710_InitialCode")]
    partial class InitialCode
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PointSystem.API.DomainModels.Point", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ExpiryPointDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MemberCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalPoints")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Points");
                });
#pragma warning restore 612, 618
        }
    }
}
