using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelBlog.Migrations
{
    public partial class AddRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExperienceId",
                table: "People",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_ExperienceId",
                table: "People",
                column: "ExperienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Experiences_ExperienceId",
                table: "People",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "ExperienceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Experiences_ExperienceId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_ExperienceId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ExperienceId",
                table: "People");
        }
    }
}
