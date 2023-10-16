using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserTesting.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenameField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11bac029-c18b-40dd-baca-2854e731149f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e312bb62-fb35-4f59-a9f4-6a926cc807bd", "AQAAAAIAAYagAAAAEOt9fZnlHnYn3kMeWbmZMswnuk7u+ky4qze79UV1+pcU83rwx0WclYxA2Pfd/ATmRQ==", "6883715c-3dec-4a52-8a81-1f7c1b2d9d34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb31e26e-ced9-43be-9108-4d251071fc2e", "AQAAAAIAAYagAAAAEJbVAoTDEMrP2xPxOU7GPnhm5CXIFiq9JBMDRhbaASmXTVHbygV64V4IXPgqg+jRYA==", "13b2222a-f746-41e4-9ae2-be4f296bb9ad" });

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: new Guid("0ccda22e-372a-48ef-afc6-9dc8b41007e1"),
                column: "Questions",
                value: "[{\"Ordinal\":1,\"Text\":\"Question 1\",\"Options\":[{\"Ordinal\":1,\"Text\":\"Option 1\"},{\"Ordinal\":2,\"Text\":\"Option 2\"},{\"Ordinal\":2,\"Text\":\"Option 3\"}],\"Answer\":{\"Ordinal\":1,\"Text\":\"Option 1\"}},{\"Ordinal\":2,\"Text\":\"Question 2\",\"Options\":[{\"Ordinal\":1,\"Text\":\"Option 1\"},{\"Ordinal\":2,\"Text\":\"Option 2\"},{\"Ordinal\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Ordinal\":2,\"Text\":\"Option 2\"}},{\"Ordinal\":3,\"Text\":\"Question 3\",\"Options\":[{\"Ordinal\":1,\"Text\":\"Option 1\"},{\"Ordinal\":2,\"Text\":\"Option 2\"},{\"Ordinal\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Ordinal\":3,\"Text\":\"Option 3\"}}]");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: new Guid("2cbae21d-0651-4609-b77c-a0d69af10349"),
                column: "Questions",
                value: "[{\"Ordinal\":1,\"Text\":\"Question 1\",\"Options\":[{\"Ordinal\":1,\"Text\":\"Option 1\"},{\"Ordinal\":2,\"Text\":\"Option 2\"},{\"Ordinal\":2,\"Text\":\"Option 3\"}],\"Answer\":{\"Ordinal\":1,\"Text\":\"Option 1\"}},{\"Ordinal\":2,\"Text\":\"Question 2\",\"Options\":[{\"Ordinal\":1,\"Text\":\"Option 1\"},{\"Ordinal\":2,\"Text\":\"Option 2\"},{\"Ordinal\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Ordinal\":2,\"Text\":\"Option 2\"}},{\"Ordinal\":3,\"Text\":\"Question 3\",\"Options\":[{\"Ordinal\":1,\"Text\":\"Option 1\"},{\"Ordinal\":2,\"Text\":\"Option 2\"},{\"Ordinal\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Ordinal\":3,\"Text\":\"Option 3\"}}]");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: new Guid("591928f1-0e0a-4e7b-8b9d-e5c7a7791974"),
                column: "Questions",
                value: "[{\"Ordinal\":1,\"Text\":\"Question 1\",\"Options\":[{\"Ordinal\":1,\"Text\":\"Option 1\"},{\"Ordinal\":2,\"Text\":\"Option 2\"},{\"Ordinal\":2,\"Text\":\"Option 3\"}],\"Answer\":{\"Ordinal\":1,\"Text\":\"Option 1\"}},{\"Ordinal\":2,\"Text\":\"Question 2\",\"Options\":[{\"Ordinal\":1,\"Text\":\"Option 1\"},{\"Ordinal\":2,\"Text\":\"Option 2\"},{\"Ordinal\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Ordinal\":2,\"Text\":\"Option 2\"}},{\"Ordinal\":3,\"Text\":\"Question 3\",\"Options\":[{\"Ordinal\":1,\"Text\":\"Option 1\"},{\"Ordinal\":2,\"Text\":\"Option 2\"},{\"Ordinal\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Ordinal\":3,\"Text\":\"Option 3\"}}]");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: new Guid("ba4dfdda-e505-402e-8be2-d2c619974c9e"),
                column: "Questions",
                value: "[{\"Ordinal\":1,\"Text\":\"Question 1\",\"Options\":[{\"Ordinal\":1,\"Text\":\"Option 1\"},{\"Ordinal\":2,\"Text\":\"Option 2\"},{\"Ordinal\":2,\"Text\":\"Option 3\"}],\"Answer\":{\"Ordinal\":1,\"Text\":\"Option 1\"}},{\"Ordinal\":2,\"Text\":\"Question 2\",\"Options\":[{\"Ordinal\":1,\"Text\":\"Option 1\"},{\"Ordinal\":2,\"Text\":\"Option 2\"},{\"Ordinal\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Ordinal\":2,\"Text\":\"Option 2\"}},{\"Ordinal\":3,\"Text\":\"Question 3\",\"Options\":[{\"Ordinal\":1,\"Text\":\"Option 1\"},{\"Ordinal\":2,\"Text\":\"Option 2\"},{\"Ordinal\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Ordinal\":3,\"Text\":\"Option 3\"}}]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "Tests",
                keyColumn: "Id",
                keyValue: new Guid("0ccda22e-372a-48ef-afc6-9dc8b41007e1"),
                column: "Questions",
                value: "[{\"Number\":1,\"Text\":\"Question 1\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":2,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":1,\"Text\":\"Option 1\"}},{\"Number\":2,\"Text\":\"Question 2\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":2,\"Text\":\"Option 2\"}},{\"Number\":3,\"Text\":\"Question 3\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":3,\"Text\":\"Option 3\"}}]");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: new Guid("2cbae21d-0651-4609-b77c-a0d69af10349"),
                column: "Questions",
                value: "[{\"Number\":1,\"Text\":\"Question 1\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":2,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":1,\"Text\":\"Option 1\"}},{\"Number\":2,\"Text\":\"Question 2\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":2,\"Text\":\"Option 2\"}},{\"Number\":3,\"Text\":\"Question 3\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":3,\"Text\":\"Option 3\"}}]");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: new Guid("591928f1-0e0a-4e7b-8b9d-e5c7a7791974"),
                column: "Questions",
                value: "[{\"Number\":1,\"Text\":\"Question 1\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":2,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":1,\"Text\":\"Option 1\"}},{\"Number\":2,\"Text\":\"Question 2\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":2,\"Text\":\"Option 2\"}},{\"Number\":3,\"Text\":\"Question 3\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":3,\"Text\":\"Option 3\"}}]");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: new Guid("ba4dfdda-e505-402e-8be2-d2c619974c9e"),
                column: "Questions",
                value: "[{\"Number\":1,\"Text\":\"Question 1\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":2,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":1,\"Text\":\"Option 1\"}},{\"Number\":2,\"Text\":\"Question 2\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":2,\"Text\":\"Option 2\"}},{\"Number\":3,\"Text\":\"Question 3\",\"Options\":[{\"Number\":1,\"Text\":\"Option 1\"},{\"Number\":2,\"Text\":\"Option 2\"},{\"Number\":3,\"Text\":\"Option 3\"}],\"Answer\":{\"Number\":3,\"Text\":\"Option 3\"}}]");
        }
    }
}
