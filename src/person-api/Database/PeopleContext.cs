using Microsoft.EntityFrameworkCore;
using person_api.Models;
using System;
using System.Collections.Generic;

namespace person_api.Database
{
    public class PeopleContext : DbContext
    {
        public PeopleContext() { }
        public PeopleContext(DbContextOptions<PeopleContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasKey(c => new { c.Id });
            modelBuilder.Entity<Person>()
                .HasIndex(x => new { x.Name });
            modelBuilder.Entity<Person>()
                .Property(b => b.CreationDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Group>()
                .HasKey(x => new { x.Id });
            modelBuilder.Entity<Group>()
                .Property(b => b.CreationDate)
                .HasDefaultValueSql("getdate()");
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
