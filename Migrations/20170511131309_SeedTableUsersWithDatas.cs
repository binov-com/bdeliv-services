using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BdelivServices.Migrations
{
    public partial class SeedTableUsersWithDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string dtNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            migrationBuilder.Sql(
                "INSERT INTO Users (CreatedAt, Email, FirstName, Gender, IsAdmin, LastLoginAt, LastName, Mobile, Phone, Status, UpdatedAt, IsDelivery, Valid) " +
                "VALUES ('" + dtNow + "', 'bessam.benyahya@gmail.com', 'Bessam', 'Mr', 1, '" + dtNow + "', 'BEN YAHYA', '06 01 01 01 01', '01 01 01 01 01', 1, '" + dtNow + "', 1, 0)"
            );

            migrationBuilder.Sql(
                "INSERT INTO Users (CreatedAt, Email, FirstName, Gender, IsAdmin, LastLoginAt, LastName, Mobile, Phone, Status, UpdatedAt, IsDelivery, Valid) " +
                "VALUES ('" + dtNow + "', 'slesage@bdeliv.com', 'Sophie', 'Mme', 1, '" + dtNow + "', 'LESAGE', '06 01 01 01 01', '01 01 01 01 01', 1, '" + dtNow + "', 0, 0)"
            );

            migrationBuilder.Sql(
                "INSERT INTO Users (CreatedAt, Email, FirstName, Gender, IsAdmin, LastLoginAt, LastName, Mobile, Phone, Status, UpdatedAt, IsDelivery, Valid) " +
                "VALUES ('" + dtNow + "', 'ncherdoud@gmail.com', 'Nora', 'Mme', 0, '" + dtNow + "', 'CHERDOUD', '06 01 01 01 01', '01 01 01 01 01', 1, '" + dtNow + "', 1, 0)"
            );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "DELETE FROM Users " +
                "WHERE Telephone = '01 01 01 01 01'"
                );
        }
    }
}
