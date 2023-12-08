using Microsoft.EntityFrameworkCore;

namespace VehiclePriceCalc.Models;

public class CalculationContext : DbContext
{
    public CalculationContext(DbContextOptions<CalculationContext> options)
        : base(options)
    {}

    public DbSet<CalculationInput> CalculationInputs { get; set; } = null!;
}