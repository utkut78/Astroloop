using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MetixChargeStation.Models;

public partial class MetixChargeStationContext : DbContext
{
    public MetixChargeStationContext()
    {
    }

    public MetixChargeStationContext(DbContextOptions<MetixChargeStationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountGroup> AccountGroups { get; set; }

    public virtual DbSet<CarModel> CarModels { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Opportunity> Opportunities { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sensor> Sensors { get; set; }

    public virtual DbSet<SensorType> SensorTypes { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRoleClaim> UserRoleClaims { get; set; }

    public virtual DbSet<UserToRole> UserToRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=constring");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.Property(e => e.Address)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.AuthorizedPerson).HasMaxLength(50);
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TaxOffice)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Group).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_Accounts_AccountGroups");

            entity.HasOne(d => d.Station).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.StationId)
                .HasConstraintName("FK_Accounts_Stations1");
        });

        modelBuilder.Entity<AccountGroup>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<CarModel>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Plate).HasMaxLength(9);

            entity.HasMany(d => d.Users).WithMany(p => p.Cards)
                .UsingEntity<Dictionary<string, object>>(
                    "CarToUser",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CarToUsers_Users"),
                    l => l.HasOne<CarModel>().WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CarToUsers_CarModels"),
                    j =>
                    {
                        j.HasKey("CardId", "UserId");
                        j.ToTable("CarToUsers");
                    });
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Location).WithMany(p => p.Companies)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Companies_Locations");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(e => e.Latitude)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Longitude)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Opportunity>(entity =>
        {
            entity.Property(e => e.Details).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Sensor>(entity =>
        {
            entity.Property(e => e.PlugName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.SensorModelNavigation).WithMany(p => p.Sensors)
                .HasForeignKey(d => d.SensorModel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sensors_SensorTypes");

            entity.HasOne(d => d.Station).WithMany(p => p.Sensors)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sensors_StationId");
        });

        modelBuilder.Entity<SensorType>(entity =>
        {
            entity.Property(e => e.ModelName).HasMaxLength(50);
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Company).WithMany(p => p.Stations)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stations_Companies");

            entity.HasOne(d => d.Location).WithMany(p => p.Stations)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stations_Locations");

            entity.HasMany(d => d.Opportunities).WithMany(p => p.Stations)
                .UsingEntity<Dictionary<string, object>>(
                    "OpportunityToStation",
                    r => r.HasOne<Opportunity>().WithMany()
                        .HasForeignKey("OpportunityId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_OpportunityToStations_Opportunities"),
                    l => l.HasOne<Station>().WithMany()
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_OpportunityToStations_Stations"),
                    j =>
                    {
                        j.HasKey("StationId", "OpportunityId");
                        j.ToTable("OpportunityToStations");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsFixedLength();
            entity.Property(e => e.SurName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserToRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId });

            entity.HasOne(d => d.Role).WithMany(p => p.UserToRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserToRoles_Roles");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.UserToRoleRoleNavigations)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserToRoles_UserRoleClaims1");

            entity.HasOne(d => d.User).WithMany(p => p.UserToRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserToRoles_Users");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.UserToRoleUserNavigations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserToRoles_UserRoleClaims");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
