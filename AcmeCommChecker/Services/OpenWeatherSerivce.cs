using AcmeCommChecker.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AcmeCommChecker.Services
{
    public class OpenWeatherSerivce
    {
        private HttpClient client = new HttpClient();

        private readonly IConfiguration Configuration;

        private string ApiKey;

        public OpenWeatherSerivce(IConfiguration configuration)
        {
            Configuration = configuration;
            ApiKey = Configuration["OpenWeatherApiKey"];
            client.BaseAddress = new Uri("http://api.openweathermap.org");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<OpenWeatherForecast> GetForecast(string location)
        {
            var forecast = new OpenWeatherForecast();
            var url = $"/data/2.5/forecast?q={location}&units=imperial&APPID={ApiKey}";

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                forecast = JsonConvert.DeserializeObject<OpenWeatherForecast>(result);
            }
            

            return forecast;
        }
    }
}
