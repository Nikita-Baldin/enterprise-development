using CarRentalService.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CarRentalService.Domain.Context;

public class CarRentalServiceDbContext(DbContextOptions<CarRentalServiceDbContext> options) : DbContext(options)
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<RentalPoint> RentalPoints { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<RentalRecord> RentalRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<RentalRecord>()
            .HasOne(r => r.Vehicle)
            .WithMany() 
            .HasForeignKey("vehicle")
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RentalRecord>()
            .HasOne(r => r.Client)
            .WithMany() 
            .HasForeignKey("client")
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RentalRecord>()
            .HasOne(r => r.RentalPoint)
            .WithMany() 
            .HasForeignKey("rental_point")
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RentalRecord>()
            .HasOne(r => r.ReturnPoint)
            .WithMany() 
            .HasForeignKey("return_point")
            .OnDelete(DeleteBehavior.Restrict); 

    }


}