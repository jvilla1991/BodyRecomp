using BodyRecomp.Entities;
using BodyRecomp.Requests.FoodEntry;
using BodyRecomp.Responses.FoodEntry;
using BodyRecomp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BodyRecomp.Services
{
    public class FoodLogService : IFoodLogService
    {
        private readonly AppDbContext _context;

        public FoodLogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FoodEntryResponse> LogFoodAsync(CreateFoodEntryRequest request)
        {
            var entry = new FoodEntry
            {
                Name = request.Name,
                Quantity = request.Quantity,
                Unit = request.Unit,
                Calories = request.Calories,
                Protein = request.Protein,
                Carbs = request.Carbs,
                Fat = request.Fat,
                MealType = request.MealType,
                LoggedAt = request.LogDate ?? DateTime.UtcNow
            };

            _context.FoodEntries.Add(entry);
            await _context.SaveChangesAsync();

            return new FoodEntryResponse
            {
                Id = entry.Id,
                Name = entry.Name,
                Quantity = entry.Quantity,
                Unit = entry.Unit,
                Calories = entry.Calories,
                Protein = entry.Protein,
                Carbs = entry.Carbs,
                Fat = entry.Fat,
                LoggedAt = entry.LoggedAt,
                MealType = entry.MealType
            };
        }

        public async Task<List<FoodEntryResponse>> LogFoodBulkAsync(List<CreateFoodEntryRequest> requests)
        {
            var entries = requests.Select(r => new FoodEntry
            {
                Name = r.Name,
                Quantity = r.Quantity,
                Unit = r.Unit,
                Calories = r.Calories,
                Protein = r.Protein,
                Carbs = r.Carbs,
                Fat = r.Fat,
                MealType = r.MealType,
                LoggedAt = r.LogDate?.ToUniversalTime() ?? DateTime.UtcNow
            }).ToList();

            _context.FoodEntries.AddRange(entries);
            await _context.SaveChangesAsync();

            return entries.Select(e => new FoodEntryResponse
            {
                Id = e.Id,
                Name = e.Name,
                Quantity = e.Quantity,
                Unit = e.Unit,
                Calories = e.Calories,
                Protein = e.Protein,
                Carbs = e.Carbs,
                Fat = e.Fat,
                LoggedAt = e.LoggedAt,
                MealType = e.MealType
            }).ToList();
        }

        public async Task<List<FoodEntryResponse>> GetFoodLogsByDateAsync(DateTime date)
        {
            var dayStart = DateTime.SpecifyKind(date.Date, DateTimeKind.Local).ToUniversalTime();
            var dayEnd = dayStart.AddDays(1);

            return await _context.FoodEntries
                .Where(e => e.LoggedAt >= dayStart && e.LoggedAt <= dayEnd)
                .OrderBy(e => e.LoggedAt)
                .Select(e => new FoodEntryResponse
                {
                    Id = e.Id,
                    Name = e.Name,
                    Calories = e.Calories,
                    Protein = e.Protein,
                    Carbs = e.Carbs,
                    Fat = e.Fat,
                    LoggedAt = e.LoggedAt,
                    MealType = e.MealType
                })
                .ToListAsync();
        }
    }
}
