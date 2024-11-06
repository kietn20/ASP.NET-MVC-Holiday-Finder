using HolidaysWebApp.Models;
using HolidaysWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

public class HomeController : Controller
{
    private readonly IHolidaysApiService _holidaysApiService;

    public HomeController(IHolidaysApiService holidaysApiService)
    {
        _holidaysApiService = holidaysApiService;
    }


    [HttpGet]
    public async Task<IActionResult> GetHolidays(string countryCode, int year)
    {
        try
        {
            if (string.IsNullOrEmpty(countryCode) || year <= 0)
            {
                return BadRequest("Invalid input parameters");
            }

            // Call the GetHolidays method of the IHolidaysApiService interface
            var holidays = await _holidaysApiService.GetHolidays(countryCode.ToUpper(), year);
            return Json(holidays);
        }
        catch (Exception ex) // catch any exceptions thrown by the GetHolidays method
        {
            return StatusCode(500, "An unexpected error occurred");
        }
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}