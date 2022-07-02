
using AutoMapper.Entities;
using AutoMapper.Models;
using AutoMapper.Services.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace AutoMapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastDTOController : ControllerBase
    {
        private readonly IWeatherForecastService WeatherForecastService;
        private readonly ITemperatureService TemperatureService;
        private readonly IMapper mapper;

        public WeatherForecastDTOController(IWeatherForecastService WeatherForecast , ITemperatureService temperatureService ,IMapper mapper )
        {
            this.WeatherForecastService = WeatherForecast;
            this.TemperatureService = temperatureService;
            this.mapper = mapper;
        }

        [HttpPost]
        public void CreateWeatherForecast(WeatherForecastDTO weatherForecastDTO)
        {
            WeatherForecast weatherForecast = mapper.Map<WeatherForecast>(weatherForecastDTO);
            Temperature temperature = mapper.Map<Temperature>(weatherForecastDTO);

            WeatherForecastService.CreateWeatherForecast(weatherForecast);
            TemperatureService.CreateTemperature(temperature);


        }

        [HttpDelete]
        public void DeleteWeatherForecastById(int id)
        {
            WeatherForecastService.DeleteWeatherForecastById(id);
            TemperatureService.DeleteTemperatureById(id);
        }

        [HttpGet]
        public WeatherForecastDTO GetWeatherForecastById(int id)
        {
            var weatherForecast = WeatherForecastService.GetWeatherForecastById(id);
            var temperature = TemperatureService.GetTemperatureById(id);

            var weatherForecastDTO = mapper.Map<WeatherForecastDTO>(weatherForecast);
            weatherForecastDTO.TemperatureC = temperature.TemperatureC;

            return weatherForecastDTO;

        }

        [HttpGet]
        public IEnumerable<WeatherForecastDTO> GetWeatherForecasts()
        {
            var WeatherForecasts = WeatherForecastService.GetWeatherForecasts();
            foreach (var item in WeatherForecasts)
            {
                var dto = mapper.Map<WeatherForecastDTO>(item);
                dto.TemperatureC = TemperatureService.GetTemperatureById(dto.TemperatureId).TemperatureC;

                yield return dto;
            }
        }

        [HttpPut]
        public void UpdateWeatherForecast(WeatherForecastDTO weatherForecastDto)
        {
            var weatherForecast =  mapper.Map<WeatherForecast>(weatherForecastDto);
            var temperature = mapper.Map<Temperature>(weatherForecastDto);

            WeatherForecastService.UpdateWeatherForecast(weatherForecast);
            TemperatureService.UpdateTemperature(temperature);

        }
    }
}