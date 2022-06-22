using PremiumCalculator.Models;

namespace PremiumCalculator.Controllers
{
    public static class RatingConstants
    {
        public static IDictionary<string, double> ReturnRating()
        {
             IDictionary<string, double> RatingList = new Dictionary<string, double>();
            RatingList.Add("Professional", 1.0); //adding a key/value using the Add() method
            RatingList.Add("White Collar", 1.25);
            RatingList.Add("Light Manual", 1.50);
            RatingList.Add("Heavy Manual", 1.75);

            return RatingList;
        }
        public static List<Occupation> OccupationList()
        {
            List<Occupation> lstOccupation = new List<Occupation>
                {
                    new Occupation { OccupationName = "Cleaner", Rating = "Light Manual"},
                    new Occupation { OccupationName = "Doctor", Rating = "Professional" },
                    new Occupation { OccupationName = "Author", Rating = "White Collar" },
                     new Occupation { OccupationName = "Farmer", Rating = "Heavy Manual"},
                    new Occupation { OccupationName = "Mechanic", Rating = "Heavy Manual" },
                    new Occupation { OccupationName = "Florist", Rating = "Light Manual" }

                };
            return lstOccupation;
        }
    }
}
