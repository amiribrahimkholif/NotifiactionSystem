using Microsoft.EntityFrameworkCore.Migrations;

namespace NotificationSystem.Migrations
{
    public partial class addissend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isSent",
                table: "EmailQueue",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSent",
                table: "EmailQueue");
        }
    }
}
