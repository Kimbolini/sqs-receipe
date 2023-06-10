using frontend.Data;

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
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:5782/api/MealController");
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
