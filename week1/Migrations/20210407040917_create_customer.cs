using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace week1.Migrations
{
    public partial class create_customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("80f5e2a1-95a5-40d4-a258-22614f1c2677"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a6118cf1-7519-414a-8ab5-1972e8a3b411"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("be4758a7-c2bc-499e-aca4-02ff30d3084a"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f0c6f12e-d753-49dd-b107-78edebf98402"));

            migrationBuilder.EnsureSchema(
                name: "sale");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "sale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    BankAccount = table.Column<string>(maxLength: 15, nullable: false),
                    ATMCode = table.Column<string>(maxLength: 6, nullable: false),
                    Balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("89acb69a-3d4c-40b1-8556-c7196d07fd18"), "user" },
                    { new Guid("608bdb54-dc04-4b9e-a8c5-5cea9c07c302"), "Manager" },
                    { new Guid("50a6abee-995f-4d92-a187-f28a752024f3"), "Admin" },
                    { new Guid("09ac1040-dbbe-443b-895d-e20556a94462"), "Developer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer",
                schema: "sale");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("09ac1040-dbbe-443b-895d-e20556a94462"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("50a6abee-995f-4d92-a187-f28a752024f3"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("608bdb54-dc04-4b9e-a8c5-5cea9c07c302"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("89acb69a-3d4c-40b1-8556-c7196d07fd18"));

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("80f5e2a1-95a5-40d4-a258-22614f1c2677"), "user" },
                    { new Guid("be4758a7-c2bc-499e-aca4-02ff30d3084a"), "Manager" },
                    { new Guid("f0c6f12e-d753-49dd-b107-78edebf98402"), "Admin" },
                    { new Guid("a6118cf1-7519-414a-8ab5-1972e8a3b411"), "Developer" }
                });
        }
    }
}
