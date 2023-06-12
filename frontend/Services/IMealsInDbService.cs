using frontend.Services.DTO;

namespace frontend.Services
{
    public interface IMealsInDbService
    {
        Task<IEnumerable<MealDto>> GetMealsFromDb();

        Task<MealDto> GetMealById(int id);

        void AddMealDtoToFavourites(MealDto meal);
    }
}
