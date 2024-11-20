using Lab6API.Data;
using Lab6API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerStatus>>> GetCustomerStatuses()
        {
            return await _context.CustomerStatuses.ToListAsync();
        }

        // GET: api/CustomerStatus/5
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

        // POST: api/CustomerStatus
        [HttpPost]
        public async Task<ActionResult<CustomerStatus>> PostCustomerStatus(CustomerStatus customerStatus)
        {
            // Если хотите избежать обязательного поля Customers, раскомментируйте строку ниже:
            // customerStatus.Customers = new List<Customer>(); 

            _context.CustomerStatuses.Add(customerStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerStatus", new { id = customerStatus.StatusCode }, customerStatus);
        }

        // PUT: api/CustomerStatus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerStatus(int id, CustomerStatus customerStatus)
        {
            if (id != customerStatus.StatusCode)
            {
                return BadRequest();
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

        // DELETE: api/CustomerStatus/5
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
