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

    }
}
