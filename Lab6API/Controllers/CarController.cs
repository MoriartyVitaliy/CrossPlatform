using Lab6API.Data;
using Lab6API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await _context.Cars
                .Include(c => c.CarManufacturer)
                .ToListAsync();
        }

        // GET: api/Cars/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(string id)
        {
            var car = await _context.Cars
                .Include(c => c.CarManufacturer)
                .FirstOrDefaultAsync(c => c.CarID == id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // POST: api/Cars
        [HttpPost]
        public async Task<ActionResult<Car>> CreateCar(Car car)
        {
            // Проверка наличия производителя
            if (!_context.CarManufacturers.Any(cm => cm.CarManufacturerNr == car.CarManufacturerNr))
            {
                return BadRequest("Производитель с указанным номером не найден.");
            }

            // Генерация ID, если не задано
            if (string.IsNullOrEmpty(car.CarID))
            {
                car.CarID = Guid.NewGuid().ToString();
            }

            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCar), new { id = car.CarID }, car);
        }

        // PUT: api/Cars/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(string id, Car car)
        {
            if (id != car.CarID)
            {
                return BadRequest("ID в запросе и модели не совпадают.");
            }

            // Проверка наличия производителя
            if (!_context.CarManufacturers.Any(cm => cm.CarManufacturerNr == car.CarManufacturerNr))
            {
                return BadRequest("Производитель с указанным номером не найден.");
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

        // DELETE: api/Cars/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(string id)
        {
            var car = await _context.Cars
                .Include(c => c.PartsForCars)
                .FirstOrDefaultAsync(c => c.CarID == id);

            if (car == null)
            {
                return NotFound();
            }

            // Удаление связанных записей
            if (car.PartsForCars.Any())
            {
                return Conflict("Невозможно удалить автомобиль, так как он связан с деталями.");
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(string id)
        {
            return _context.Cars.Any(c => c.CarID == id);
        }
    }
}
