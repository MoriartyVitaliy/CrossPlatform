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

    }
}
