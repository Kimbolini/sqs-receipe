using frontend.Data;
using frontend.Services.DTO;

namespace frontend.Services
{
    public interface IMealsAtAPIService
    {
        Task<IEnumerable<MealDto>> GetMealsFromAPI(string? searchString);

        Task<MealDto> GetMealByIdFromAPI(string mealId);
    }
}
