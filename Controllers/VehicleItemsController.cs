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
    public class VehicleItemsController : ControllerBase
    {
        private readonly VehicleContext _context;

        public VehicleItemsController(VehicleContext context)
        {
            _context = context;
        }

        // GET: api/VehicleItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleItem>>> GetVehicleItems()
        {
            return await _context.VehicleItems.ToListAsync();
        }

        // GET: api/VehicleItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleItem>> GetVehicleItem(long id)
        {
            var vehicleItem = await _context.VehicleItems.FindAsync(id);

            if (vehicleItem == null)
            {
                return NotFound();
            }

            return vehicleItem;
        }

        // PUT: api/VehicleItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleItem(long id, VehicleItem vehicleItem)
        {
            if (id != vehicleItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(vehicleItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VehicleItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VehicleItem>> PostVehicleItem(VehicleItem vehicleItem)
        {
            _context.VehicleItems.Add(vehicleItem);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetVehicleItem", new { id = vehicleItem.Id }, vehicleItem);
            return CreatedAtAction(nameof(GetVehicleItem), new { id = vehicleItem.Id }, vehicleItem);
        }

        // DELETE: api/VehicleItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleItem(long id)
        {
            var vehicleItem = await _context.VehicleItems.FindAsync(id);
            if (vehicleItem == null)
            {
                return NotFound();
            }

            _context.VehicleItems.Remove(vehicleItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleItemExists(long id)
        {
            return _context.VehicleItems.Any(e => e.Id == id);
        }
    }
}
