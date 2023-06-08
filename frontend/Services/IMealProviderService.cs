using frontend.Data;

namespace frontend.Services
{
    public interface IMealProviderService
    {
        Task<IEnumerable<Meal>> GetMeals(string? searchString);
    }
}
