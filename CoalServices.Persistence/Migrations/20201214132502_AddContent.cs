using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoalServices.Carousel.Persistence.Migrations
{
    public partial class AddContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                schema: "dbo",
                table: "Images",
                type: "VARBINARY(MAX)",
                nullable: false,
                defaultValue: new byte[] {  });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                schema: "dbo",
                table: "Images");
        }
    }
}
