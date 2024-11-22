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

    }
}
