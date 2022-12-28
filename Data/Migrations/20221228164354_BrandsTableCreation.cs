using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecisionCloud.Data.Migrations
{
    public partial class BrandsTableCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BrandLink = table.Column<string>(type: "TEXT", nullable: true),
                    BrandName = table.Column<string>(type: "TEXT", nullable: true),
                    BrandImage = table.Column<string>(type: "TEXT", nullable: true),
                    Channel_Alpha = table.Column<string>(type: "TEXT", nullable: true),
                    Channel_Beta = table.Column<string>(type: "TEXT", nullable: true),
                    Channel_Gamma = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    Cnt_Max = table.Column<int>(type: "INTEGER", nullable: false),
                    Cnt_Reg = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
