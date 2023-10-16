using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserTesting.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11bac029-c18b-40dd-baca-2854e731149f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12272131-338d-46d4-94d0-9194b1747c9a", "AQAAAAIAAYagAAAAEO237Ji52DcSpLRJHbZ5QPZNqXZ+D2zXUuFll77ndGrJJzmiAjHF+UuNlh7YnjAJZQ==", "564dde50-9ab9-4e71-98db-f410b4ad5095" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa45eb55-2832-4020-979c-c50e073e23b1", "AQAAAAIAAYagAAAAEDWKuPFfoAGSWLkVIPEZbPSKMuD38RZcujf//sTTtusPy3+xLJopLCl4ZrTPL7yCzg==", "da07d961-5a13-41ab-b067-0ae58568ad57" });

            migrationBuilder.UpdateData(
                table: "UserTests",
                keyColumns: new[] { "TestId", "UserId" },
                keyValues: new object[] { new Guid("2cbae21d-0651-4609-b77c-a0d69af10349"), "11bac029-c18b-40dd-baca-2854e731149f" },
                columns: new[] { "Mark", "Passed" },
                values: new object[] { 0.3m, true });

            migrationBuilder.UpdateData(
                table: "UserTests",
                keyColumns: new[] { "TestId", "UserId" },
                keyValues: new object[] { new Guid("ba4dfdda-e505-402e-8be2-d2c619974c9e"), "11bac029-c18b-40dd-baca-2854e731149f" },
                columns: new[] { "Mark", "Passed" },
                values: new object[] { 0.8m, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "UserTests",
                keyColumns: new[] { "TestId", "UserId" },
                keyValues: new object[] { new Guid("2cbae21d-0651-4609-b77c-a0d69af10349"), "11bac029-c18b-40dd-baca-2854e731149f" },
                columns: new[] { "Mark", "Passed" },
                values: new object[] { null, false });

            migrationBuilder.UpdateData(
                table: "UserTests",
                keyColumns: new[] { "TestId", "UserId" },
                keyValues: new object[] { new Guid("ba4dfdda-e505-402e-8be2-d2c619974c9e"), "11bac029-c18b-40dd-baca-2854e731149f" },
                columns: new[] { "Mark", "Passed" },
                values: new object[] { null, false });
        }
    }
}
