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
    public class AddonItemsController : ControllerBase
    {
        private readonly AddonContext _context;

        public AddonItemsController(AddonContext context)
        {
            _context = context;
        }

        // GET: api/AddonItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddonItem>>> GetAddonItems()
        {
            return await _context.AddonItems.ToListAsync();
        }

        // GET: api/AddonItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddonItem>> GetAddonItem(long id)
        {
            var addonItem = await _context.AddonItems.FindAsync(id);

            if (addonItem == null)
            {
                return NotFound();
            }

            return addonItem;
        }

        // PUT: api/AddonItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddonItem(long id, AddonItem addonItem)
        {
            if (id != addonItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(addonItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddonItemExists(id))
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

        // POST: api/AddonItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddonItem>> PostAddonItem(AddonItem addonItem)
        {
            _context.AddonItems.Add(addonItem);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetVehicleItem", new { id = addonItem.Id }, addonItem);
            return CreatedAtAction(nameof(GetAddonItem), new { id = addonItem.Id }, addonItem);
        }

        // DELETE: api/AddonItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddonItem(long id)
        {
            var addonItem = await _context.AddonItems.FindAsync(id);
            if (addonItem == null)
            {
                return NotFound();
            }

            _context.AddonItems.Remove(addonItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddonItemExists(long id)
        {
            return _context.AddonItems.Any(e => e.Id == id);
        }
    }
}
