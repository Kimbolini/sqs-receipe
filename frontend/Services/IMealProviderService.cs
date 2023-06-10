using frontend.Data;

namespace frontend.Services
{
    public interface IMealProviderService
    {
        Task<IEnumerable<Meal>> GetMealsFromAPI(string? searchString);

        Task<IEnumerable<Meal>> GetMealsFromDb();
    }
}
