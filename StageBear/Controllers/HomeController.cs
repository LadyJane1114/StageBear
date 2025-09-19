using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StageBear.Models;

namespace StageBear.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Event> events =
                [
                new() {
                    EventID = 1,
                    Title = "Roger's and Hammerstein's Cinderella",
                    Description = "A beloved musical adaptation of the classic fairy tale about a mistreated servant girl who, with the help of her fairy godmother, attends a royal ball and wins the heart of the prince, overcoming her wicked stepfamily.",
                    Scheduled = new DateTime(2025, 10, 2, 19, 00, 00),
                    Location = "Gerswin Theatre - 222 W 51st St, New York, NY 10019, United States",
                    Owner = "Richard Rogers and Oscar Hammerstein",
                    DateRecorded = DateTime.Now
                },
                new() {
                    EventID = 2,
                    Title = "Rent",
                    Description = "A rock musical set in New York's East Village during the AIDS epidemic, following a group of impoverished artists struggling with love, loss, and poverty, inspired by Puccini's opera La Bohème.",
                    Scheduled = new DateTime(2025, 12, 25, 11, 00, 00),
                    Location = "Richard Rogers Theatre - 226 W 46th St, New York, NY 10036, United States",
                    Owner = "Jonathan Larson",
                    DateRecorded = DateTime.Now
                },
                ];
            return View(events);
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
