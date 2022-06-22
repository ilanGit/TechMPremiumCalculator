namespace PremiumCalculator.Models
{
    public class PremiumModel
    {
       
        public int Age { get; set; }
        public string? IName { get; set; }
        public string? sOccupation { get; set; }
        public DateTime DateOfBirth { get; set; }

        public double InsuredAmount { get; set; }
        public List<Occupation>? Occupations { get; set; }

        public double MPremium { get; set; }


    }
    public class Occupation
    {
        public string? OccupationName { get; set; }
        public string? Rating { get; set; }
    }
}
