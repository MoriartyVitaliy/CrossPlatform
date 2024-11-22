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

}
