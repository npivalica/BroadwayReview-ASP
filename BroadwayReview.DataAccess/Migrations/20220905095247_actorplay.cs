using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BroadwayReview.DataAccess.Migrations
{
    public partial class actorplay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PlayGenres");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PlayGenres");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "PlayGenres");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlayGenres");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PlayGenres");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "PlayGenres");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PlayGenres");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ActorPlays");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ActorPlays");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ActorPlays");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ActorPlays");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ActorPlays");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ActorPlays");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PlayGenres",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PlayGenres",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "PlayGenres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PlayGenres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PlayGenres",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "PlayGenres",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PlayGenres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ActorPlays",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ActorPlays",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "ActorPlays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ActorPlays",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ActorPlays",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ActorPlays",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
