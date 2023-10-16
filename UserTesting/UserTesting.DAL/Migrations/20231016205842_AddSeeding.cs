using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserTesting.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11bac029-c18b-40dd-baca-2854e731149f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a8f62f8-5980-4129-8faf-213f587c6ccb", "AQAAAAIAAYagAAAAEMWE7SvfhKRPgZd2RfUAanT03ddPzg8OMjDLFTlZUd0TjQhmujAYHPzSgOzq1yIY4w==", "f8d45684-76f4-4549-845c-5f7bcd00bde0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf97c9eb-46e2-487e-9bd8-b0ec737a90e9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5a75308-996d-4a7b-9abb-3e69acf3aa35", "AQAAAAIAAYagAAAAEFk2wFG4NK1kL/2qQhkj2bvtZcI4yZ2bzYzaOVeQ3eUC2tj/inLDTvqSsqb6sll+Iw==", "1163ecd5-da4a-4642-85bc-1497e5eb6e28" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "146df55d-308b-4846-91b7-d5725b8c6045", "32f1b2c0-f313-42ca-a797-3013df971d99", "user3@example.com", "USER2@EXAMPLE.COM", "USER3", "AQAAAAIAAYagAAAAELFGBsswSAhh5+nqktf4LVW3qQhCi0U5iehKwpycyVADqNjQTiogzVYeld00IrhbVQ==", "a786cb67-d813-40d8-8844-2bcb2989915d", "User3" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d96d22fd-fbe0-4ba1-a8d0-7f076c3e3edd", "146df55d-308b-4846-91b7-d5725b8c6045" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d96d22fd-fbe0-4ba1-a8d0-7f076c3e3edd", "146df55d-308b-4846-91b7-d5725b8c6045" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "146df55d-308b-4846-91b7-d5725b8c6045");

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
        }
    }
}
