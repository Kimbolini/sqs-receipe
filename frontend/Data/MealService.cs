using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json.Serialization;

namespace frontend.Data
{
    public class MealService : PageModel
    {
        public async Task<List<Meal>> GetMealsAsync(string search)
        {
            List<Meal> meals = new List<Meal>();
            using var httpClient = new HttpClient();
            using (HttpResponseMessage response = await httpClient.GetAsync("https://www.themealdb.com/api/json/v1/1/search.php?s=Arrabiata"))
            {
                /*if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Meal>>(apiResponse);
                } else
                {
                    return meals;
                }*/
                return meals;
            }
       
        }
    }
}
