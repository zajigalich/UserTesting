using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserTesting.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestUser");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11bac029-c18b-40dd-baca-2854e731149f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e1f1cce-8194-428f-bbd8-5ab46260800e", "AQAAAAIAAYagAAAAEL8AxcGvamG1rOq5xFlixYCRFp9jaT3RSpnP0NS5DHaFK+IBMy0H4H9wpSm6dycnrg==", "385ea9ab-467b-4a9f-87dc-8e1b681fd195" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c953aea8-f72d-4ac5-9f99-a181659df77d", "AQAAAAIAAYagAAAAEK0aG51QTiavbP9hDY5fqCdY0+op472KkgXtBJB0S8xmQlGwd5as7B0nh3VXmEGmIg==", "7e5b61e5-e8ff-4b8b-bb7b-9792713e204f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestUser",
                columns: table => new
                {
                    TestsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestUser", x => new { x.TestsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TestUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestUser_Tests_TestsId",
                        column: x => x.TestsId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11bac029-c18b-40dd-baca-2854e731149f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41a1facd-9b01-4994-abf8-169a341204fe", "AQAAAAIAAYagAAAAEPqJJY1f28TL0FSt83jCGxWP+0eFrV8uGJYcdkxl4JLgdCdgyYfdAPHNYdVjtI6oTA==", "32d3f2dc-14d5-4250-ad54-62baa783d913" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b9a7d65-d759-4b82-aa6e-6dbde13e82b8", "AQAAAAIAAYagAAAAEDXVohGcec6MGOqY3rBz1nvudbs+1EMnA5dNjPm8+kQsf0NYcWq2Vzfvgs6tNmz25A==", "729e5337-2575-4493-add4-cd4ba4c66d9a" });

            migrationBuilder.CreateIndex(
                name: "IX_TestUser_UsersId",
                table: "TestUser",
                column: "UsersId");
        }
    }
}
