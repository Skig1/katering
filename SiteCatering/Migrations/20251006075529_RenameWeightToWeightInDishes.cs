using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteCatering.Migrations
{
    /// <inheritdoc />
    public partial class RenameWeightToWeightInDishes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f2eed6fc-5f04-4dac-98e3-4fd443023f9b", "60ead9ee-9bd4-44b1-a492-6c6bc53dcb2f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2eed6fc-5f04-4dac-98e3-4fd443023f9b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60ead9ee-9bd4-44b1-a492-6c6bc53dcb2f");

            migrationBuilder.RenameColumn(
                name: "weight",
                table: "Dishes",
                newName: "Weight");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Dishes",
                newName: "weight");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2eed6fc-5f04-4dac-98e3-4fd443023f9b", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "60ead9ee-9bd4-44b1-a492-6c6bc53dcb2f", 0, "a9e9cda2-4208-47d2-a932-f61ffd7324b0", "belyanko97@yandex.ru", true, false, null, "belyanko97@yandex.ru", "ADMIN", "AQAAAAIAAYagAAAAEGHNLywHJCilwf4aTpz95izmBIWx3NTife+ImiM+2y1NofPPgUPc/6E2sM1gohdzdA==", null, true, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f2eed6fc-5f04-4dac-98e3-4fd443023f9b", "60ead9ee-9bd4-44b1-a492-6c6bc53dcb2f" });
        }
    }
}
