using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using bdeliv_services.Persistence;

namespace BdelivServices.Migrations
{
    [DbContext(typeof(BdelivDbContext))]
    [Migration("20170510145730_SeedTableCategoriesAndProducts")]
    partial class SeedTableCategoriesAndProducts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("bdeliv_services.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("ImgName")
                        .HasMaxLength(512);

                    b.Property<string>("ImgPath")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<bool>("Status");

                    b.Property<decimal>("Tax");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("bdeliv_services.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("ImgName")
                        .HasMaxLength(128);

                    b.Property<string>("Measure")
                        .HasMaxLength(32);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Origin")
                        .HasMaxLength(128);

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<bool>("Status");

                    b.Property<decimal>("Tax");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<decimal>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("bdeliv_services.Models.Product", b =>
                {
                    b.HasOne("bdeliv_services.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
