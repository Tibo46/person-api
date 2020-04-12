using Microsoft.EntityFrameworkCore.Migrations;

namespace person_api.Migrations
{
    public partial class AddPersonsPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Persons",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: "384b1855-c8e4-4641-a570-1a0dc6a08fe2",
                column: "Photo",
                value: "https://assets.cloudylab.co.uk/eintech/assets/henry-gray.jpg");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: "43a2abde-1902-4db6-96a4-0c6e9ad198cd",
                column: "Photo",
                value: "https://assets.cloudylab.co.uk/eintech/assets/florence-nightingale.jpg");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: "95119dc4-816c-4213-b86b-56c13045c22e",
                column: "Photo",
                value: "https://assets.cloudylab.co.uk/eintech/assets/walt-whitman.jpg");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: "af2bdcf0-7bc3-420d-b06f-9e780aaf01d0",
                column: "Photo",
                value: "https://assets.cloudylab.co.uk/eintech/assets/joseph-lister.jpg");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: "b7236db2-9513-4442-8fcb-fee7dead1aac",
                column: "Photo",
                value: "https://assets.cloudylab.co.uk/eintech/assets/alexander-fleming.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Persons");
        }
    }
}
