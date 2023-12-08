// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Runtime.CompilerServices;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
using VehiclePriceCalc.Models;

namespace VehiclePriceCalc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly CalculationContext _context;

        public CalculationController(CalculationContext context)
        {
            _context = context;
        }

        // GET: api/calculatePrice
        [HttpGet]
        [Route("calculatePrice")]
        public IActionResult CalculateGrossGet([FromQuery] CalculationInput input) 
        {
            var vehicleNetPrice = input.IsVehiclePriceNet 
                ? input.VehiclePrice 
                : input.VehiclePrice / (1 + (input.Tax / 100));
            var vehicleGrossPrice = input.IsVehiclePriceNet 
                ? input.VehiclePrice + (input.VehiclePrice * (input.Tax / 100)) 
                : input.VehiclePrice;
            var addonsNetPrice = input.IsAddonsPriceNet 
                ? input.AddonsPrice 
                : input.AddonsPrice / (1 + (input.Tax / 100));
            var addonsGrossPrice = input.IsAddonsPriceNet 
                ? input.AddonsPrice + (input.AddonsPrice * (input.Tax / 100)) 
                : input.AddonsPrice;
            var totalNetPrice = vehicleNetPrice + addonsNetPrice;
            var totalGrossPrice = vehicleGrossPrice + addonsGrossPrice;

            return Ok(new { 
                    vatRate = input.Tax,
                    baseVehicleNetPrice = vehicleNetPrice,
                    baseVehicleGrossPrice = vehicleGrossPrice,
                    additionalEquipmentNet = addonsNetPrice,
                    additionalEquipmentGross = addonsGrossPrice,
                    vehicleTotalNetPrice = totalNetPrice,
                    vehicleTotalGrossPrice = totalGrossPrice
                });
        }
    }
}
