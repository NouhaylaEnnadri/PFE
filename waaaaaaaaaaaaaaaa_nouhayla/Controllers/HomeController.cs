using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using waaaaaaaaaaaaaaaa_nouhayla.hubs;
using waaaaaaaaaaaaaaaa_nouhayla.Models;

namespace waaaaaaaaaaaaaaaa_nouhayla.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<death> _death;

        public HomeController(ILogger<HomeController> logger ,
            IHubContext<death> deaTh)
        {
            _logger = logger;
            _death = deaTh;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> DeathlyHallows(string type)
        {
            if (sd.DealthyHallowRace.ContainsKey(type))
            {
                sd.DealthyHallowRace[type]++;
            }
            await _death.Clients.All.SendAsync("updateDealthyHallowCount",
             sd.DealthyHallowRace[sd.Cloak],
             sd.DealthyHallowRace[sd.Stone],
             sd.DealthyHallowRace[sd.Wand]);
            return Accepted();

    }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}