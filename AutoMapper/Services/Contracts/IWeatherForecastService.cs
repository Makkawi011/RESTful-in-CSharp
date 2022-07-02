using AutoMapper.Entities;
using AutoMapper.Models;

namespace AutoMapper.Services.Contracts
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
