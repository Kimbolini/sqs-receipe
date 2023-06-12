﻿using frontend.Data;
using frontend.Services.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        /// <summary>Requests all meals that are saved in the Database</summary>
        /// <returns>The response from the DB as Task with an IEnumerable of MealDtos</returns>
        public Task<IEnumerable<MealDto>> GetMealsFromDb()
        {
            IEnumerable<MealDto> meals = Array.Empty<MealDto>();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5782/api/Meal");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            var client = _clientFactory.CreateClient();

            var response = client.Send(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync();
                if (response.Content.Headers.ContentLength > 14)
                {
                    meals = JArray.Parse(responseContent.Result).ToObject<IEnumerable<MealDto>>();
                }
            }
            return Task.FromResult(meals);
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
