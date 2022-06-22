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
            prm.Occupations = RatingConstants.OccupationList();
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
        public JsonResult GetPremium(string Name, string occupation, DateTime dob, double InsAmount)
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
                return Json("Error occured");
                //log exception //TODO
            }
        }

        private int GetAge(DateTime dob)
        {
            var age = DateTime.Now.Subtract(dob).Days;
            age = age / 365;
            return age;
        }
        /// <summary>
        /// Calculates the premium based on the formula
        /// </summary>
        /// <param name="occupation"></param>
        /// <param name="InsAmount"></param>
        /// <param name="Age"></param>
        /// <returns></returns>
        private double CalucalatePremium(string occupation, double InsAmount, int Age)
        {
          
            var Rating = RatingConstants.ReturnRating().Where(x => x.Key == occupation).FirstOrDefault().Value;//Get the rating value
            double mpremium = Math.Round((InsAmount * Rating * Age) / (1000 * 12),2); //calculate the monthly value
           return mpremium;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}