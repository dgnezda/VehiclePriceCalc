using Microsoft.EntityFrameworkCore;

namespace VehiclePriceCalc.Models;

public class VehicleContext : DbContext
{
    public VehicleContext(DbContextOptions<VehicleContext> options)
        : base(options)
    {}

    public DbSet<VehicleItem> VehicleItems { get; set; } = null!;
}