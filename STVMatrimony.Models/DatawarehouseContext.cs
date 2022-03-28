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

        public virtual DbSet<ProfileDetails> ProfileDetails { get; set; }
        public virtual DbSet<ProfileLogCount> ProfileLogCount { get; set; }
        public virtual DbSet<ProfilePic> ProfilePic { get; set; }
        public virtual DbSet<RoleMaster> RoleMaster { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }
        public virtual DbSet<UserProfileLogs> UserProfileLogs { get; set; }
        public virtual DbSet<UserdetailsActivation> UserdetailsActivation { get; set; }
        public virtual DbSet<VwBasicProfileDetailsInfo> VwBasicProfileDetailsInfo { get; set; }
        public virtual DbSet<VwDetailProfileInfo> VwDetailProfileInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "Maadhu");

            modelBuilder.Entity<ProfileDetails>(entity =>
            {
                entity.HasKey(e => e.ProfileId)
                    .HasName("PK__ProfileD__290C88E42FB66C9A");

                entity.Property(e => e.Assetdetails)
                    .HasColumnName("assetdetails")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Birthplace)
                    .HasColumnName("birthplace")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Caste)
                    .IsRequired()
                    .HasColumnName("caste")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("datetime");

                entity.Property(e => e.Education)
                    .HasColumnName("education")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Exception)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Familydetails)
                    .HasColumnName("familydetails")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Foodstyle)
                    .HasColumnName("foodstyle")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Jobdetails)
                    .HasColumnName("jobdetails")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Star)
                    .HasColumnName("star")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfileLogCount>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__ProfileL__1788CC4C5E34CA7C");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ProfilePic>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Navamsam)
                    .HasColumnName("navamsam")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Pic1)
                    .HasColumnName("pic1")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Pic2)
                    .HasColumnName("pic2")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Pic3)
                    .HasColumnName("pic3")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Raasi)
                    .HasColumnName("raasi")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoleMaster>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__RoleMast__8AFACE1A6584E25A");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__UserDeta__536C85E50CA74C2B");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__UserDeta__A9D10534245C587C")
                    .IsUnique();

                entity.HasIndex(e => e.MobileNumber)
                    .HasName("UQ__UserDeta__250375B172410C9A")
                    .IsUnique();

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<UserProfileLogs>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ViewedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<UserdetailsActivation>(entity =>
            {
                entity.ToTable("userdetailsActivation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.Updatedby).HasColumnName("updatedby");
            });

            modelBuilder.Entity<VwBasicProfileDetailsInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwBasicProfileDetailsInfo");

                entity.Property(e => e.Birthplace)
                    .HasColumnName("birthplace")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Caste)
                    .IsRequired()
                    .HasColumnName("caste")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("datetime");

                entity.Property(e => e.Education)
                    .HasColumnName("education")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pic1)
                    .HasColumnName("pic1")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileId).HasColumnName("profileId");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwDetailProfileInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwDetailProfileInfo");

                entity.Property(e => e.Assetdetails)
                    .HasColumnName("assetdetails")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Birthplace)
                    .HasColumnName("birthplace")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Caste)
                    .IsRequired()
                    .HasColumnName("caste")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("datetime");

                entity.Property(e => e.Education)
                    .HasColumnName("education")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Exception)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Familydetails)
                    .HasColumnName("familydetails")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Foodstyle)
                    .HasColumnName("foodstyle")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Jobdetails)
                    .HasColumnName("jobdetails")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Navamsam)
                    .HasColumnName("navamsam")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Pic1)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Pic2)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Pic3)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Raasi)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Star)
                    .HasColumnName("star")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
