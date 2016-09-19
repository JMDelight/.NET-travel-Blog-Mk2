using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TravelBlog.Models;

namespace TravelsBlog.Migrations
{
    [DbContext(typeof(TravelBlogContext))]
    partial class TravelBlogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TravelBlog.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("LocationId");

                    b.HasKey("ExperienceId");

                    b.HasIndex("LocationId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("TravelBlog.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("TravelBlog.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("PersonId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("TravelBlog.Models.PersonExperience", b =>
                {
                    b.Property<int>("PeopleExperiencesId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExperienceId");

                    b.Property<int>("PersonId");

                    b.HasKey("PeopleExperiencesId");

                    b.HasIndex("ExperienceId");

                    b.HasIndex("PersonId");

                    b.ToTable("PeopleExperiences");
                });

            modelBuilder.Entity("TravelsBlog.Models.Detail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("SuggestionId");

                    b.HasKey("DetailId");

                    b.HasIndex("SuggestionId");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("TravelsBlog.Models.Suggestion", b =>
                {
                    b.Property<int>("SuggestionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Destination");

                    b.Property<bool>("Visited");

                    b.Property<int>("Votes");

                    b.HasKey("SuggestionId");

                    b.ToTable("Suggestions");
                });

            modelBuilder.Entity("TravelBlog.Models.Experience", b =>
                {
                    b.HasOne("TravelBlog.Models.Location", "Location")
                        .WithMany("Experiences")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelBlog.Models.PersonExperience", b =>
                {
                    b.HasOne("TravelBlog.Models.Experience", "Experience")
                        .WithMany("People")
                        .HasForeignKey("ExperienceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelBlog.Models.Person", "Person")
                        .WithMany("PeopleExperiences")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelsBlog.Models.Detail", b =>
                {
                    b.HasOne("TravelsBlog.Models.Suggestion", "Suggestion")
                        .WithMany("Details")
                        .HasForeignKey("SuggestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
