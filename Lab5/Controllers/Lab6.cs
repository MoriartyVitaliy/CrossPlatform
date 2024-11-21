using Lab5.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


[Authorize]
public class Lab6 : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public Lab6(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // Сторінка для перегляду всіх записів
    public async Task<IActionResult> CarManufacturer()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7043/api/CarManufacturers");
        var client = _httpClientFactory.CreateClient();
        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonResponse);  // Логируем полученные данные

            try
            {
                var carManufacturers = JsonSerializer.Deserialize<List<CarManufacturerViewModel>>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (carManufacturers != null)
                {
                    return View(carManufacturers);
                }
                else
                {
                    return View("Error", new { message = "Error deserializing data" });
                }
            }
            catch (JsonException ex)
            {
                return View("Error", new { message = ex.Message });
            }
        }

        return View("Error", new { message = "Failed to fetch data" });
    }

    public async Task<IActionResult> Customer(string status, string organisationName)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7043/api/Customers");
        var client = _httpClientFactory.CreateClient();
        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonResponse);  // Логируем полученные данные

            try
            {
                var customers = JsonSerializer.Deserialize<List<CustomerViewModels>>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (customers != null)
                {
                    // Фільтрація по статусу
                    if (!string.IsNullOrEmpty(status))
                    {
                        customers = customers.Where(c => c.CustomerStatus.StatusDescription.Contains(status, StringComparison.OrdinalIgnoreCase)).ToList();
                    }

                    // Фільтрація по назві організації
                    if (!string.IsNullOrEmpty(organisationName))
                    {
                        customers = customers.Where(c => c.OrganisationName.Contains(organisationName, StringComparison.OrdinalIgnoreCase)).ToList();
                    }

                    // Передача даних у вигляд
                    ViewData["OrganisationName"] = organisationName;
                    ViewData["Status"] = status;

                    return View(customers);
                }
                else
                {
                    return View("Error", new { message = "Error deserializing data" });
                }
            }
            catch (JsonException ex)
            {
                return View("Error", new { message = ex.Message });
            }
        }

        return View("Error", new { message = "Failed to fetch data" });
    }

    public async Task<IActionResult> CustomerStatus()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7043/api/CustomerStatuses");
        var client = _httpClientFactory.CreateClient();
        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonResponse);  // Логируем полученные данные

            try
            {
                var сustomerStatuses = JsonSerializer.Deserialize<List<CustomerStatusViewModels>>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (сustomerStatuses != null)
                {
                    return View(сustomerStatuses);
                }
                else
                {
                    return View("Error", new { message = "Error deserializing data" });
                }
            }
            catch (JsonException ex)
            {
                return View("Error", new { message = ex.Message });
            }
        }

        return View("Error", new { message = "Failed to fetch data" });
    }

}
