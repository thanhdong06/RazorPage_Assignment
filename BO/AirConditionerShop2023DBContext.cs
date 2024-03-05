using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BO
{
    public partial class AirConditionerShop2023DBContext : DbContext
    {
        public AirConditionerShop2023DBContext()
        {
        }

        public AirConditionerShop2023DBContext(DbContextOptions<AirConditionerShop2023DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AirConditioner> AirConditioners { get; set; } = null!;
        public virtual DbSet<StaffMember> StaffMembers { get; set; } = null!;
        public virtual DbSet<SupplierCompany> SupplierCompanies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionStringsss());
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        private string GetConnectionStringsss()
        {
            IConfiguration config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
            var strConn = config.GetConnectionString("DBConnect");

            return strConn;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirConditioner>(entity =>
            {
                entity.ToTable("AirConditioner");

                entity.Property(e => e.AirConditionerId).ValueGeneratedNever();

                entity.Property(e => e.AirConditionerName).HasMaxLength(200);

                entity.Property(e => e.FeatureFunction).HasMaxLength(250);

                entity.Property(e => e.SoundPressureLevel).HasMaxLength(80);

                entity.Property(e => e.SupplierId).HasMaxLength(20);

                entity.Property(e => e.Warranty).HasMaxLength(60);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.AirConditioners)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__AirCondit__Suppl__29572725");
            });

            modelBuilder.Entity<StaffMember>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK__StaffMem__0CF04B382F72764D");

                entity.ToTable("StaffMember");

                entity.HasIndex(e => e.EmailAddress, "UQ__StaffMem__49A14740740FB76B")
                    .IsUnique();

                entity.Property(e => e.MemberId)
                    .ValueGeneratedNever()
                    .HasColumnName("MemberID");

                entity.Property(e => e.EmailAddress).HasMaxLength(60);

                entity.Property(e => e.FullName).HasMaxLength(60);

                entity.Property(e => e.Password).HasMaxLength(40);
            });

            modelBuilder.Entity<SupplierCompany>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("PK__Supplier__4BE666B4A4B9F7E5");

                entity.ToTable("SupplierCompany");

                entity.Property(e => e.SupplierId).HasMaxLength(20);

                entity.Property(e => e.PlaceOfOrigin).HasMaxLength(60);

                entity.Property(e => e.SupplierDescription).HasMaxLength(250);

                entity.Property(e => e.SupplierName).HasMaxLength(80);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
