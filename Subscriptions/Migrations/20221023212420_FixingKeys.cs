using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Subscriptions.Migrations
{
    public partial class FixingKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrentPeriondEndDate",
                table: "Subscriptions",
                newName: "CurrentPeriodEndDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrentPeriodEndDate",
                table: "Subscriptions",
                newName: "CurrentPeriondEndDate");
        }
    }
}
