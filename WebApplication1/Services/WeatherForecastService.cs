using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Models;
using WebApplication1.Services.Contracts;

namespace WebApplication1.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly Context context;

        public WeatherForecastService(Context context)
        {
            this.context = context;
        }

        public void CreateWeatherForecast(WeatherForecast WeatherForecast)
        {
            context.WeatherForecast.Add(WeatherForecast);
            context.SaveChanges();
        }

        public void DeleteWeatherForecastById(int id)
        {
            var val = context.WeatherForecast.Where(x => x.Id == id).FirstOrDefault();
            context.Remove(val);
            context.SaveChanges();
        }

        public WeatherForecast GetWeatherForecastById(int id)
            => context.WeatherForecast.Where(x => x.Id == id).FirstOrDefault();

        public IEnumerable<WeatherForecast> GetWeatherForecasts() => context.WeatherForecast;

        public void UpdateWeatherForecast(WeatherForecast newWeatherForecast)
        {
            var oldWeatherForecast = context.WeatherForecast.Find(newWeatherForecast.Id);
            oldWeatherForecast.Summary = newWeatherForecast.Summary;
            oldWeatherForecast.TemperatureId = newWeatherForecast.TemperatureId;    
            oldWeatherForecast.Date = newWeatherForecast.Date;

            context.SaveChanges();
        }
    }
}
