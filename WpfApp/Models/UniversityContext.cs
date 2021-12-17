using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.Models
{
    public class UniversityContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Test> Tests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=University;Username=postgres;Password=Artik2003");

        private UniversityContext()
        {
            Database.EnsureCreated();
        }


        static UniversityContext()
        { 
            Instance = new UniversityContext();
        }
        public static UniversityContext Instance { get; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("tablefunc");


            modelBuilder.Entity<Student>(s =>
            {
                s.HasOne(s => s.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GroupId);

                s.HasMany(s => s.Grades)
                .WithOne(g => g.Student)
                .OnDelete(DeleteBehavior.Cascade);

                s.Property(s => s.BirthDate)
                .HasColumnType("timestamp without time zone");
            });

            modelBuilder.Entity<Group>(g =>
            {
                g.HasMany(g => g.Students)
                .WithOne(s => s.Group)
                .OnDelete(DeleteBehavior.Cascade);

                g.Property(g => g.StartEducation)
                .HasColumnType("timestamp without time zone");

                g.Property(g => g.EndEducation)
                .HasColumnType("timestamp without time zone");
            });

            modelBuilder.Entity<Grade>(g =>
            {
                g.HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId);

                g.HasOne(g => g.Test)
                .WithMany(t => t.Grades)
                .HasForeignKey(g => g.TestId);
            });

            modelBuilder.Entity<Teacher>(t =>
            {
                t.HasMany(t => t.Subjects)
                .WithOne(s => s.Teacher)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Test>(t =>
            {
                t.HasMany(t => t.Grades)
                .WithOne(g => g.Test)
                .OnDelete(DeleteBehavior.Cascade);

                t.HasOne(t => t.Subject)
                .WithMany(s => s.Tests)
                .HasForeignKey(t => t.SubjectId);

                t.Property(t => t.EventDate)
                .HasColumnType("timestamp without time zone");
            });

            modelBuilder.Entity<Subject>(s =>
            {
                s.HasMany(s => s.Tests)
                .WithOne(t => t.Subject)
                .OnDelete(DeleteBehavior.Cascade);

                s.HasOne(s => s.Teacher)
                .WithMany(t => t.Subjects)
                .HasForeignKey(s => s.TeacherId);
            });
        }
    }
}
