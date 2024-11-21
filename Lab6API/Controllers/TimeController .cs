using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab6API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {

        [HttpGet]
        [Route("time")]
        public IActionResult GetTime([FromQuery] string date)
        {
            try
            {
                var inputDate = DateTime.Parse(date);

                var kyivTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(inputDate, "FLE Standard Time");

                return Ok(kyivTime.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            catch (Exception ex)
            {
                return BadRequest($"Ошибка: {ex.Message}");
            }
        }
    }
}
