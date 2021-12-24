using Microsoft.EntityFrameworkCore.Migrations;

namespace LibManagerApp.Migrations
{
    public partial class RatingAdde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverUrl",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "CoverUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
