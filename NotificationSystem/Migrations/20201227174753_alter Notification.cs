using Microsoft.EntityFrameworkCore.Migrations;

namespace NotificationSystem.Migrations
{
    public partial class alterNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "SmsQueue",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Object",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Object",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "SmsQueue",
                newName: "phoneNumber");
        }
    }
}
