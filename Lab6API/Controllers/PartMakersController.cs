using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab6API.Data;
using Lab6API.Model;

namespace Lab6API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartMakersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PartMakersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PartMakers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartMaker>>> GetPartMakers()
        {
            var partMakers = await _context.PartMakers.ToListAsync();
            return Ok(partMakers);
        }

        // GET: api/PartMakers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartMaker>> GetPartMaker(string id)
        {
            var partMaker = await _context.PartMakers.FindAsync(id);

            if (partMaker == null)
            {
                return NotFound();
            }

            return Ok(partMaker);
        }

        // POST: api/PartMakers
        [HttpPost]
        public async Task<ActionResult<PartMaker>> PostPartMaker(PartMaker partMaker)
        {
            _context.PartMakers.Add(partMaker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartMaker", new { id = partMaker.PartMakerCode }, partMaker);
        }

        // PUT: api/PartMakers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartMaker(int id, PartMaker partMaker)
        {
            if (id != partMaker.PartMakerCode)
            {
                return BadRequest("PartMaker ID mismatch.");
            }

            _context.Entry(partMaker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartMakerExists(id))
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

        // DELETE: api/PartMakers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartMaker(string id)
        {
            var partMaker = await _context.PartMakers.FindAsync(id);
            if (partMaker == null)
            {
                return NotFound();
            }

            _context.PartMakers.Remove(partMaker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartMakerExists(int id)
        {
            return _context.PartMakers.Any(e => e.PartMakerCode == id);
        }
    }
}
