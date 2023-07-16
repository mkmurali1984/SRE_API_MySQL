using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SRE_API.Models;

public partial class SreDatasContext : DbContext
{
    public SreDatasContext()
    {
    }

    public SreDatasContext(DbContextOptions<SreDatasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PropertyInfo> PropertyInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Server=MYSQL8001.site4now.net;Database=db_a9c23f_sreinfo;Uid=a9c23f_sreinfo;Pwd=V1shnu@priya;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PropertyInfo>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PRIMARY");

            entity.ToTable("PropertyInfo");

            entity.Property(e => e.Pid)
                .HasColumnType("int(11)")
                .HasColumnName("PID");
            entity.Property(e => e.ContactNumber).HasMaxLength(50);
            entity.Property(e => e.Dimension).HasMaxLength(100);
            entity.Property(e => e.EmailAddress).HasMaxLength(80);
            entity.Property(e => e.ImageFileName).HasMaxLength(100);
            entity.Property(e => e.MapUrl)
                .HasMaxLength(250)
                .HasColumnName("MapURL");
            entity.Property(e => e.OwnershipType).HasMaxLength(50);
            entity.Property(e => e.PersonAddress).HasMaxLength(255);
            entity.Property(e => e.PersonName).HasMaxLength(100);
            entity.Property(e => e.Price).HasMaxLength(100);
            entity.Property(e => e.PropertyDescription).HasMaxLength(100);
            entity.Property(e => e.PropertySubtype)
                .HasMaxLength(100)
                .HasColumnName("propertySubtype");
            entity.Property(e => e.PropertyType).HasMaxLength(100);
            entity.Property(e => e.Purpose).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
