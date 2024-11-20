using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab6API.Model;
using System.Linq;
using System.Threading.Tasks;
using Lab6API.Data;

namespace Lab6API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            var cars = await _context.Cars
                .Include(c => c.CarManufacturer)  // Загружаем связанные данные CarManufacturer
                .Include(c => c.PartsForCars)     // Загружаем связанные данные PartsForCars
                .ToListAsync();

            return Ok(cars);
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _context.Cars
                .Include(c => c.CarManufacturer)  // Загружаем связанные данные CarManufacturer
                .Include(c => c.PartsForCars)     // Загружаем связанные данные PartsForCars
                .FirstOrDefaultAsync(c => c.CarID == id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.CarID)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        // POST: api/Cars
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            if (car == null)
            {
                return BadRequest("Car data is null");
            }

            var manufacturer = await _context.CarManufacturers
                .FirstOrDefaultAsync(m => m.CarManufacturerNr == car.CarManufacturerNr);

            if (manufacturer == null)
            {
                return NotFound($"Car manufacturer with CarManufacturerNr {car.CarManufacturerNr} not found.");
            }

            car.CarManufacturer = manufacturer;

            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCar), new { id = car.CarID }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.CarID == id);
        }
    }
}
