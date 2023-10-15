using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserTesting.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: new Guid("488025a2-4704-4983-b3ba-3894d103c6cc"));

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: new Guid("c069b135-5c2c-4c60-81df-ee56f1554b01"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Mark",
                table: "UserTests",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[,]
                {
                    { "11bac029-c18b-40dd-baca-2854e731149f", "81508461-8dc4-411a-8ae9-d7f6761f845c", "user1@example.com", "USER1@EXAMPLE.COM", "USER1", "AQAAAAIAAYagAAAAELXX5oFty1hdyPJx9GYfXqMw94bmSP08UOQNiPRavNUzhNzDcJuo0NW3IpPRpDDZPw==", "075cc6c6-aee1-44db-a756-4c49c6daa224", "User1" },
                    { "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9", "621a65d8-9d47-48db-824c-2d33b0f4d9a1", "user2@example.com", "USER2@EXAMPLE.COM", "USER2", "AQAAAAIAAYagAAAAEBDEMgxDLApN+1wmQ1DT273w5THHbCSR9jOM8k3Ox4N3NjZyLpYitTYdgQevxeKbCg==", "417f1c6e-2369-4197-a343-963062b10818", "User2" }
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Description", "Name", "Questions" },
                values: new object[,]
                {
                    { new Guid("0ccda22e-372a-48ef-afc6-9dc8b41007e1"), "This is Test 4", "Test 4", "[{\"Number\":1,\"Text\":\"Question 1\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":2,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":1,\"Text\":\"Option 1\"}},{\"Number\":2,\"Text\":\"Question 2\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":2,\"Text\":\"Option 2\"}},{\"Number\":3,\"Text\":\"Question 3\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":3,\"Text\":\"Option 3\"}}]" },
                    { new Guid("2cbae21d-0651-4609-b77c-a0d69af10349"), "This is Test 2", "Test 2", "[{\"Number\":1,\"Text\":\"Question 1\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":2,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":1,\"Text\":\"Option 1\"}},{\"Number\":2,\"Text\":\"Question 2\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":2,\"Text\":\"Option 2\"}},{\"Number\":3,\"Text\":\"Question 3\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":3,\"Text\":\"Option 3\"}}]" },
                    { new Guid("591928f1-0e0a-4e7b-8b9d-e5c7a7791974"), "This is Test 3", "Test 3", "[{\"Number\":1,\"Text\":\"Question 1\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":2,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":1,\"Text\":\"Option 1\"}},{\"Number\":2,\"Text\":\"Question 2\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":2,\"Text\":\"Option 2\"}},{\"Number\":3,\"Text\":\"Question 3\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":3,\"Text\":\"Option 3\"}}]" },
                    { new Guid("ba4dfdda-e505-402e-8be2-d2c619974c9e"), "This is Test 1", "Test 1", "[{\"Number\":1,\"Text\":\"Question 1\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":2,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":1,\"Text\":\"Option 1\"}},{\"Number\":2,\"Text\":\"Question 2\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":2,\"Text\":\"Option 2\"}},{\"Number\":3,\"Text\":\"Question 3\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":3,\"Text\":\"Option 3\"}}]" }
                });

            migrationBuilder.InsertData(
                table: "UserTests",
                columns: new[] { "TestId", "UserId", "Mark" },
                values: new object[,]
                {
                    { new Guid("2cbae21d-0651-4609-b77c-a0d69af10349"), "11bac029-c18b-40dd-baca-2854e731149f", null },
                    { new Guid("591928f1-0e0a-4e7b-8b9d-e5c7a7791974"), "11bac029-c18b-40dd-baca-2854e731149f", null },
                    { new Guid("ba4dfdda-e505-402e-8be2-d2c619974c9e"), "11bac029-c18b-40dd-baca-2854e731149f", null },
                    { new Guid("0ccda22e-372a-48ef-afc6-9dc8b41007e1"), "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9", null },
                    { new Guid("591928f1-0e0a-4e7b-8b9d-e5c7a7791974"), "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserTests",
                keyColumns: new[] { "TestId", "UserId" },
                keyValues: new object[] { new Guid("2cbae21d-0651-4609-b77c-a0d69af10349"), "11bac029-c18b-40dd-baca-2854e731149f" });

            migrationBuilder.DeleteData(
                table: "UserTests",
                keyColumns: new[] { "TestId", "UserId" },
                keyValues: new object[] { new Guid("591928f1-0e0a-4e7b-8b9d-e5c7a7791974"), "11bac029-c18b-40dd-baca-2854e731149f" });

            migrationBuilder.DeleteData(
                table: "UserTests",
                keyColumns: new[] { "TestId", "UserId" },
                keyValues: new object[] { new Guid("ba4dfdda-e505-402e-8be2-d2c619974c9e"), "11bac029-c18b-40dd-baca-2854e731149f" });

            migrationBuilder.DeleteData(
                table: "UserTests",
                keyColumns: new[] { "TestId", "UserId" },
                keyValues: new object[] { new Guid("0ccda22e-372a-48ef-afc6-9dc8b41007e1"), "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9" });

            migrationBuilder.DeleteData(
                table: "UserTests",
                keyColumns: new[] { "TestId", "UserId" },
                keyValues: new object[] { new Guid("591928f1-0e0a-4e7b-8b9d-e5c7a7791974"), "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11bac029-c18b-40dd-baca-2854e731149f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9");

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: new Guid("0ccda22e-372a-48ef-afc6-9dc8b41007e1"));

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: new Guid("2cbae21d-0651-4609-b77c-a0d69af10349"));

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: new Guid("591928f1-0e0a-4e7b-8b9d-e5c7a7791974"));

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: new Guid("ba4dfdda-e505-402e-8be2-d2c619974c9e"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Mark",
                table: "UserTests",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Description", "Name", "Questions" },
                values: new object[,]
                {
                    { new Guid("488025a2-4704-4983-b3ba-3894d103c6cc"), "This is Test 2", "Test 2", "[{\"Number\":1,\"Text\":\"Question 1\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":2,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":1,\"Text\":\"Option 1\"}},{\"Number\":2,\"Text\":\"Question 2\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":2,\"Text\":\"Option 2\"}},{\"Number\":3,\"Text\":\"Question 3\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":3,\"Text\":\"Option 3\"}}]" },
                    { new Guid("c069b135-5c2c-4c60-81df-ee56f1554b01"), "This is Test 1", "Test 1", "[{\"Number\":1,\"Text\":\"Question 1\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":2,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":1,\"Text\":\"Option 1\"}},{\"Number\":2,\"Text\":\"Question 2\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":2,\"Text\":\"Option 2\"}},{\"Number\":3,\"Text\":\"Question 3\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":3,\"Text\":\"Option 3\"}}]" }
                });
        }
    }
}
