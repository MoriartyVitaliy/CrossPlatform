using Lab6API.Data;
using Lab6API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartForCarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PartForCarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PartForCar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartForCar>>> GetPartForCars()
        {
            return await _context.PartsForCars
                .Include(pfc => pfc.Part)
                .Include(pfc => pfc.Car)
                .ToListAsync();
        }

        // GET: api/PartForCar/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PartForCar>> GetPartForCar(int id)
        {
            var partForCar = await _context.PartsForCars
                .Include(pfc => pfc.Part)
                .Include(pfc => pfc.Car)
                .FirstOrDefaultAsync(pfc => pfc.PartID == id || pfc.CarID == id);

            if (partForCar == null)
            {
                return NotFound();
            }

            return partForCar;
        }

        // POST: api/PartForCar
        [HttpPost]
        public async Task<ActionResult<PartForCar>> PostPartForCar(PartForCar partForCar)
        {
            if (partForCar == null)
            {
                return BadRequest("PartForCar data is null.");
            }

            var part = await _context.Parts.FindAsync(partForCar.PartID);
            if (part == null)
            {
                return NotFound($"Part with ID {partForCar.PartID} not found.");
            }

            var car = await _context.Cars.FindAsync(partForCar.CarID);
            if (car == null)
            {
                return NotFound($"Car with ID {partForCar.CarID} not found.");
            }

            partForCar.Part = part;
            partForCar.Car = car;

            _context.PartsForCars.Add(partForCar);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPartForCar), new { id = partForCar.PartID }, partForCar);
        }

        // PUT: api/PartForCar/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartForCar(int id, PartForCar partForCar)
        {
            if (id != partForCar.PartID)
            {
                return BadRequest("PartID mismatch.");
            }

            _context.Entry(partForCar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartForCarExists(id))
                {
                    return NotFound($"PartForCar with ID {id} not found.");
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/PartForCar/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartForCar(int id)
        {
            var partForCar = await _context.PartsForCars.FindAsync(id);

            if (partForCar == null)
            {
                return NotFound();
            }

            _context.PartsForCars.Remove(partForCar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartForCarExists(int id)
        {
            return _context.PartsForCars.Any(pfc => pfc.PartID == id);
        }
    }
}
