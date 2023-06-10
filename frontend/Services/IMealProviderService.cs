using frontend.Data;
using frontend.Services.DTO;

namespace frontend.Services
{
    public interface IMealProviderService
    {
        Task<IEnumerable<Meal>> GetMealsFromAPI(string? searchString);

        Task<MealDto> GetMealByIdFromAPI(string mealId);

        Task<IEnumerable<Meal>> GetMealsFromDb();
    }
}
