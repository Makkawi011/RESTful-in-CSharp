using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Services.Contracts
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> GetWeatherForecasts();
        WeatherForecast GetWeatherForecastById(int id);

        void CreateWeatherForecast(WeatherForecast weatherForcast);

        void UpdateWeatherForecast(WeatherForecast weatherForcast);

        void DeleteWeatherForecastById(int id);

    }
}
