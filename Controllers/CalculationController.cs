using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // GET: api/calculateNet
        [HttpGet]
        [Route("calculateNet")]
        public IActionResult CalculateNetGet([FromQuery] CalculationInput input) 
        {
            return Ok(new { result = CalculateNet(input.VehiclePrice, input.IsVehiclePriceNet, input.AddonsPrice, input.IsAddonsPriceNet, input.Tax) });
        }

        // GET: api/calculateGross
        [HttpGet]
        [Route("calculateGross")]
        public IActionResult CalculateGrossGet([FromQuery] CalculationInput input) 
        {
            return Ok(new { result = CalculateGross(input.VehiclePrice, input.IsVehiclePriceNet, input.AddonsPrice, input.IsAddonsPriceNet, input.Tax) });
        }

        // Calculate Net Price Method
        private static double CalculateNet(double vehiclePrice, bool isVehiclePriceNet, double addonsPrice, bool isAddonsPriceNet, double tax) 
        {
            if (!isVehiclePriceNet)
            {
                vehiclePrice = vehiclePrice / (1 + (tax / 100));
            }
            if (!isAddonsPriceNet) 
            {
                addonsPrice = addonsPrice / (1 + (tax / 100));
            }
            return Math.Round(vehiclePrice + addonsPrice, 2);
        }

        // Calculate Gross Price Method
        private static double CalculateGross(double vehiclePrice, bool isVehiclePriceNet, double addonsPrice, bool isAddonsPriceNet, double tax)
        {
            if (isVehiclePriceNet)
            {
                vehiclePrice += vehiclePrice * (tax / 100);
            }
            if (isAddonsPriceNet)
            {
                addonsPrice += addonsPrice * (tax / 100);
            }
            return Math.Round(vehiclePrice + addonsPrice, 2);
        }
    }
}
