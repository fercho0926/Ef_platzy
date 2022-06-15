using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ef_platzy.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Effort", "Name" },
                values: new object[] { new Guid("62dd1227-8d77-4ed6-b811-ddc4530c97ae"), null, 50, "Personal Activities" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Effort", "Name" },
                values: new object[] { new Guid("d25eb6c9-b078-4771-a1a1-ccc9a7cd0755"), null, 20, "Pending Activities" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "DateCreated", "Description", "Title", "priority" },
                values: new object[] { new Guid("03ebb742-cbb2-46b4-a8a8-957f4ae873bd"), new Guid("d25eb6c9-b078-4771-a1a1-ccc9a7cd0755"), new DateTime(2022, 6, 14, 23, 17, 26, 4, DateTimeKind.Local).AddTicks(8085), null, "Public Services pay", 1 });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "DateCreated", "Description", "Title", "priority" },
                values: new object[] { new Guid("57b67926-b7fe-4a04-84d7-ec800dfdf7a5"), new Guid("d25eb6c9-b078-4771-a1a1-ccc9a7cd0755"), new DateTime(2022, 6, 14, 23, 17, 26, 4, DateTimeKind.Local).AddTicks(8121), null, "pay the house cleaning", 2 });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "DateCreated", "Description", "Title", "priority" },
                values: new object[] { new Guid("b3a7249f-5d58-4ae6-aa6b-43dd7c3d7807"), new Guid("62dd1227-8d77-4ed6-b811-ddc4530c97ae"), new DateTime(2022, 6, 14, 23, 17, 26, 4, DateTimeKind.Local).AddTicks(8125), null, "Call mom", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("03ebb742-cbb2-46b4-a8a8-957f4ae873bd"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("57b67926-b7fe-4a04-84d7-ec800dfdf7a5"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("b3a7249f-5d58-4ae6-aa6b-43dd7c3d7807"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("62dd1227-8d77-4ed6-b811-ddc4530c97ae"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("d25eb6c9-b078-4771-a1a1-ccc9a7cd0755"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
