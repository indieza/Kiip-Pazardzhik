using KiipPazardzhik.Models;
using KiipPazardzhik.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KiipPazardzhik.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

        public DbSet<WebsiteFile> WebsiteFiles { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<RegionalCollege> RegionalColleges { get; set; }

        public DbSet<Document> Documents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<News>()
                .HasMany(x => x.WebsiteFiles)
                .WithOne(x => x.News)
                .HasForeignKey(x => x.NewsId)
                .IsRequired(false);

            base.OnModelCreating(builder);
        }
    }
}