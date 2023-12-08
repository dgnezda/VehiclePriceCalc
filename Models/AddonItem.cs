namespace VehiclePriceCalc.Models;

public class AddonItem
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? CarBrand { get; set; }
    public string? CarModel { get; set; }
    public string? CarModelVersion { get; set; }
    public double BaseNetPrice { get; set; }
}
