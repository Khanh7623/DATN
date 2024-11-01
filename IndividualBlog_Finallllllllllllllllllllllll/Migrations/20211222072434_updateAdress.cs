using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndividualBlog.Migrations
{
    public partial class updateAdress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 14, 24, 34, 533, DateTimeKind.Local).AddTicks(6689),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 799, DateTimeKind.Local).AddTicks(7913));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 14, 24, 34, 533, DateTimeKind.Local).AddTicks(6263),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 799, DateTimeKind.Local).AddTicks(7328));

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Users",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 14, 24, 34, 517, DateTimeKind.Local).AddTicks(4262),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 780, DateTimeKind.Local).AddTicks(4708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 14, 24, 34, 507, DateTimeKind.Local).AddTicks(9069),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 768, DateTimeKind.Local).AddTicks(7643));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 14, 24, 34, 529, DateTimeKind.Local).AddTicks(6195),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 795, DateTimeKind.Local).AddTicks(1319));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 14, 24, 34, 529, DateTimeKind.Local).AddTicks(5695),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 795, DateTimeKind.Local).AddTicks(848));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 14, 24, 34, 528, DateTimeKind.Local).AddTicks(2361),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 793, DateTimeKind.Local).AddTicks(6063));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 14, 24, 34, 528, DateTimeKind.Local).AddTicks(1908),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 793, DateTimeKind.Local).AddTicks(5502));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 799, DateTimeKind.Local).AddTicks(7913),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 14, 24, 34, 533, DateTimeKind.Local).AddTicks(6689));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 799, DateTimeKind.Local).AddTicks(7328),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 14, 24, 34, 533, DateTimeKind.Local).AddTicks(6263));

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Users",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 780, DateTimeKind.Local).AddTicks(4708),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 14, 24, 34, 517, DateTimeKind.Local).AddTicks(4262));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 768, DateTimeKind.Local).AddTicks(7643),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 14, 24, 34, 507, DateTimeKind.Local).AddTicks(9069));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 795, DateTimeKind.Local).AddTicks(1319),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 14, 24, 34, 529, DateTimeKind.Local).AddTicks(6195));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 795, DateTimeKind.Local).AddTicks(848),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 14, 24, 34, 529, DateTimeKind.Local).AddTicks(5695));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 793, DateTimeKind.Local).AddTicks(6063),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 14, 24, 34, 528, DateTimeKind.Local).AddTicks(2361));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 793, DateTimeKind.Local).AddTicks(5502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 14, 24, 34, 528, DateTimeKind.Local).AddTicks(1908));
        }
    }
}
