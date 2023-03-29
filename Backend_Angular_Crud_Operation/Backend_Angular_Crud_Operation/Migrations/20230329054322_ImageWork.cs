using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Angular_Crud_Operation.Migrations
{
    public partial class ImageWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "students",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "students");
        }
    }
}
