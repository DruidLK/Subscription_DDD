using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Subscriptions.Migrations
{
    public partial class RemovedSchemaForFixingTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Customer",
                schema: "Customer",
                newName: "Customer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Customer");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customer",
                newSchema: "Customer");
        }
    }
}
