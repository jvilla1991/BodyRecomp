using BodyRecomp.Enums;

namespace BodyRecomp.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Quantity { get; set; }
        public UnitType Unit { get; set; } = UnitType.Grams!;
        public int Calories { get; set; }

        public double Protein { get; set; }

        public double Carbs { get; set; }
        public double Fat { get; set; }
    }
}
