using BodyRecomp.Enums;

namespace BodyRecomp.Responses.FoodEntry
{
    public class FoodEntryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }

        public DateTime LoggedAt { get; set; }
        public string? MealType { get; set; }
        public double Quantity { get; internal set; }
        public UnitType Unit { get; internal set; }
    }
}
