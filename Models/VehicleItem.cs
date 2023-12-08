namespace VehiclePriceCalc.Models;

public class VehicleItem
{
    public long Id { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? ModelVersion { get; set; }
    public double BaseNetPrice { get; set; }
}
