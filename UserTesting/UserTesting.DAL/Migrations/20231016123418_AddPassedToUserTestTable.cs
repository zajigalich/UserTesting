using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserTesting.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddPassedToUserTestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Passed",
                table: "UserTests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11bac029-c18b-40dd-baca-2854e731149f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4fbf0bb8-3c87-4acb-a00b-33e465ed0e29", "AQAAAAIAAYagAAAAEFwoXJ2eiWC6CS4PKyE2reIJ+2KCoXdFxQxi+ka6xE6t4AqlfAzsJhKo2NR8s8Qmxg==", "43ce0aa7-2ac0-440a-9bbb-135969d46a96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1152b097-5402-4645-a3c4-6389d8dc1d96", "AQAAAAIAAYagAAAAEFW2MKxOHy6jXZfFd8Y8P9LOkYoCDvRaQKhLovcbNhRILaMJjMaRRr0wPZnnHM1ObQ==", "6c748b18-49c6-4e32-897d-d40eb83feb06" });

            migrationBuilder.UpdateData(
                table: "UserTests",
                keyColumns: new[] { "TestId", "UserId" },
                keyValues: new object[] { new Guid("2cbae21d-0651-4609-b77c-a0d69af10349"), "11bac029-c18b-40dd-baca-2854e731149f" },
                column: "Passed",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserTests",
                keyColumns: new[] { "TestId", "UserId" },
                keyValues: new object[] { new Guid("591928f1-0e0a-4e7b-8b9d-e5c7a7791974"), "11bac029-c18b-40dd-baca-2854e731149f" },
                column: "Passed",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserTests",
                keyColumns: new[] { "TestId", "UserId" },
                keyValues: new object[] { new Guid("ba4dfdda-e505-402e-8be2-d2c619974c9e"), "11bac029-c18b-40dd-baca-2854e731149f" },
                column: "Passed",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserTests",
                keyColumns: new[] { "TestId", "UserId" },
                keyValues: new object[] { new Guid("0ccda22e-372a-48ef-afc6-9dc8b41007e1"), "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9" },
                column: "Passed",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserTests",
                keyColumns: new[] { "TestId", "UserId" },
                keyValues: new object[] { new Guid("591928f1-0e0a-4e7b-8b9d-e5c7a7791974"), "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9" },
                column: "Passed",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Passed",
                table: "UserTests");

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
    }
}
