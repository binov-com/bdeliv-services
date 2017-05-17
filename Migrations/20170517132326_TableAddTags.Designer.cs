using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using bdeliv_services.Persistence;

namespace BdelivServices.Migrations
{
    [DbContext(typeof(BdelivDbContext))]
    [Migration("20170517132326_TableAddTags")]
    partial class TableAddTags
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

            modelBuilder.Entity("bdeliv_services.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .HasMaxLength(128);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Gender")
                        .HasMaxLength(8);

                    b.Property<string>("Hash")
                        .HasMaxLength(256);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Password")
                        .HasMaxLength(256);

                    b.Property<string>("Phone")
                        .HasMaxLength(16);

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<bool>("Valid");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("bdeliv_services.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Address2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Registration")
                        .HasMaxLength(64);

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.HasKey("Id");

                    b.ToTable("Companies");
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

            modelBuilder.Entity("bdeliv_services.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("bdeliv_services.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment")
                        .HasMaxLength(1024);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .HasMaxLength(128);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Gender")
                        .HasMaxLength(8);

                    b.Property<string>("Hash")
                        .HasMaxLength(256);

                    b.Property<bool>("IsAdmin");

                    b.Property<bool>("IsDelivery");

                    b.Property<DateTime>("LastLoginAt");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Mobile")
                        .HasMaxLength(16);

                    b.Property<string>("Password")
                        .HasMaxLength(256);

                    b.Property<string>("Phone")
                        .HasMaxLength(16);

                    b.Property<bool>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<bool>("Valid");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("bdeliv_services.Models.Client", b =>
                {
                    b.HasOne("bdeliv_services.Models.Company", "Company")
                        .WithMany("Clients")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
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
