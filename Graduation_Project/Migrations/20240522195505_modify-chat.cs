using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graduation_Project.Migrations
{
    /// <inheritdoc />
    public partial class modifychat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TraineeId",
                table: "chats",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "CoachId",
                table: "chats",
                newName: "ReceiverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "chats",
                newName: "TraineeId");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "chats",
                newName: "CoachId");
        }
    }
}
