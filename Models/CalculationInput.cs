namespace VehiclePriceCalc.Models;

public class CalculationInput
{
    public double VehiclePrice { get; set; }
    public bool IsVehiclePriceNet { get; set; }
    public double AddonsPrice { get; set; }
    public bool IsAddonsPriceNet { get; set; }
    public double Tax { get; set; }
}
