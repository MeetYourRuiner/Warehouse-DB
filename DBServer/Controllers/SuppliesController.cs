using DBServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliesController : ControllerBase
    {
        private readonly WarehouseContext _context;

        public SuppliesController(WarehouseContext context)
        {
            _context = context;
        }

        // GET: api/Supplies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supply>>> GetSupplies()
        {
            return await _context.Supplies
                .Include(s => s.SupplyProducts)
                    .ThenInclude(sp => sp.Product)
                .Include(s => s.Supplier)
                .Include(s => s.Employee)
                .ToListAsync();
        }

        // GET: api/Supplies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supply>> GetSupply(long id)
        {
            var supply = await _context.Supplies.FindAsync(id);

            if (supply == null)
            {
                return NotFound();
            }

            return supply;
        }

        // PUT: api/Supplies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupply(long id, Supply supply)
        {
            if (id != supply.Id)
            {
                return BadRequest();
            }

            var oldSupply = await _context.Supplies
                .AsNoTracking()
                .Include(s => s.SupplyProducts)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();
            var listToDelete = oldSupply.SupplyProducts;
            foreach (var item in listToDelete)
            {
                _context.Entry(item).State = EntityState.Deleted;
            }
            await _context.SaveChangesAsync();

            var listToAdd = supply.SupplyProducts;
            foreach (var item in listToAdd)
            {
                _context.SupplyProducts.Add(item);
            }
            _context.Entry(supply).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Supplies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Supply>> PostSupply(Supply supply)
        {
            _context.Supplies.Add(supply);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupply", new { id = supply.Id }, supply);
        }

        // DELETE: api/Supplies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Supply>> DeleteSupply(long id)
        {
            var supply = await _context.Supplies.FindAsync(id);
            if (supply == null)
            {
                return NotFound();
            }

            _context.Supplies.Remove(supply);
            await _context.SaveChangesAsync();

            return supply;
        }

        private bool SupplyExists(long id)
        {
            return _context.Supplies.Any(e => e.Id == id);
        }
    }
}
