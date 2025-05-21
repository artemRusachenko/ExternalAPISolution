using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExternalAPI.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public WeatherController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeather(string city)
        {
            var apiKey = "494936b36bcec526c681c502cfb18cb2";
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric&lang=ua";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return StatusCode((int)response.StatusCode, "Помилка при отриманні погоди");

                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Помилка сервера: {ex.Message}");
            }
        }

        
    }
}
