using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace Lab5.Controllers
{
    public class TimeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TimeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> GetTimeInKyiv()
        {
            try
            {
                var currentTime = DateTime.UtcNow;

                var client = _httpClientFactory.CreateClient();

                var apiUrl = $"https://localhost:7043/api/Time/time?date={currentTime:yyyy-MM-ddTHH:mm:ssZ}";

                var response = await client.GetStringAsync(apiUrl);

                ViewBag.Result = $"Текущее время в Киеве: {response}";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Ошибка: {ex.Message}";
            }

            return View("Index");
        }
    }
}
