using BodyRecomp.Enums;
using System.ComponentModel.DataAnnotations;

namespace BodyRecomp.Entities
{
    public class FoodEntry
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public double Quantity { get; set; }
        public UnitType Unit { get; set; } = UnitType.Grams!;

        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }

        public DateTime LoggedAt { get; set; } = DateTime.UtcNow;

        public string? MealType { get; set; } // e.g. Breakfast, Lunch
    }
}
