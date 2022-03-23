using LearningHttpRequest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Json;

namespace LearningHttpRequest.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public async Task<JsonResult> FindCity(string city_name)
        {
            HttpClient httpClient = new HttpClient();
            //var query_collection = new QueryCollection();
            city_name.Replace(" ", "%20");
            var response = await httpClient.GetAsync("https://www.metaweather.com/api/location/search/?query=" + city_name);


            var json_response = await response.Content.ReadAsStringAsync();
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            return new JsonResult(json_response);
        }

        [HttpPost]
        public async Task<JsonResult> GetCityInformation(int woeid)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://www.metaweather.com/api/location/" + woeid);
            var json_response = await response.Content.ReadAsStringAsync();
            var deserialized_object = JsonSerializer.Deserialize<MetaWeatherCityObj>(json_response);
            return new JsonResult(deserialized_object);
        }

    }
}