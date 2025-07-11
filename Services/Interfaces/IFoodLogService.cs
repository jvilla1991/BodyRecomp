using BodyRecomp.Requests.FoodEntry;
using BodyRecomp.Responses.FoodEntry;

namespace BodyRecomp.Services.Interfaces
{
    public interface IFoodLogService
    {
        Task<FoodEntryResponse> LogFoodAsync(CreateFoodEntryRequest request);
        Task<List<FoodEntryResponse>> LogFoodBulkAsync (List<CreateFoodEntryRequest> requests);

        Task<List<FoodEntryResponse>> GetFoodLogsByDateAsync(DateTime date);
    }
}
