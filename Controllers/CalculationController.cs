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
            return Ok(new { result = CalculateNet(input.VehiclePrice, input.Addons, input.IsVehicleNet, input.IsAddonsNet, input.Tax) });
        }

        // GET: api/calculateGross
        [HttpGet]
        [Route("calculateGross")]
        public IActionResult CalculateGrossGet([FromQuery] CalculationInput input) 
        {
            return Ok(new { result = CalculateGross(input.VehiclePrice, input.Addons, input.IsVehicleNet, input.IsAddonsNet, input.Tax) });
        }

        // public async Task<ActionResult<IEnumerable<CalculationInput>>> GetVehicleItems()
        // {
        //     return await _context.CalculationInputs.ToListAsync();
        // }

        private static double CalculateNet(double vehiclePrice, double addons, bool isPriceNet, bool isAddonsNet, double tax) 
        {
            if (!isPriceNet)
            {
                vehiclePrice = vehiclePrice / (1 + (tax / 100));
            }
            if (!isAddonsNet) 
            {
                addons = addons / (1 + (tax / 100));
            }
            return Math.Round(vehiclePrice + addons, 2);
        }

        private static double CalculateGross(double vehiclePrice, double addons, bool isPriceNet, bool isAddonsNet, double tax)
        {
            if (isPriceNet)
            {
                vehiclePrice += vehiclePrice * (tax / 100);
            }
            if (isAddonsNet)
            {
                addons += addons * (tax / 100);
            }
            return Math.Round(vehiclePrice + addons, 2);
        }
    }
}
