using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BdelivServices.Migrations
{
    public partial class SeedTableTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string dtNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            migrationBuilder.Sql(
                "INSERT INTO Tags (Name, CreatedAt, UpdatedAt) " +
                "VALUES ('Haut de Gamme', '" + dtNow + "','"+ dtNow +"')"
                );
            
            migrationBuilder.Sql(
                "INSERT INTO Tags (Name, CreatedAt, UpdatedAt) " +
                "VALUES ('Produit des Chefs', '" + dtNow + "','"+ dtNow +"')"
                );
            
            migrationBuilder.Sql(
                "INSERT INTO Tags (Name, CreatedAt, UpdatedAt) " +
                "VALUES ('Origine France', '" + dtNow + "','"+ dtNow +"')"
                );
            
            migrationBuilder.Sql(
                "INSERT INTO Tags (Name, CreatedAt, UpdatedAt) " +
                "VALUES ('Stock Limité', '" + dtNow + "','"+ dtNow +"')"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "DELETE FROM Tags " +
                "WHERE Name IN ('Haut de Gamme', 'Produit des Chefs', 'Origine France', 'Stock Limité')"
                );
        }
    }
}
