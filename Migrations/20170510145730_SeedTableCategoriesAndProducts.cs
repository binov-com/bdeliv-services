using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BdelivServices.Migrations
{
    public partial class SeedTableCategoriesAndProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string dtNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // CATEGORIES //
            migrationBuilder.Sql(
                "INSERT INTO Categories (Name, Status, Tax, CreatedAt, UpdatedAt) " +
                "VALUES ('PRODUITS DE LA MER', 1, 20, '" + dtNow + "','"+ dtNow +"')"
                );
            migrationBuilder.Sql(
                "INSERT INTO Categories (Name, Status, Tax, CreatedAt, UpdatedAt) " +
                "VALUES ('PRODUITS ASIATIQUES', 1, 20, '" + dtNow + "','"+ dtNow +"')"
                );
            migrationBuilder.Sql(
                "INSERT INTO Categories (Name, Status, Tax, CreatedAt, UpdatedAt) " +
                "VALUES ('AUTRES PRODUITS', 1, 20, '" + dtNow + "','"+ dtNow +"')"
                );


            // PRODUITS //
            migrationBuilder.Sql(
                "INSERT INTO Products (CreatedAt, Name, Price, CategoryId, Reference, Status, Tax, UpdatedAt, Weight, Measure, Origin, Quantity) " +
                "VALUES ('" + dtNow + "', 'Soupe de Poissons', 20.99, (SELECT Id FROM Categories WHERE Name = 'PRODUITS DE LA MER'), 'REF001', 1, 20, '" + dtNow + "', 900, 'g', 'France', 1)"
                );
            migrationBuilder.Sql(
                "INSERT INTO Products (CreatedAt, Name, Price, CategoryId, Reference, Status, Tax, UpdatedAt, Weight, Measure, Origin, Quantity) " +
                "VALUES ('" + dtNow + "', 'Tarama au Crabe', 10.90, (SELECT Id FROM Categories WHERE Name = 'PRODUITS DE LA MER'), 'REF002', 1, 20, '" + dtNow + "', 90, 'g', 'France', 1)"
                );
            migrationBuilder.Sql(
                "INSERT INTO Products (CreatedAt, Name, Price, CategoryId, Reference, Status, Tax, UpdatedAt, Weight, Measure, Origin, Quantity) " +
                "VALUES ('" + dtNow + "', 'Tarama au Crabe', 20.90, (SELECT Id FROM Categories WHERE Name = 'PRODUITS DE LA MER'), 'REF003', 1, 20, '" + dtNow + "', 160, 'g', 'France', 1)"
                );
            migrationBuilder.Sql(
                "INSERT INTO Products (CreatedAt, Name, Price, CategoryId, Reference, Status, Tax, UpdatedAt, Weight, Measure, Origin, Quantity) " +
                "VALUES ('" + dtNow + "', 'Tarama au Crabe', 99, (SELECT Id FROM Categories WHERE Name = 'PRODUITS DE LA MER'), 'REF005', 1, 20, '" + dtNow + "', 1, 'kg', 'France', 1)"
                );
            migrationBuilder.Sql(
                "INSERT INTO Products (CreatedAt, Name, Price, CategoryId, Reference, Status, Tax, UpdatedAt, Weight, Measure, Origin, Quantity) " +
                "VALUES ('" + dtNow + "', 'Filet de Rouget', 15.40, (SELECT Id FROM Categories WHERE Name = 'PRODUITS DE LA MER'), 'REF006', 1, 20, '" + dtNow + "', 1, 'kg', 'Océan Pacifique – Zone FAO71', 5)"
                );
            
            migrationBuilder.Sql(
                "INSERT INTO Products (CreatedAt, Name, Price, CategoryId, Reference, Status, Tax, UpdatedAt, Weight, Measure, Origin, Quantity) " +
                "VALUES ('" + dtNow + "', 'Arachides au Wasabi', 9.70, (SELECT Id FROM Categories WHERE Name = 'PRODUITS ASIATIQUES'), 'REF007', 1, 20, '" + dtNow + "', 10, 'kg', 'Chine', 1)"
                );
            migrationBuilder.Sql(
                "INSERT INTO Products (CreatedAt, Name, Price, CategoryId, Reference, Status, Tax, UpdatedAt, Weight, Measure, Origin, Quantity) " +
                "VALUES ('" + dtNow + "', 'Edamame', 10.90, (SELECT Id FROM Categories WHERE Name = 'PRODUITS ASIATIQUES'), 'REF008', 1, 20, '" + dtNow + "', 500, 'g', 'Chine', 1)"
                );
            migrationBuilder.Sql(
                "INSERT INTO Products (CreatedAt, Name, Price, CategoryId, Reference, Status, Tax, UpdatedAt, Weight, Measure, Origin, Quantity) " +
                "VALUES ('" + dtNow + "', 'Sauce Chili', 20.70, (SELECT Id FROM Categories WHERE Name = 'PRODUITS ASIATIQUES'), 'REF009', 1, 20, '" + dtNow + "', 740, 'ml', 'Chine', 1)"
                );

            migrationBuilder.Sql(
                "INSERT INTO Products (CreatedAt, Name, Price, CategoryId, Reference, Status, Tax, UpdatedAt, Weight, Measure, Origin, Quantity) " +
                "VALUES ('" + dtNow + "', 'Huile Olive arôme Truffe Noire', 29.10, (SELECT Id FROM Categories WHERE Name = 'AUTRES PRODUITS'), 'REF010', 1, 20, '" + dtNow + "', 25, 'cl', 'France', 1)"
                );
            migrationBuilder.Sql(
                "INSERT INTO Products (CreatedAt, Name, Price, CategoryId, Reference, Status, Tax, UpdatedAt, Weight, Measure, Origin, Quantity) " +
                "VALUES ('" + dtNow + "', 'Confiture « Love » (fraise-passion-pétales de roses)', 10.90, (SELECT Id FROM Categories WHERE Name = 'AUTRES PRODUITS'), 'REF011', 1, 20, '" + dtNow + "', 260, 'g', 'France', 1)"
                );
            migrationBuilder.Sql(
                "INSERT INTO Products (CreatedAt, Name, Price, CategoryId, Reference, Status, Tax, UpdatedAt, Weight, Measure, Origin, Quantity) " +
                "VALUES ('" + dtNow + "', 'Safran Moulu', 20.70, (SELECT Id FROM Categories WHERE Name = 'AUTRES PRODUITS'), 'REF012', 1, 20, '" + dtNow + "', 0.5, 'g', 'Iran', 1)"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "DELETE FROM Categories " +
                "WHERE Name IN ('PRODUITS DE LA MER', 'PRODUITS ASIATIQUES', 'AUTRES PRODUITS')"
                );
        }
    }
}
