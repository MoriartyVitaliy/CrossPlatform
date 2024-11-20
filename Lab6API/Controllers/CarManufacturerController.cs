using Lab6API.Data;
using Lab6API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarManufacturerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarManufacturerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CarManufacturer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarManufacturer>>> GetCarManufacturers()
        {
            return await _context.CarManufacturers.ToListAsync();
        }

        // GET: api/CarManufacturer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarManufacturer>> GetCarManufacturer(int id)
        {
            var carManufacturer = await _context.CarManufacturers.FindAsync(id);

            if (carManufacturer == null)
            {
                return NotFound();
            }

            return carManufacturer;
        }

        // POST: api/CarManufacturer
        [HttpPost]
        public async Task<ActionResult<CarManufacturer>> PostCarManufacturer(CarManufacturer carManufacturer)
        {
            _context.CarManufacturers.Add(carManufacturer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarManufacturer", new { id = carManufacturer.CarManufacturerNr }, carManufacturer);
        }

        // PUT: api/CarManufacturer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarManufacturer(int id, CarManufacturer carManufacturer)
        {
            if (id != carManufacturer.CarManufacturerNr)
            {
                return BadRequest();
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

        // DELETE: api/CarManufacturer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarManufacturer(int id)
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

        private bool CarManufacturerExists(int id)
        {
            return _context.CarManufacturers.Any(e => e.CarManufacturerNr == id);
        }
    }
}
