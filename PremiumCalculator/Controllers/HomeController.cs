using Microsoft.AspNetCore.Mvc;
using PremiumCalculator.Models;
using System.Diagnostics;

namespace PremiumCalculator.Controllers
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
            PremiumModel prm = new PremiumModel();
            List<Occupation> lstOccupation = new List<Occupation>
                {
                    new Occupation { OccupationName = "Cleaner", Rating = "Light Manual"},
                    new Occupation { OccupationName = "Doctor", Rating = "Professional" },
                    new Occupation { OccupationName = "Author", Rating = "White Collar" },
                     new Occupation { OccupationName = "Farmer", Rating = "Heavy Manual"},
                    new Occupation { OccupationName = "Mechanic", Rating = "Heavy Manual" },
                    new Occupation { OccupationName = "Florist", Rating = "Light Manual" }

                };
            prm.Occupations = lstOccupation;
            return View(prm);
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