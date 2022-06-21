using Microsoft.AspNetCore.Mvc;
using PremiumCalculator.Models;
using System.Diagnostics;

namespace PremiumCalculator.Controllers
{
    public class HomeController : Controller
    {
        

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
       
        /// <summary>
        /// calcuates the premium
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="occupation"></param>
        /// <param name="dob"></param>
        /// <param name="InsAmount"></param>
        /// <returns></returns>
        public JsonResult GetPremium(string Name, string occupation, DateTime dob, int InsAmount)
        {
            try
            {
                var age = GetAge(dob);
                var Premium = CalucalatePremium(occupation, InsAmount, age);
                PremiumModel prm = new PremiumModel();
                prm.Age = age;
                prm.IName = Name;
                prm.sOccupation = occupation;
                prm.InsuredAmount = InsAmount;
                prm.MPremium = Premium;

                return Json(prm);
            }
            catch
            {
                return Json("");
            }
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
            mpremium = Math.Round((InsAmount * Rating * Age) / (1000 * 12),2);
           return mpremium;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}