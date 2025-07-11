using BodyRecomp.Entities;
using BodyRecomp.Requests.Ingredient;
using BodyRecomp.Responses.Ingredient;

namespace BodyRecomp.Services.Interfaces
{
    public interface IIngredientService
    {
        IEnumerable<Ingredient> GetAll();
        Ingredient? GetById(int id);
        Ingredient Add(Ingredient ingredient);
        bool Update(int id, Ingredient updated);
        bool Delete(int id);
        Task<CreateIngredientResponse> CreateAsync(CreateIngredientRequest request);
    }
}