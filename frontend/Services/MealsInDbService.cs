using frontend.Data;
using frontend.Services.DTO;

namespace frontend.Services
{
    public class MealsInDbService
    {
        private readonly IHttpClientFactory _clientFactory;

        public MealsInDbService(IHttpClientFactory clientFactory) 
        {
            _clientFactory = clientFactory;
        }

        //Send a meal over the API to the db and create it there
        //TODO: Change rückkabetyp
        public void AddMealToFavourites(Meal meal)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:5782/api/Meal");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            var client = _clientFactory.CreateClient();

            var response = client.Send(request);
            if (response.IsSuccessStatusCode)
            {             
                //do sth
            }
        }

        //Send a meal over the API to the db and create it there
        //TODO: Change rückkabetyp
        public void AddMealDtoToFavourites(MealDto meal)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:5782/api/Meal");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            var client = _clientFactory.CreateClient();

            var response = client.Send(request);
            if (response.IsSuccessStatusCode)
            {
                //do sth
            }
        }
    }

}
