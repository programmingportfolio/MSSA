using Microsoft.EntityFrameworkCore.Migrations;

namespace Reef.Model.Migrations
{
    public partial class modify1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FishCount",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "CommonName",
                table: "Schools");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FishCount",
                table: "Surveys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CommonName",
                table: "Schools",
                nullable: true);
        }
    }
}
