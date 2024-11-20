using Lab6API.Data;
using Lab6API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartGroupsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PartGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PartGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartGroup>>> GetPartGroups()
        {
            return await _context.PartGroups
                .Include(pg => pg.Parts) // Include related parts
                .ToListAsync();
        }

        // GET: api/PartGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartGroup>> GetPartGroup(int id)
        {
            var partGroup = await _context.PartGroups
                .Include(pg => pg.Parts) // Include related parts
                .FirstOrDefaultAsync(pg => pg.PartGroupID == id);

            if (partGroup == null)
            {
                return NotFound();
            }

            return partGroup;
        }

        // POST: api/PartGroups
        [HttpPost]
        public async Task<ActionResult<PartGroup>> PostPartGroup(PartGroup partGroup)
        {
            if (partGroup != null)
            {
                return BadRequest("PartGroup data is null");
            }

            _context.PartGroups.Add(partGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPartGroup), new { id = partGroup.PartGroupID }, partGroup);
        }

        // PUT: api/PartGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartGroup(int id, PartGroup partGroup)
        {   
            if (id != partGroup.PartGroupID)
            {
                return BadRequest();
            }

            _context.Entry(partGroup).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/PartGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartGroup(int id)
        {
            var partGroup = await _context.PartGroups.FindAsync(id);
            if (partGroup == null)
            {
                return NotFound();
            }

            _context.PartGroups.Remove(partGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
