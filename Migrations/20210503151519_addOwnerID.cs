using Microsoft.EntityFrameworkCore.Migrations;

namespace FizzBuzzik.Migrations
{
    public partial class addOwnerID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "FizzBuzz",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "FizzBuzz");
        }
    }
}
