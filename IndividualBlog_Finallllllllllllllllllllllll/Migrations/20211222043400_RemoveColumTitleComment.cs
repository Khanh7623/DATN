using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndividualBlog.Migrations
{
    public partial class RemoveColumTitleComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 799, DateTimeKind.Local).AddTicks(7913),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 32, 13, 117, DateTimeKind.Local).AddTicks(1268));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 799, DateTimeKind.Local).AddTicks(7328),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 32, 13, 117, DateTimeKind.Local).AddTicks(271));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 780, DateTimeKind.Local).AddTicks(4708),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 32, 13, 72, DateTimeKind.Local).AddTicks(5380));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 768, DateTimeKind.Local).AddTicks(7643),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 32, 13, 55, DateTimeKind.Local).AddTicks(5626));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 795, DateTimeKind.Local).AddTicks(1319),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 32, 13, 102, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 795, DateTimeKind.Local).AddTicks(848),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 32, 13, 102, DateTimeKind.Local).AddTicks(6983));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 793, DateTimeKind.Local).AddTicks(6063),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 32, 13, 98, DateTimeKind.Local).AddTicks(4891));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 793, DateTimeKind.Local).AddTicks(5502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 32, 13, 98, DateTimeKind.Local).AddTicks(4202));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 32, 13, 117, DateTimeKind.Local).AddTicks(1268),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 799, DateTimeKind.Local).AddTicks(7913));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 32, 13, 117, DateTimeKind.Local).AddTicks(271),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 799, DateTimeKind.Local).AddTicks(7328));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 32, 13, 72, DateTimeKind.Local).AddTicks(5380),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 780, DateTimeKind.Local).AddTicks(4708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 32, 13, 55, DateTimeKind.Local).AddTicks(5626),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 768, DateTimeKind.Local).AddTicks(7643));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 32, 13, 102, DateTimeKind.Local).AddTicks(8030),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 795, DateTimeKind.Local).AddTicks(1319));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 32, 13, 102, DateTimeKind.Local).AddTicks(6983),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 795, DateTimeKind.Local).AddTicks(848));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 32, 13, 98, DateTimeKind.Local).AddTicks(4891),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 793, DateTimeKind.Local).AddTicks(6063));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 22, 11, 32, 13, 98, DateTimeKind.Local).AddTicks(4202),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 22, 11, 33, 59, 793, DateTimeKind.Local).AddTicks(5502));
        }
    }
}
