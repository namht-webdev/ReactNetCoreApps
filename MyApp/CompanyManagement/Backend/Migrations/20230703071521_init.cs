using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    department_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    department_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    floor = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "level",
                columns: table => new
                {
                    level_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    level_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_level", x => x.level_id);
                });

            migrationBuilder.CreateTable(
                name: "province",
                columns: table => new
                {
                    province_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    province_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    province_name2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postal_code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_province", x => x.province_id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    role_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "district",
                columns: table => new
                {
                    district_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    district_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    district_name2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    province_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_district", x => x.district_id);
                    table.ForeignKey(
                        name: "FK_district_province_province_id",
                        column: x => x.province_id,
                        principalTable: "province",
                        principalColumn: "province_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ward",
                columns: table => new
                {
                    ward_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ward_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ward_name2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    district_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ward", x => x.ward_id);
                    table.ForeignKey(
                        name: "FK_ward_district_district_id",
                        column: x => x.district_id,
                        principalTable: "district",
                        principalColumn: "district_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "addresse",
                columns: table => new
                {
                    address_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ward_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresse", x => x.address_id);
                    table.ForeignKey(
                        name: "FK_addresse_ward_ward_id",
                        column: x => x.ward_id,
                        principalTable: "ward",
                        principalColumn: "ward_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birth_date = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_start = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    date_end = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    salary = table.Column<double>(type: "float", nullable: false),
                    department_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    level_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    role_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_user_addresse_address_id",
                        column: x => x.address_id,
                        principalTable: "addresse",
                        principalColumn: "address_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_department_department_id",
                        column: x => x.department_id,
                        principalTable: "department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_level_level_id",
                        column: x => x.level_id,
                        principalTable: "level",
                        principalColumn: "level_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "announcement",
                columns: table => new
                {
                    annc_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    department_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    date = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_announcement", x => x.annc_id);
                    table.ForeignKey(
                        name: "FK_announcement_department_department_id",
                        column: x => x.department_id,
                        principalTable: "department",
                        principalColumn: "department_id");
                    table.ForeignKey(
                        name: "FK_announcement_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "fingerprinting",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    date = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    comein_time = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    comeout_time = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fingerprinting", x => new { x.user_id, x.date });
                    table.ForeignKey(
                        name: "FK_fingerprinting_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "requirement",
                columns: table => new
                {
                    requirement_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    from_user = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    to_user = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    date = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    require_message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requirement", x => x.requirement_id);
                    table.ForeignKey(
                        name: "FK_requirement_user_from_user",
                        column: x => x.from_user,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requirement_user_to_user",
                        column: x => x.to_user,
                        principalTable: "user",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "schedule",
                columns: table => new
                {
                    schedule_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    date = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time_start = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time_end = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedule", x => x.schedule_id);
                    table.ForeignKey(
                        name: "FK_schedule_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresse_ward_id",
                table: "addresse",
                column: "ward_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_announcement_department_id",
                table: "announcement",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_announcement_user_id",
                table: "announcement",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_district_province_id",
                table: "district",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "IX_requirement_from_user",
                table: "requirement",
                column: "from_user");

            migrationBuilder.CreateIndex(
                name: "IX_requirement_to_user",
                table: "requirement",
                column: "to_user");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_user_id",
                table: "schedule",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_address_id",
                table: "user",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_department_id",
                table: "user",
                column: "department_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_level_id",
                table: "user",
                column: "level_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_role_id",
                table: "user",
                column: "role_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ward_district_id",
                table: "ward",
                column: "district_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "announcement");

            migrationBuilder.DropTable(
                name: "fingerprinting");

            migrationBuilder.DropTable(
                name: "requirement");

            migrationBuilder.DropTable(
                name: "schedule");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "addresse");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "level");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "ward");

            migrationBuilder.DropTable(
                name: "district");

            migrationBuilder.DropTable(
                name: "province");
        }
    }
}
