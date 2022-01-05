using VideoApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoApp.DBContexts
{
    public class MyDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public MyDBContext(DbContextOptions<MyDBContext> options) :base(options)  
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure

            // Map entities to tables
            modelBuilder.Entity<Movie>().ToTable("Movies");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Rental>().ToTable("Rentals");

            // Configure Primary Keys
            modelBuilder.Entity<Movie>().HasKey(m => m.Id).HasName("PK_Movies");
            modelBuilder.Entity<Customer>().HasKey(c => c.Id).HasName("PK_Customers");
            modelBuilder.Entity<Rental>().HasKey(r => r.Id).HasName("PK_Rentals");

            // Configure indexes
            modelBuilder.Entity<Movie>().HasIndex(mt => mt.Title).HasDatabaseName("Idx_Title");
            modelBuilder.Entity<Movie>().HasIndex(my => my.Year).HasDatabaseName("Idx_Year");
            modelBuilder.Entity<Customer>().HasIndex(cft => cft.FirstName).HasDatabaseName("Idx_FirstName");
            modelBuilder.Entity<Customer>().HasIndex(clt => clt.LastName).HasDatabaseName("Idx_LastName");
            modelBuilder.Entity<Rental>().HasIndex(rsr => rsr.StartRental).HasDatabaseName("Idx_StartRental");
            modelBuilder.Entity<Rental>().HasIndex(rer => rer.EndRental).HasDatabaseName("Idx_EndRental");

            // Configure columns
            modelBuilder.Entity<Movie>().Property(m => m.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Movie>().Property(m => m.Title).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Movie>().Property(m => m.Year).HasColumnType("int").IsRequired();

            modelBuilder.Entity<Customer>().Property(c => c.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.FirstName).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.LastName).HasColumnType("nvarchar(50)").IsRequired();

            modelBuilder.Entity<Rental>().Property(r => r.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Rental>().Property(r => r.StartRental).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<Rental>().Property(r => r.EndRental).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<Rental>().Property(r => r.CustomerId).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Rental>().Property(r => r.MovieId).HasColumnType("int").IsRequired();

            // Configure relationships
            modelBuilder.Entity<Rental>()
                .HasOne<Movie>().WithMany()
                .HasPrincipalKey(m => m.Id).HasForeignKey(r => r.MovieId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Rental_Movie");
            modelBuilder.Entity<Rental>()
                .HasOne<Customer>().WithMany()
                .HasPrincipalKey(c => c.Id).HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Rental_Customer");
        }
    }
}
