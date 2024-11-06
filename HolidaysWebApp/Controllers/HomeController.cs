using HolidaysWebApp.Models;
using HolidaysWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HolidaysWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHolidaysApiService _holidaysApiService;

        public HomeController(IHolidaysApiService holidaysApiService)
        {
            _holidaysApiService = holidaysApiService;
        }

        public async Task<IActionResult> Index(string countryCode, int year)
        {
            List<HolidayModel> holidays = new List<HolidayModel>();

            if (!string.IsNullOrEmpty(countryCode) && year > 0)
            {
                holidays = await _holidaysApiService.GetHolidays(countryCode, year);
            }

            return View(holidays);
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
}
