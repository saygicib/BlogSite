using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogSite.DataAccess.Migrations
{
    public partial class updated_contentSummary_in_Articles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContentSummary",
                table: "Articles",
                type: "nvarchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContentSummary",
                table: "Articles",
                type: "nvarchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");
        }
    }
}
