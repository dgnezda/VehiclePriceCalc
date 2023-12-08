namespace VehiclePriceCalc.Models;

public class CalculationInput
{
    public double VehiclePrice { get; set; }
    public double Addons { get; set; }
    public bool IsVehicleNet { get; set; }
    public bool IsAddonsNet { get; set; }
    public double Tax { get; set; }
}
