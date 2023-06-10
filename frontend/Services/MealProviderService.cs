using frontend.Data;
using Newtonsoft.Json.Linq;

namespace frontend.Services
{
    public class MealProviderService : IMealProviderService
    {
        private readonly IHttpClientFactory _clientFactory;

        public MealProviderService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public Task<IEnumerable<Meal>> GetMealsFromAPI(string? searchString)
        {
            IEnumerable<Meal> meals = Array.Empty<Meal>();

            var request = new HttpRequestMessage(HttpMethod.Get, "https://www.themealdb.com/api/json/v1/1/search.php?s=" + searchString);
            //request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            var client = _clientFactory.CreateClient();

            var response = client.Send(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync();

                if (response.Content.Headers.ContentLength > 1)
                {
                    meals = JObject.Parse(responseContent.Result)["meals"].ToObject<IEnumerable<Meal>>();
                }

            }

            return Task.FromResult(meals);

        }

        //TODO: vervollständigen
        public Task<IEnumerable<Meal>> GetMealsFromDb()
        {
            IEnumerable<Meal> meals = Array.Empty<Meal>();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5782/api/MealController");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            var client = _clientFactory.CreateClient();

            var response = client.Send(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStreamAsync();
                //do sth
            }

            throw new NotImplementedException();
        }
    }
}
