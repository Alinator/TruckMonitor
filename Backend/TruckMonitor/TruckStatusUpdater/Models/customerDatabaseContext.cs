using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TruckStatusUpdater.Models
{
    public partial class customerDatabaseContext : DbContext
    {
        public virtual DbSet<CustomerTrucks> CustomerTrucks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=alinazarsqlserver.database.windows.net;User=alinazar;Password=Muhammad9429;Encrypt=True;Database=customerDatabase;Trusted_Connection=False;");
            }
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
