using frontend.Services.DTO;

namespace frontend.Services
{
    public interface IMealsInDbService
    {
        Task<IEnumerable<MealDto>> GetMealsFromDb();
    }
}
