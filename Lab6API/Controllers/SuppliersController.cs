using Lab6API.Data;
using Lab6API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SuppliersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Suppliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            return await _context.Suppliers.ToListAsync();
        }

        // GET: api/Suppliers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(string id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return supplier;
        }

        // POST: api/Suppliers
        [HttpPost]
        public async Task<ActionResult<Supplier>> CreateSupplier(Supplier supplier)
        {

            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSupplier), new { id = supplier.SupplierNr }, supplier);
        }

        // PUT: api/Suppliers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(string id, Supplier supplier)
        {
            if (id != supplier.SupplierNr)
            {
                return BadRequest("ID в запросе и модели не совпадают.");
            }

            _context.Entry(supplier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
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

        // DELETE: api/Suppliers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(string id)
        {
            var supplier = await _context.Suppliers
                .Include(s => s.PartSuppliers)
                .Include(s => s.SuppliedParts)
                .FirstOrDefaultAsync(s => s.SupplierNr == id);

            if (supplier == null)
            {
                return NotFound();
            }

            if (supplier.PartSuppliers.Any() || supplier.SuppliedParts.Any())
            {
                return Conflict("Невозможно удалить поставщика, так как он связан с деталями или поставками.");
            }

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SupplierExists(string id)
        {
            return _context.Suppliers.Any(s => s.SupplierNr == id);
        }
    }
}
