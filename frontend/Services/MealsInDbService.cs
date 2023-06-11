using frontend.Data;
using frontend.Services.DTO;
using Newtonsoft.Json;
using System.Text;

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
        public async void AddMealDtoToFavourites(MealDto meal)
        {
            var tmp = JsonConvert.SerializeObject(meal);
            var data = new StringContent(tmp, Encoding.UTF8, "application/json");
            var url = "http://localhost:5782/api/Meal";
            var client = _clientFactory.CreateClient();

            var response = await client.PostAsync(url, data);

         

           // var response = client.Send(request);
            if (response.IsSuccessStatusCode)
            {
                //do sth
            }
        }
    }

}
