using Microsoft.EntityFrameworkCore.Migrations;

namespace BroadwayReview.DataAccess.Migrations
{
    public partial class PlayTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Plays_Title",
                table: "Plays");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Plays_Title",
                table: "Plays",
                column: "Title",
                unique: true);
        }
    }
}
