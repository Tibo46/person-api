using Microsoft.EntityFrameworkCore.Migrations;

namespace person_api.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Nurse" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Doctor" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Biologist" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "GroupId", "Name" },
                values: new object[,]
                {
                    { "95119dc4-816c-4213-b86b-56c13045c22e", 1, "Walt Whitman" },
                    { "43a2abde-1902-4db6-96a4-0c6e9ad198cd", 1, "Florence Nightingale" },
                    { "384b1855-c8e4-4641-a570-1a0dc6a08fe2", 2, "Henry Gray" },
                    { "af2bdcf0-7bc3-420d-b06f-9e780aaf01d0", 2, "Joseph Lister" },
                    { "b7236db2-9513-4442-8fcb-fee7dead1aac", 3, "Alexander Fleming" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: "384b1855-c8e4-4641-a570-1a0dc6a08fe2");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: "43a2abde-1902-4db6-96a4-0c6e9ad198cd");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: "95119dc4-816c-4213-b86b-56c13045c22e");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: "af2bdcf0-7bc3-420d-b06f-9e780aaf01d0");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: "b7236db2-9513-4442-8fcb-fee7dead1aac");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
