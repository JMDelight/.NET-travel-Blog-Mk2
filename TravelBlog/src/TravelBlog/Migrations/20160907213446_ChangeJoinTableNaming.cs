using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TravelBlog.Migrations
{
    public partial class ChangeJoinTableNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PeopleExperiences",
                table: "PeopleExperiences");

            migrationBuilder.DropColumn(
                name: "PeopleExperiencesId",
                table: "PeopleExperiences");

            migrationBuilder.AddColumn<int>(
                name: "PersonExperienceId",
                table: "PeopleExperiences",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeopleExperiences",
                table: "PeopleExperiences",
                column: "PersonExperienceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PeopleExperiences",
                table: "PeopleExperiences");

            migrationBuilder.DropColumn(
                name: "PersonExperienceId",
                table: "PeopleExperiences");

            migrationBuilder.AddColumn<int>(
                name: "PeopleExperiencesId",
                table: "PeopleExperiences",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeopleExperiences",
                table: "PeopleExperiences",
                column: "PeopleExperiencesId");
        }
    }
}
