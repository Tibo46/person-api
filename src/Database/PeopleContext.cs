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
            modelBuilder.Entity<Group>()
                .HasKey(x => new { x.Id });
            modelBuilder.Entity<Group>()
                .Property(b => b.CreationDate)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Group>().HasData(new List<Group>
            {
                new Group
                {
                    Id = 1,
                    Name = "Nurse"
                },
                new Group
                {
                    Id = 2,
                    Name = "Doctor"
                },
                new Group
                {
                    Id = 3,
                    Name = "Biologist"
                }
            });

            modelBuilder.Entity<Person>()
                .HasKey(c => new { c.Id });
            modelBuilder.Entity<Person>()
                .HasIndex(x => new { x.Name });
            modelBuilder.Entity<Person>()
                .Property(b => b.CreationDate)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Person>().HasData(new List<Person>
            {
                new Person
                {
                    Id = "95119dc4-816c-4213-b86b-56c13045c22e",
                    Name = "Walt Whitman",
                    Photo = "https://assets.cloudylab.co.uk/eintech/assets/walt-whitman.jpg",
                    GroupId = 1
                },
                new Person
                {
                    Id = "43a2abde-1902-4db6-96a4-0c6e9ad198cd",
                    Name = "Florence Nightingale",
                    Photo = "https://assets.cloudylab.co.uk/eintech/assets/florence-nightingale.jpg",
                    GroupId = 1
                },
                new Person
                {
                    Id = "384b1855-c8e4-4641-a570-1a0dc6a08fe2",
                    Name = "Henry Gray",
                    Photo = "https://assets.cloudylab.co.uk/eintech/assets/henry-gray.jpg",
                    GroupId = 2
                },
                new Person
                {
                    Id = "af2bdcf0-7bc3-420d-b06f-9e780aaf01d0",
                    Name = "Joseph Lister",
                    Photo = "https://assets.cloudylab.co.uk/eintech/assets/joseph-lister.jpg",
                    GroupId = 2
                },
                new Person
                {
                    Id = "b7236db2-9513-4442-8fcb-fee7dead1aac",
                    Name = "Alexander Fleming",
                    Photo = "https://assets.cloudylab.co.uk/eintech/assets/alexander-fleming.jpg",
                    GroupId = 3
                }
            });
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
