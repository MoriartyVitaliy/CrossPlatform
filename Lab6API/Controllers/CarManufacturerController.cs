using Lab6API.Data;
using Lab6API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarManufacturersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarManufacturersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CarManufacturers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarManufacturer>>> GetCarManufacturers()
        {
            return await _context.CarManufacturers.ToListAsync();
        }

        // GET: api/CarManufacturers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CarManufacturer>> GetCarManufacturer(string id)
        {
            var carManufacturer = await _context.CarManufacturers.FindAsync(id);

            if (carManufacturer == null)
            {
                return NotFound();
            }

            return carManufacturer;
        }

        // POST: api/CarManufacturers
        [HttpPost]
        public async Task<ActionResult<CarManufacturer>> CreateCarManufacturer(CarManufacturer carManufacturer)
        {
            // Генерация уникального идентификатора, если не указано
            if (string.IsNullOrEmpty(carManufacturer.CarManufacturerNr))
            {
                carManufacturer.CarManufacturerNr = Guid.NewGuid().ToString();
            }

            _context.CarManufacturers.Add(carManufacturer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarManufacturer), new { id = carManufacturer.CarManufacturerNr }, carManufacturer);
        }

        // PUT: api/CarManufacturers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarManufacturer(string id, CarManufacturer carManufacturer)
        {
            if (id != carManufacturer.CarManufacturerNr)
            {
                return BadRequest("ID в запросе и модели не совпадают.");
            }

            _context.Entry(carManufacturer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarManufacturerExists(id))
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

        // DELETE: api/CarManufacturers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarManufacturer(string id)
        {
            var carManufacturer = await _context.CarManufacturers.FindAsync(id);
            if (carManufacturer == null)
            {
                return NotFound();
            }

            _context.CarManufacturers.Remove(carManufacturer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarManufacturerExists(string id)
        {
            return _context.CarManufacturers.Any(e => e.CarManufacturerNr == id);
        }
    }
}
