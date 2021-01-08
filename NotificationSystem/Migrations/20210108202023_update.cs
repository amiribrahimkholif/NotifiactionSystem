using Microsoft.EntityFrameworkCore.Migrations;

namespace NotificationSystem.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isSent",
                table: "SmsQueue",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSent",
                table: "SmsQueue");
        }
    }
}
