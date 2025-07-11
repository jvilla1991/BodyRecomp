using BodyRecomp.Enums;
using System.ComponentModel.DataAnnotations;

namespace BodyRecomp.Requests.FoodEntry
{
    public class CreateFoodEntryRequest
    {
        [Required]
        public string Name { get; set; }

        public double Quantity { get; set; }
        public UnitType Unit { get; set; } = UnitType.Grams;
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }

        public string? MealType { get; set; }
        public DateTime? LogDate { get; set; }
    }
}
