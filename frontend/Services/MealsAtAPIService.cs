using frontend.Data;
using frontend.Services.DTO;
using Newtonsoft.Json.Linq;

namespace frontend.Services
{
    public class MealsAtAPIService : IMealsAtAPIService
    {
        private readonly IHttpClientFactory _clientFactory;

        public MealsAtAPIService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>Requests Meals from the meal API.</summary>
        /// <param name="searchString">The search keyword that was entered by the user. Can be empty</param>
        /// <returns>A Task with an IEnumerable of MealDtos of the response of the API</returns>
        public Task<IEnumerable<MealDto>> GetMealsFromAPI(string? searchString)
        {
            IEnumerable<MealDto> meals = Array.Empty<MealDto>();

            var request = new HttpRequestMessage(HttpMethod.Get, "https://www.themealdb.com/api/json/v1/1/search.php?s=" + searchString);
            //request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            var client = _clientFactory.CreateClient();

            var response = client.Send(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync();
                if (response.Content.Headers.ContentLength > 14)
                {
                    IEnumerable<Meal> tmp = JObject.Parse(responseContent.Result)["meals"].ToObject<IEnumerable<Meal>>();
                    if(tmp != null)
                    {
                        meals = tmp.Select(x => new MealDto(x)).ToList();
                    }             
                }
            }

            return Task.FromResult(meals);
        }

        /// <summary>Requests a single meal from the meal API </summary>
        /// <param name="mealId">The id of the meal as communicated by the API</param>
        /// <returns>The response from the API as Task with a MealDto</returns>
        public Task<MealDto> GetMealByIdFromAPI(string mealId)
        {
            MealDto mealDto = new();

            var request = new HttpRequestMessage(HttpMethod.Get, "https://www.themealdb.com/api/json/v1/1/lookup.php?i=" + mealId);
            //request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            var client = _clientFactory.CreateClient();

            var response = client.Send(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync();
                IEnumerable<Meal> tmp = JObject.Parse(responseContent.Result)["meals"].ToObject<IEnumerable<Meal>>();
                mealDto = new MealDto(tmp.ElementAt(0));
            }

            return Task.FromResult(mealDto);

        }
    }
}
