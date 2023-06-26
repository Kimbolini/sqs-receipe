using frontend.Services.DTO;

namespace frontend.Services
{
    public interface IMealsInDbService
    {
        Task<IEnumerable<MealDto>> GetMealsFromDb();

        Task<MealDto> GetMealById(int id);

        Task AddMealDtoToFavourites(MealDto meal);
    }
}
