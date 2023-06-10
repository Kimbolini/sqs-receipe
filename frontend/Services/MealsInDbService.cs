using frontend.Data;

namespace frontend.Services
{
    public class MealsInDbService
    {

        public void AddMealToFavourites(Meal meal)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:5782/api/MealController");
        }
    }

}
