using BodyRecomp.Enums;
using System.ComponentModel.DataAnnotations;

namespace BodyRecomp.Requests.Ingredient
{
    public class CreateIngredientRequest
    {
        [Required]
        public required string Name { get; set; }

        [Range(0, 1000)]
        public int? Calories { get; set; }
        public double? Quantity { get; set; }
        public UnitType Unit { get; set; } = UnitType.Grams!;
        public double? Protein { get; set; }
        public double? Carbs { get; set; }
        public double? Fat { get; set; }
    }
}
