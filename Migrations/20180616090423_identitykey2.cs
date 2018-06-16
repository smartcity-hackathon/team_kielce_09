using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GameX.Migrations
{
    public partial class identitykey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "EventParticipants",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_UserID",
                table: "EventParticipants",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_AspNetUsers_UserID",
                table: "EventParticipants",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_AspNetUsers_UserID",
                table: "EventParticipants");

            migrationBuilder.DropIndex(
                name: "IX_EventParticipants_UserID",
                table: "EventParticipants");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "EventParticipants",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
