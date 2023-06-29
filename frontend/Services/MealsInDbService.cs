using frontend.Data;
using frontend.Services.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace frontend.Services
{
    public class MealsInDbService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly InternalCacheService _cacheService;
        private readonly string _restUrl;

        public MealsInDbService(IHttpClientFactory clientFactory, InternalCacheService cacheService, IConfiguration configuration) 
        {
            _clientFactory = clientFactory;
            _cacheService = cacheService;
            _restUrl = configuration.GetConnectionString("MealDBURL");
        }

        /// <summary>Requests all meals that are saved in the Database</summary>
        /// <returns>The response from the DB as Task with an IEnumerable of MealDtos</returns>
        public Task<IEnumerable<MealDto>> GetMealsFromDb()
        {
            IEnumerable<MealDto> meals = Array.Empty<MealDto>();
            var request = new HttpRequestMessage(HttpMethod.Get, _restUrl);
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

        /// <summary>Requests a certain meal from the database </summary>
        /// <param name="id">The id of the requested meal</param>
        /// <returns>The requested meal as MealDto</returns>
        public Task<MealDto> GetMealById(int id)
        {
            MealDto entity = new();
            var request = new HttpRequestMessage(HttpMethod.Get, _restUrl + "/"+ id);
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            var client = _clientFactory.CreateClient();

            var response = client.Send(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync();
                if (response.Content.Headers.ContentLength > 1)
                {
                    entity = JObject.Parse(responseContent.Result).ToObject<MealDto>();
                }
            }

            return Task.FromResult(entity);
        }

        //Send a meal over the API to the db and create it there
        public async Task AddMealDtoToFavourites(MealDto meal)
        {
            var tmp = JsonConvert.SerializeObject(meal);
            var data = new StringContent(tmp, Encoding.UTF8, "application/json");
            var url = _restUrl;
            var client = _clientFactory.CreateClient();

            var response = await client.PostAsync(url, data);

            if (response.IsSuccessStatusCode)
            {
                _cacheService.AddToFavourites(meal.StrId);
            }
        }
    }

}
