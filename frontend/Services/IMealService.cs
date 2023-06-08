using frontend.Data;

namespace frontend.Services
{
    public interface IMealService
    {
        Task<IEnumerable<Meal>> GetMeals();
    }
}
