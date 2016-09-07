using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TravelBlog.Migrations
{
    public partial class SetUpRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Experiences_ExperienceId",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PeopleExperiences",
                table: "PeopleExperiences");

            migrationBuilder.DropIndex(
                name: "IX_People_ExperienceId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ExperienceId",
                table: "People");

            migrationBuilder.AlterColumn<int>(
                name: "PersonExperienceId",
                table: "PeopleExperiences",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeopleExperiences",
                table: "PeopleExperiences",
                columns: new[] { "ExperienceId", "PersonId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PeopleExperiences",
                table: "PeopleExperiences");

            migrationBuilder.AlterColumn<int>(
                name: "PersonExperienceId",
                table: "PeopleExperiences",
                nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeopleExperiences",
                table: "PeopleExperiences",
                column: "PersonExperienceId");

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
    }
}
