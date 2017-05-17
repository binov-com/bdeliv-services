using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BdelivServices.Migrations
{
    public partial class SeedTableClients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string dtNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            migrationBuilder.Sql(
                "INSERT INTO Clients (Email, FirstName, Gender, LastName, Phone, Valid, CreatedAt, UpdatedAt, CompanyId) " +
                "VALUES ('bessam.benyahya@gmail.com', 'Bessam', 'Mr', 'BEN YAHYA' , '06 01 01 01 01', 1, '" + dtNow + "','"+ dtNow +"', (SELECT Id FROM Companies WHERE Name = 'LE FOUQUET S'))"
                );
            
            migrationBuilder.Sql(
                "INSERT INTO Clients (Email, FirstName, Gender, LastName, Phone, Valid, CreatedAt, UpdatedAt, CompanyId) " +
                "VALUES ('claire.desproux@gmail.com', 'Claire', 'Mme', 'DESPROUX', '06 01 01 01 01', 1, '" + dtNow + "','"+ dtNow +"', (SELECT Id FROM Companies WHERE Name = 'LA ROTONDE'))"
                );
            
            migrationBuilder.Sql(
                "INSERT INTO Clients (Email, FirstName, Gender, LastName, Phone, Valid, CreatedAt, UpdatedAt, CompanyId) " +
                "VALUES ('charlotte.denis@gmail.com', 'Charlotte', 'Mme', 'DENIS', '06 01 01 01 01', 1, '" + dtNow + "','"+ dtNow +"', (SELECT Id FROM Companies WHERE Name = 'LA ROTONDE'))"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "DELETE FROM Clients " +
                "WHERE Phone = '06 01 01 01 01'"
                );
        }
    }
}
