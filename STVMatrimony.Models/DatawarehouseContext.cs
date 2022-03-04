using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace STVMatrimony.Models
{
    public partial class DatawarehouseContext : DbContext
    {
        public DatawarehouseContext()
        {
        }

        public DatawarehouseContext(DbContextOptions<DatawarehouseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminUser> AdminUser { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Customeractivation> Customeractivation { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Preferences> Preferences { get; set; }
        public virtual DbSet<VwAdminUser> VwAdminUser { get; set; }
        public virtual DbSet<VwCustomerBasicInfo> VwCustomerBasicInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "Maadhu");

            modelBuilder.Entity<AdminUser>(entity =>
            {
                entity.HasIndex(e => e.Username)
                    .HasName("UQ__AdminUse__F3DBC57268F3C8A6")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsEmailVerified).HasColumnName("isEmailVerified");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Aboutme)
                    .HasColumnName("aboutme")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Assets)
                    .HasColumnName("assets")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Birthplace)
                    .HasColumnName("birthplace")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bloodgroup)
                    .HasColumnName("bloodgroup")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("datetime");

                entity.Property(e => e.Education)
                    .HasColumnName("education")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Expectations)
                    .HasColumnName("expectations")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Income)
                    .HasColumnName("income")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Star)
                    .HasColumnName("star")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subcaste)
                    .HasColumnName("subcaste")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customeractivation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("customeractivation");

                entity.Property(e => e.Custid).HasColumnName("custid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Isblocked).HasColumnName("isblocked");

                entity.Property(e => e.Remainingprofiles).HasColumnName("remainingprofiles");

                entity.Property(e => e.Updatedby).HasColumnName("updatedby");

                entity.Property(e => e.Updatedtime)
                    .HasColumnName("updatedtime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Photos>(entity =>
            {
                entity.ToTable("photos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.Navamsam)
                    .HasColumnName("navamsam")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Pic1)
                    .HasColumnName("pic1")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Pic2)
                    .HasColumnName("pic2")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Pic3)
                    .HasColumnName("pic3")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Pic4)
                    .HasColumnName("pic4")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Raasi)
                    .HasColumnName("raasi")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Preferences>(entity =>
            {
                entity.ToTable("preferences");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Agemax).HasColumnName("agemax");

                entity.Property(e => e.Agemin).HasColumnName("agemin");

                entity.Property(e => e.Complexion)
                    .HasColumnName("complexion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.Diet)
                    .HasColumnName("diet")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Maritialstatus)
                    .HasColumnName("maritialstatus")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subcaste)
                    .HasColumnName("subcaste")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwAdminUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwAdminUser");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwCustomerBasicInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwCustomerBasicInfo");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Education)
                    .HasColumnName("education")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pic1)
                    .HasColumnName("pic1")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Pic2)
                    .HasColumnName("pic2")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
