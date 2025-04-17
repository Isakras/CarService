using Abp.Localization;
using Abp.Zero.EntityFrameworkCore;
using Invoice.Authorization.Roles;
using Invoice.Authorization.Users;
using Invoice.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Invoice.Vehicles;
using Invoice.Workers;
using Invoice.Diagnose;
using System;
using System.Data;

namespace Invoice.EntityFrameworkCore;

public class InvoiceDbContext : AbpZeroDbContext<Tenant, Role, User, InvoiceDbContext>
{
    /* Define a DbSet for each entity of the application */
    public DbSet<Vehicle> Vehicle { get; set; }
    public DbSet<Mechanic> Mechanic { get; set; }
     public DbSet <VehicleDiagnosis> VehicleDiagnoses { get; set; }
    public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options)
        : base(options)
    {
    }

    // add these lines to override max length of property
    // we should set max length smaller than the PostgreSQL allowed size (10485760)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationLanguageText>()
            .Property(p => p.Value)
            .HasMaxLength(100); // any integer that is smaller than 10485760

        modelBuilder.Entity<Vehicle>(b =>
        {b.Property(v => v.VIN).IsRequired().HasMaxLength(50);});

        modelBuilder.Entity<Mechanic>(b => b.Property(x => x.FullName).HasMaxLength(70));
        modelBuilder.Entity<VehicleDiagnosis>(b => b.Property(x => x.Comments).HasMaxLength(150));


        //Configure all DateTime properties to be converted to UTC
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                {
                    property.SetValueConverter(
                        new ValueConverter<DateTime, DateTime>(
                            v => v.ToUniversalTime(),
                            v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                        )
                    );
                }
            }
        }
    }
}
