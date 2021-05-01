using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkFree.Areas.Identity.Data;
using WorkFree.Models;

namespace WorkFree.Data
{
    public class WorkFreeContext : IdentityDbContext<User>
    {
        public WorkFreeContext(DbContextOptions<WorkFreeContext> options)
            : base(options)
        {
        }
        public DbSet<ListingCategory> ListingCategory { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<PricingType> PricingTypes { get; set; }
        public DbSet<Listing> Listings { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Listing>(entity =>
            {
                entity.ToTable("listings");

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.Price)
                    .HasColumnName("Price")
                    .HasColumnType("double");

                entity.Property(e => e.Score)
                    .HasColumnName("Score")
                    .HasColumnType("double");

                entity.Property(e => e.PricingTypeId)
                    .HasColumnName("PricingTypeId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ListingCategoryId)
                    .HasColumnName("ListingCategoryId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CityId)
                    .HasColumnName("CityId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserId")
                    .HasColumnType("varchar(767)");

                entity.HasOne<City>(s => s.City)
                    .WithMany(g => g.Listings)
                    .HasForeignKey(s => s.CityId);

                entity.HasOne<PricingType>(s => s.PricingType)
                    .WithMany(g => g.Listings)
                    .HasForeignKey(s => s.PricingTypeId);

                entity.HasOne<ListingCategory>(s => s.ListingCategory)
                    .WithMany(g => g.Listings)
                    .HasForeignKey(s => s.ListingCategoryId);
            });

            builder.Entity<City>(entity =>
            {
                entity.ToTable("cities");

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("varchar(30)");

                entity.HasMany<Listing>(c => c.Listings)
                    .WithOne(l => l.City)
                    .HasForeignKey(l => l.CityId);
            });

            builder.Entity<ListingCategory>(entity =>
            {
                entity.ToTable("listingcategory");

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("varchar(30)");

                entity.HasMany<Listing>(c => c.Listings)
                    .WithOne(l => l.ListingCategory)
                    .HasForeignKey(l => l.ListingCategoryId);
            });

            builder.Entity<PricingType>(entity =>
            {
                entity.ToTable("pricingtypes");

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("varchar(30)");

                entity.HasMany<Listing>(c => c.Listings)
                    .WithOne(l => l.PricingType)
                    .HasForeignKey(l => l.PricingTypeId);
            });
        }
    }
}
