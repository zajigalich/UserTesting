using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserTesting.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d96d22fd-fbe0-4ba1-a8d0-7f076c3e3edd", "d96d22fd-fbe0-4ba1-a8d0-7f076c3e3edd", "User", "USER" });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "d96d22fd-fbe0-4ba1-a8d0-7f076c3e3edd", "11bac029-c18b-40dd-baca-2854e731149f" },
                    { "d96d22fd-fbe0-4ba1-a8d0-7f076c3e3edd", "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d96d22fd-fbe0-4ba1-a8d0-7f076c3e3edd", "11bac029-c18b-40dd-baca-2854e731149f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d96d22fd-fbe0-4ba1-a8d0-7f076c3e3edd", "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d96d22fd-fbe0-4ba1-a8d0-7f076c3e3edd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11bac029-c18b-40dd-baca-2854e731149f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81508461-8dc4-411a-8ae9-d7f6761f845c", "AQAAAAIAAYagAAAAELXX5oFty1hdyPJx9GYfXqMw94bmSP08UOQNiPRavNUzhNzDcJuo0NW3IpPRpDDZPw==", "075cc6c6-aee1-44db-a756-4c49c6daa224" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "621a65d8-9d47-48db-824c-2d33b0f4d9a1", "AQAAAAIAAYagAAAAEBDEMgxDLApN+1wmQ1DT273w5THHbCSR9jOM8k3Ox4N3NjZyLpYitTYdgQevxeKbCg==", "417f1c6e-2369-4197-a343-963062b10818" });
        }
    }
}
