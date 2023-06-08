using frontend.Data;
using System.Net.Http.Json;

namespace frontend.Services
{
    public class MealService : IMealService
    {
        private readonly HttpClient _httpClient;

        public MealService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Meal>> GetMeals()
        {
            return await _httpClient.GetJsonAsync<Meal[]>("api/MealController");
            throw new NotImplementedException();
        }
    }
}
