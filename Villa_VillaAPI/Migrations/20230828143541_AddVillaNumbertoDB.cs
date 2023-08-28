using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Villa_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddVillaNumbertoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rate",
                table: "villas",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Occupancy",
                table: "villas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Meter",
                table: "villas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "villaNumbers",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_villaNumbers", x => x.VillaNo);
                });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Meter", "Occupancy", "Rate" },
                values: new object[] { new DateTime(2023, 8, 28, 19, 5, 41, 554, DateTimeKind.Local).AddTicks(1815), 550, 5, 200.0 });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Meter", "Occupancy", "Rate" },
                values: new object[] { new DateTime(2023, 8, 28, 19, 5, 41, 554, DateTimeKind.Local).AddTicks(1867), 450, 6, 200.0 });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Meter", "Occupancy", "Rate" },
                values: new object[] { new DateTime(2023, 8, 28, 19, 5, 41, 554, DateTimeKind.Local).AddTicks(1870), 350, 6, 200.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "villaNumbers");

            migrationBuilder.AlterColumn<string>(
                name: "Rate",
                table: "villas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Occupancy",
                table: "villas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Meter",
                table: "villas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Meter", "Occupancy", "Rate" },
                values: new object[] { new DateTime(2023, 8, 27, 19, 42, 21, 463, DateTimeKind.Local).AddTicks(5066), "550", "5", "220" });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Meter", "Occupancy", "Rate" },
                values: new object[] { new DateTime(2023, 8, 27, 19, 42, 21, 463, DateTimeKind.Local).AddTicks(5120), "450", "6", "200" });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Meter", "Occupancy", "Rate" },
                values: new object[] { new DateTime(2023, 8, 27, 19, 42, 21, 463, DateTimeKind.Local).AddTicks(5122), "450", "6", "200" });
        }
    }
}
