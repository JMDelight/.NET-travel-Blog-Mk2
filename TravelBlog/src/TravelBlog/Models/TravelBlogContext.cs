using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TravelBlog.Models
{
    public class TravelBlogContext : DbContext
    {
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonExperience> PeopleExperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TravelBlog;integrated security=True");
        }
    }
}
