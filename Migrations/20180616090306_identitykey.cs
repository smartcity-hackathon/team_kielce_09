using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GameX.Migrations
{
    public partial class identitykey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "EventParticipants",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_UsersId",
                table: "EventParticipants",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_AspNetUsers_UsersId",
                table: "EventParticipants",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_AspNetUsers_UsersId",
                table: "EventParticipants");

            migrationBuilder.DropIndex(
                name: "IX_EventParticipants_UsersId",
                table: "EventParticipants");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "EventParticipants");

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
    }
}
