using Application.Data;

using EF_and_API;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CORS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly Context _context;

        public WeatherForecastController(Context context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> GetAll()
        {
            return _context.WeatherForecast;
        }

        // POST: WeatherForecast Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public void Create( WeatherForecast weatherForecast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weatherForecast);
                _context.SaveChanges();
            }
        }

        // GET: WeatherForecast/Edit/5
        [HttpPut]
        public void Edit(int? id , WeatherForecast weatherForecast)
        {
            if (id == null || _context.WeatherForecast == null)
            {
                throw new Exception();
            }

            var oldWeatherForecast = _context.WeatherForecast.Find(id);

            oldWeatherForecast.Date = weatherForecast.Date;
            oldWeatherForecast.TemperatureC = weatherForecast.TemperatureC;
            oldWeatherForecast.Summary = weatherForecast.Summary;

            if (oldWeatherForecast == null)
            {
                throw new Exception();
            }

            _context.SaveChanges();
        }



        // GET: WeatherForecast/Delete/5
        [HttpDelete]
        public void Delete(int? id)
        {
            if (id == null || _context.WeatherForecast == null)
            {
                throw new Exception();
            }

            var weatherForecast = _context.WeatherForecast
                .FirstOrDefault(m => m.Id == id);

            _context.Remove(weatherForecast);

            _context.SaveChanges();

        }

    }
}