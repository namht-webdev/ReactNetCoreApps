using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class changelocation_info : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ward_name2",
                table: "ward");

            migrationBuilder.DropColumn(
                name: "postal_code",
                table: "province");

            migrationBuilder.DropColumn(
                name: "province_name2",
                table: "province");

            migrationBuilder.DropColumn(
                name: "district_name2",
                table: "district");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ward_name2",
                table: "ward",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "postal_code",
                table: "province",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "province_name2",
                table: "province",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "district_name2",
                table: "district",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
