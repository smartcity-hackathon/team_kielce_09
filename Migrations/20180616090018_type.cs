using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GameX.Migrations
{
    public partial class type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_Users_UserID",
                table: "EventParticipants");

            migrationBuilder.DropIndex(
                name: "IX_EventParticipants_UserID",
                table: "EventParticipants");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "EventParticipants",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UsersUserId",
                table: "EventParticipants",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_UsersUserId",
                table: "EventParticipants",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_Users_UsersUserId",
                table: "EventParticipants",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_Users_UsersUserId",
                table: "EventParticipants");

            migrationBuilder.DropIndex(
                name: "IX_EventParticipants_UsersUserId",
                table: "EventParticipants");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "EventParticipants");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "EventParticipants",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_UserID",
                table: "EventParticipants",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_Users_UserID",
                table: "EventParticipants",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
