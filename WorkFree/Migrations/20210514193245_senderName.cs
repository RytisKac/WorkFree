using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkFree.Migrations
{
    public partial class senderName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "Messages",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "chats",
                type: "varchar(767)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_chats_UserId",
                table: "chats",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_chats_AspNetUsers_UserId",
                table: "chats",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
