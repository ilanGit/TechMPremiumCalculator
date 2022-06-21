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
    }
}
