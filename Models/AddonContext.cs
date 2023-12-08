using Microsoft.EntityFrameworkCore;

namespace VehiclePriceCalc.Models;

public class AddonContext : DbContext
{
    public AddonContext(DbContextOptions<AddonContext> options)
        : base(options)
    {}

    public DbSet<AddonItem> AddonItems { get; set; } = null!;
}