using BodyRecomp.Entities;
using BodyRecomp.Enums;
using BodyRecomp.Requests.Ingredient;
using BodyRecomp.Responses.Ingredient;
using BodyRecomp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BodyRecomp.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly AppDbContext _context;

        public IngredientService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _context.Ingredients.AsNoTracking().ToList();
        }

        public Ingredient? GetById(int id)
        {
            return _context.Ingredients.AsNoTracking().FirstOrDefault(i => i.Id == id);
        }

        public Ingredient Add(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
            return ingredient;
        }

        public bool Update(int id, Ingredient updated)
        {
            var existing = _context.Ingredients.FirstOrDefault(i => i.Id == id);
            if (existing == null)
                return false;

            existing.Name = updated.Name;
            existing.Quantity = updated.Quantity;
            existing.Unit = updated.Unit;
            existing.Calories = updated.Calories;
            existing.Protein = updated.Protein;
            existing.Carbs = updated.Carbs;
            existing.Fat = updated.Fat;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var ingredient = _context.Ingredients.FirstOrDefault(i => i.Id == id);
            if (ingredient == null)
                return false;

            _context.Ingredients.Remove(ingredient);
            _context.SaveChanges();
            return true;
        }

        public async Task<CreateIngredientResponse> CreateAsync(CreateIngredientRequest request)
        {
            var entity = new Ingredient
            {
                Name = request.Name,
                Quantity = request.Quantity ?? 0,
                Unit = request.Unit,
                Calories = request.Calories ?? 0,
                Protein = request.Protein ?? 0,
                Carbs = request.Carbs ?? 0,
                Fat = request.Fat ?? 0
            };

            _context.Ingredients.Add(entity);
            await _context.SaveChangesAsync();

            return new CreateIngredientResponse
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

    }
}
