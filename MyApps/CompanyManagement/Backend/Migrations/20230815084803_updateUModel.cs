using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class updateUModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addresse",
                columns: table => new
                {
                    address_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ward_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresse", x => x.address_id);
                });

            migrationBuilder.CreateTable(
                name: "announcement",
                columns: table => new
                {
                    annc_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    department_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    user_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    message = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_announcement", x => x.annc_id);
                });

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    department_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    department_name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    floor = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "district",
                columns: table => new
                {
                    district_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    district_name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    province_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_district", x => x.district_id);
                });

            migrationBuilder.CreateTable(
                name: "fingerprinting",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    date = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    comein_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    comeout_time = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fingerprinting", x => new { x.user_id, x.date });
                });

            migrationBuilder.CreateTable(
                name: "level",
                columns: table => new
                {
                    level_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    level_name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_level", x => x.level_id);
                });

            migrationBuilder.CreateTable(
                name: "province",
                columns: table => new
                {
                    province_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    province_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_province", x => x.province_id);
                });

            migrationBuilder.CreateTable(
                name: "requirement",
                columns: table => new
                {
                    requirement_id = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    from_user = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    to_user = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    request_message = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requirement", x => x.requirement_id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    role_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    role_name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "schedule",
                columns: table => new
                {
                    schedule_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    user_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    note = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    time_start = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    time_end = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedule", x => x.schedule_id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ward_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    avatar = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    date_start = table.Column<DateTime>(type: "datetime", nullable: false),
                    date_end = table.Column<DateTime>(type: "datetime", nullable: false),
                    salary = table.Column<double>(type: "float", nullable: false),
                    department_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    level_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    role_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "ward",
                columns: table => new
                {
                    ward_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    ward_name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    district_id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ward", x => x.ward_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresse");

            migrationBuilder.DropTable(
                name: "announcement");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "district");

            migrationBuilder.DropTable(
                name: "fingerprinting");

            migrationBuilder.DropTable(
                name: "level");

            migrationBuilder.DropTable(
                name: "province");

            migrationBuilder.DropTable(
                name: "requirement");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "schedule");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "ward");
        }
    }
}
