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

            migrationBuilder.CreateIndex(
                name: "IX_addresse_ward_id",
                table: "addresse",
                column: "ward_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_district_province_id",
                table: "district",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "IX_ward_district_id",
                table: "ward",
                column: "district_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresse");

            migrationBuilder.DropTable(
                name: "ward");

            migrationBuilder.DropTable(
                name: "district");

            migrationBuilder.DropTable(
                name: "province");
        }
    }
}
