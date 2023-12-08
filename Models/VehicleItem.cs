namespace VehiclePriceCalc.Models;

public class VehicleItem
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public double VehiclePrice { get; set; }
    public double Addons { get; set; }
    public bool IsVehicleNet { get; set; }
    public bool IsAddonsNet { get; set; }
    public double Tax { get; set; }
}
