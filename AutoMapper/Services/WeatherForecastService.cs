using AutoMapper.Data;
using AutoMapper.Entities;
using AutoMapper.Models;
using AutoMapper.Services.Contracts;

namespace AutoMapper.Services
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
