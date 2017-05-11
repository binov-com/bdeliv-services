using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BdelivServices.Migrations
{
    public partial class TableAddUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(maxLength: 1024, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    FirstName = table.Column<string>(maxLength: 128, nullable: false),
                    Gender = table.Column<string>(maxLength: 8, nullable: true),
                    Hash = table.Column<string>(maxLength: 256, nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    LastLoginAt = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(maxLength: 128, nullable: false),
                    Mobile = table.Column<string>(maxLength: 16, nullable: true),
                    Password = table.Column<string>(maxLength: 256, nullable: true),
                    Phone = table.Column<string>(maxLength: 16, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Valid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
