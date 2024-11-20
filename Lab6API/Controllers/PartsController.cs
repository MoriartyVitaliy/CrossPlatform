using Lab6API.Data;
using Lab6API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class PartsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PartsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/parts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Part>>> GetParts()
    {
        return await _context.Parts
            .Include(p => p.Brand)
            .Include(p => p.PartMaker)
            .Include(p => p.PartGroup)
            .Include(p => p.Supplier)
            .ToListAsync();
    }

    // GET: api/parts/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Part>> GetPart(int id)
    {
        var part = await _context.Parts
            .Include(p => p.Brand)
            .Include(p => p.PartMaker)
            .FirstOrDefaultAsync(p => p.PartID == id);

        if (part == null)
        {
            return NotFound();
        }

        return part;
    }

    // POST: api/parts
    [HttpPost]
    public async Task<ActionResult<Part>> PostPart(Part part)
    {
        var brand = await _context.Brands
            .FirstOrDefaultAsync(b => b.BrandID == part.BrandID);

        if (brand == null)
        {
            return BadRequest($"brand is null or empty");
        }

        var supplier = await _context.Suppliers
            .FirstOrDefaultAsync(s => s.SupplierNr == part.MainSupplierNr);

        if (supplier == null)
        {
            return BadRequest($"supplier is null or empty");
        }

        var partGroup = await _context.PartGroups
            .FirstOrDefaultAsync(pm => pm.PartGroupID == part.PartGroupID);

        if (partGroup == null)
        {
            return BadRequest($"partGroup is null or empty");
        }

        var partMaker = await _context.PartMakers
            .FirstOrDefaultAsync(pm => pm.PartMakerCode == part.PartMakerCode);

        if (partMaker == null)
        {
            return BadRequest($"partMaker is null or empty");
        }

        part.MainSupplierName = supplier.SupplierName;
        part.Supplier = supplier;
        part.PartMaker = partMaker;
        part.PartGroup = partGroup;
        part.Brand = brand;
        part.PartMaker = partMaker;

        _context.Parts.Add(part);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPart), new { id = part.PartID }, part);
    }


    // PUT: api/parts/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPart(int id, Part part)
    {
        if (id != part.PartID)
        {
            return BadRequest();
        }

        _context.Entry(part).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PartExists(id))
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

    // DELETE: api/parts/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePart(int id)
    {
        var part = await _context.Parts.FindAsync(id);
        if (part == null)
        {
            return NotFound();
        }

        _context.Parts.Remove(part);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PartExists(int id)
    {
        return _context.Parts.Any(e => e.PartID == id);
    }
}
