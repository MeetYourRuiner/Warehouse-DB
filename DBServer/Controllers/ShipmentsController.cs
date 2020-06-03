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
    public class ShipmentsController : ControllerBase
    {
        private readonly WarehouseContext _context;

        public ShipmentsController(WarehouseContext context)
        {
            _context = context;
        }

        // GET: api/Shipments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipment>>> GetShipments()
        {
            return await _context.Shipments
                .Include(s => s.ShipmentProducts)
                    .ThenInclude(sp => sp.Product)
                .Include(s => s.Employee)
                .Include(s => s.Order)
                    .ThenInclude(o => o.Customer)
                .ToListAsync();
        }

        // GET: api/Shipments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipment>> GetShipment(long id)
        {
            var shipment = await _context.Shipments.FindAsync(id);

            if (shipment == null)
            {
                return NotFound();
            }

            return shipment;
        }

        // PUT: api/Shipments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipment(long id, Shipment shipment)
        {
            if (id != shipment.Id)
            {
                return BadRequest();
            }

            var shipments = await _context.ShipmentProducts.AsNoTracking().ToListAsync();
            var supplies = await _context.SupplyProducts.AsNoTracking().ToListAsync();
            var products = await _context.Products.AsNoTracking().ToListAsync();
            var orderproducts = await _context.OrderProducts.AsNoTracking().ToListAsync();

            var currentOP = orderproducts.Where(op => op.OrderId == shipment.OrderId).ToList();
            foreach (var row in shipment.ShipmentProducts)
            {
                var productId = row.ProductId;
                var plus = supplies
                    .Where(s => s.ProductId == productId)
                    .Sum(s => s.Quantity);
                var minus = shipments
                    .Where(s => s.ProductId == productId)
                    .Sum(s => s.Quantity);
                var quantity = plus - minus;
                var orderQuantity = currentOP
                    .Where(op => op.ProductId == productId)
                    .Select(op => op.Quantity)
                    .FirstOrDefault();
                if (quantity - row.Quantity < 0)
                    return BadRequest($"Количество товара {products.Where(p => p.Id == productId).Select(p => p.Name).FirstOrDefault()} недостаточно");
                else if (row.Quantity > orderQuantity)
                    return BadRequest($"В заказе требуется меньшее количество {products.Where(p => p.Id == productId).Select(p => p.Name).FirstOrDefault()}");
            }

            var oldShipment = await _context.Shipments
                .AsNoTracking()
                .Include(s => s.ShipmentProducts)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();
            var listToDelete = oldShipment.ShipmentProducts;
            foreach (var item in listToDelete)
            {
                _context.Entry(item).State = EntityState.Deleted;
            }
            await _context.SaveChangesAsync();

            var listToAdd = shipment.ShipmentProducts;
            foreach (var item in listToAdd)
            {
                _context.ShipmentProducts.Add(item);
            }
            _context.Entry(shipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipmentExists(id))
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

        // POST: api/Shipments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Shipment>> PostShipment(Shipment shipment)
        {
            var supplies = await _context.SupplyProducts.AsNoTracking().ToListAsync();
            var products = await _context.Products.AsNoTracking().ToListAsync();
            var order = await _context.Orders
                .AsNoTracking()
                .Where(o => o.Id == shipment.OrderId)
                .Include(o => o.OrderProducts)
                .Include(o => o.Shipments)
                    .ThenInclude(s => s.ShipmentProducts)
                .FirstOrDefaultAsync();
            var shipments = order.Shipments.Where(s => s.ShipmentProducts != null).SelectMany(s => s.ShipmentProducts).ToList();

            foreach (var row in shipment.ShipmentProducts)
            {
                var productId = row.ProductId;
                // Подсчет остатков
                var plus = supplies
                    .Where(s => s.ProductId == productId)
                    .Sum(s => s.Quantity);
                var minus = shipments
                    .Where(s => s.ProductId == productId)
                    .Sum(s => s.Quantity);
                var quantity = plus - minus;
                // Подсчет требуемого количества
                var orderQuantity = order.OrderProducts
                    .Where(op => op.ProductId == productId)
                    .Select(op => op.Quantity)
                    .FirstOrDefault();
                var shippedQuantity = shipments.Where(s => s.ProductId == productId).Sum(s => s.Quantity);
                if (quantity - row.Quantity < 0)
                    return BadRequest($"Количество товара {products.Where(p => p.Id == productId).Select(p => p.Name).FirstOrDefault()} недостаточно");
                else if (row.Quantity > orderQuantity - shippedQuantity)
                    return BadRequest($"В заказе требуется меньшее количество {products.Where(p => p.Id == productId).Select(p => p.Name).FirstOrDefault()}");
            }

            _context.Shipments.Add(shipment);
            shipments.AddRange(shipment.ShipmentProducts);
            bool isOrderCompleted = true;
            foreach (var op in order.OrderProducts)
            {
                var shippedQuantity = shipments.Where(s => s.ProductId == op.ProductId).Sum(s => s.Quantity);
                if (op.Quantity != shippedQuantity)
                    isOrderCompleted = false;
            }
            if (isOrderCompleted)
            {
                order.IsComplete = true;
                _context.Entry(order).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipment", new { id = shipment.Id }, shipment);
        }

        // DELETE: api/Shipments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shipment>> DeleteShipment(long id)
        {
            var shipment = await _context.Shipments.FindAsync(id);
            if (shipment == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(shipment.OrderId);
            if (order != null)
            {
                order.IsComplete = false;
                _context.Entry(order).State = EntityState.Modified;
            }
            _context.Shipments.Remove(shipment);
            await _context.SaveChangesAsync();

            return shipment;
        }

        private bool ShipmentExists(long id)
        {
            return _context.Shipments.Any(e => e.Id == id);
        }
    }
}
