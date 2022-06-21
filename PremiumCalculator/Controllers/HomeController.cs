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
       

        public JsonResult GetPremium(string Name, string occupation, DateTime dob, int InsAmount)
        {
           var age=  GetAge(dob);
           var Premium =   CalucalatePremium(occupation, InsAmount, age);
            PremiumModel prm = new PremiumModel();
            prm.IName = Name;
            prm.sOccupation = occupation;
            prm.Age = age;
            prm.InsuredAmount = InsAmount;
            prm.MPremium = Premium;

            return Json(prm);
        }

        private int GetAge(DateTime dob)
        {
            var age = DateTime.Now.Subtract(dob).Days;
            age = age / 365;
            return age;
        }

        private double CalucalatePremium(string occupation, int InsAmount, int Age)
        {
            double mpremium;
            var Rating = RatingConstants.ReturnRating().Where(x => x.Key == occupation).FirstOrDefault().Value;
            mpremium = (InsAmount * Rating * Age) / 1000 * 12;
           return mpremium;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}