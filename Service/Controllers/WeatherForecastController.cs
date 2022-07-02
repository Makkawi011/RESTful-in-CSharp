
using Microsoft.AspNetCore.Mvc;

using Service.Services.Contracts;

namespace Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecast _weatherForecast;

        public WeatherForecastController(IWeatherForecast weatherForecast)
        {
            _weatherForecast = weatherForecast;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> GetAll() => _weatherForecast.GetAll();


        // POST: WeatherForecast Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public void Create(WeatherForecast weatherForecast) => _weatherForecast.Create(weatherForecast);

        // GET: WeatherForecast/Edit/5
        [HttpPut]
        public void Edit(int? id, WeatherForecast weatherForecast) => _weatherForecast.Edit(id, weatherForecast);



        // GET: WeatherForecast/Delete/5
        [HttpDelete]
        public void Delete(int? id) => _weatherForecast.Delete(id); 
    }
}