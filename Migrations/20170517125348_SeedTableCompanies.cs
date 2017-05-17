using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BdelivServices.Migrations
{
    public partial class SeedTableCompanies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string dtNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            migrationBuilder.Sql(
                "INSERT INTO Companies (Name, Registration, Address1, Zip, City, CreatedAt, UpdatedAt) " +
                "VALUES ('LE FOUQUET S', '402 594 006', '46 Avenue George V', '75008', 'Paris', '" + dtNow + "','"+ dtNow +"')"
                );

            migrationBuilder.Sql(
                "INSERT INTO Companies (Name, Registration, Address1, Zip, City, CreatedAt, UpdatedAt) " +
                "VALUES ('LA ROTONDE', '821 514 072', '105 Boulevard du Montparnasse', '75006', 'Paris', '" + dtNow + "','"+ dtNow +"')"
                );           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "DELETE FROM Companies " +
                "WHERE Name IN ('LE FOUQUET S', 'LA ROTONDE')"
                );
        }
    }
}
