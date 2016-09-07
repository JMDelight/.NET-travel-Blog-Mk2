using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TravelBlog.Models
{
    public class TravelBlogDbContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonExperience> PeopleExperiences { get; set;}

        public TravelBlogDbContext(DbContextOptions<TravelBlogDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonExperience>()
                 .HasKey(experience => new { experience.ExperienceId, experience.PersonId });

            modelBuilder.Entity<PersonExperience>()
                .HasOne(person => person.Person)
                .WithMany(person => person.PeopleExperiences)
                .HasForeignKey(person => person.PersonId);

            modelBuilder.Entity<PersonExperience>()
                .HasOne(person => person.Experience)
                .WithMany(experience => experience.PeopleExperiences)
                .HasForeignKey(person => person.ExperienceId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TravelBlog;integrated security=True");
        }
    }
}
