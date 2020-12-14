using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoalServices.Carousel.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Images",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FileName = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    FileExtension = table.Column<string>(type: "VARCHAR(16)", nullable: false),
                    ContentType = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    FileSize = table.Column<long>(type: "BIGINT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "Timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images",
                schema: "dbo");
        }
    }
}
