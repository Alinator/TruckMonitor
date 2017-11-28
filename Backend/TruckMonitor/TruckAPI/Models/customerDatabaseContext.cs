using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TruckAPI.Models
{
    public partial class customerDatabaseContext : DbContext
    {
        public virtual DbSet<CustomerTrucks> CustomerTrucks { get; set; }

        public customerDatabaseContext(DbContextOptions<customerDatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerTrucks>(entity =>
            {
                entity.HasKey(e => e.VehicleId);

                entity.Property(e => e.VehicleId)
                    .HasColumnName("VehicleID")
                    .HasMaxLength(17)
                    .ValueGeneratedNever();

                entity.Property(e => e.Adress)
                    .HasColumnName("adress")
                    .HasMaxLength(100);

                entity.Property(e => e.CustomerCompanyName)
                    .HasColumnName("customerCompanyName")
                    .HasMaxLength(100);

                entity.Property(e => e.RegNr).HasMaxLength(6);

                entity.Property(e => e.TruckConnectionStatus)
                    .HasColumnName("truckConnectionStatus")
                    .HasMaxLength(30);
            });
        }
    }
}
