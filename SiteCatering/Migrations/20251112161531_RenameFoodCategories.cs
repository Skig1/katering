using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteCatering.Migrations
{
    /// <inheritdoc />
    public partial class RenameFoodCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "746c0e2b-02ca-4cb3-a841-c76b1b7aeaea", "cf305b4e-dd86-4515-8381-4971a495b119" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "746c0e2b-02ca-4cb3-a841-c76b1b7aeaea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf305b4e-dd86-4515-8381-4971a495b119");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7b0011d3-8f20-4684-9958-28ca21a185e2", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8eee69f3-3d09-4d8d-8830-1c9b8595376e", 0, "8c52de01-6396-45cb-88a3-9fdb0e53bb27", "belyanko97@yandex.ru", true, false, null, "belyanko97@yandex.ru", "ADMIN", "AQAAAAIAAYagAAAAEDckCSZ6QI5WHX0AU8ZVr4BVAGXJQEmpNLHkHlDjc0DQiQ5X1LzxGMtUDxpx+vUhEg==", null, true, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7b0011d3-8f20-4684-9958-28ca21a185e2", "8eee69f3-3d09-4d8d-8830-1c9b8595376e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7b0011d3-8f20-4684-9958-28ca21a185e2", "8eee69f3-3d09-4d8d-8830-1c9b8595376e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b0011d3-8f20-4684-9958-28ca21a185e2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8eee69f3-3d09-4d8d-8830-1c9b8595376e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "746c0e2b-02ca-4cb3-a841-c76b1b7aeaea", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cf305b4e-dd86-4515-8381-4971a495b119", 0, "d6960a2a-0091-4376-85ba-af5fda447b35", "belyanko97@yandex.ru", true, false, null, "belyanko97@yandex.ru", "ADMIN", "AQAAAAIAAYagAAAAEJs+EPFwE1+u3kQjzAx51Oat2zZ1IQs2MU7XqlTP6leobjoyatpOVsGNv5ZN6bnpbA==", null, true, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "746c0e2b-02ca-4cb3-a841-c76b1b7aeaea", "cf305b4e-dd86-4515-8381-4971a495b119" });
        }
    }
}
