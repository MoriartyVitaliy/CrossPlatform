using Lab6API.Data;
using Lab6API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerStatusesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerStatusesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerStatuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerStatus>>> GetCustomerStatuses()
        {
            return await _context.CustomerStatuses.ToListAsync();
        }

        // GET: api/CustomerStatuses/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerStatus>> GetCustomerStatus(int id)
        {
            var customerStatus = await _context.CustomerStatuses.FindAsync(id);

            if (customerStatus == null)
            {
                return NotFound();
            }

            return customerStatus;
        }

        // POST: api/CustomerStatuses
        [HttpPost]
        public async Task<ActionResult<CustomerStatus>> CreateCustomerStatus(CustomerStatus customerStatus)
        {
            if (_context.CustomerStatuses.Any(cs => cs.StatusCode == customerStatus.StatusCode))
            {
                return Conflict($"StatusCode {customerStatus.StatusCode} уже существует.");
            }

            _context.CustomerStatuses.Add(customerStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomerStatus), new { id = customerStatus.StatusCode }, customerStatus);
        }

        // PUT: api/CustomerStatuses/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerStatus(int id, CustomerStatus customerStatus)
        {
            if (id != customerStatus.StatusCode)
            {
                return BadRequest("ID в запросе и модели не совпадают.");
            }

            _context.Entry(customerStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerStatusExists(id))
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

        // DELETE: api/CustomerStatuses/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerStatus(int id)
        {
            var customerStatus = await _context.CustomerStatuses.FindAsync(id);
            if (customerStatus == null)
            {
                return NotFound();
            }

            _context.CustomerStatuses.Remove(customerStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerStatusExists(int id)
        {
            return _context.CustomerStatuses.Any(e => e.StatusCode == id);
        }
    }
}
