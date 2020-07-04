using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DevSkill.Web.Migrations
{
    public partial class SeedIdentityData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seed Role 
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id,Name,NormalizedName) VALUES ('" + Guid.NewGuid() + "','Admin','ADMIN')");
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id,Name,NormalizedName) VALUES ('" + Guid.NewGuid() + "','Manager','MANAGER')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM AspNetRoles WHERE Name IN ('Admin','Manager')");
        }
    }
}
