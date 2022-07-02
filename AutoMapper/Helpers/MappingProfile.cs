using AutoMapper.Entities;
using AutoMapper.Models;

namespace AutoMapper.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WeatherForecast, WeatherForecastDTO>();

            CreateMap<WeatherForecastDTO, WeatherForecast>();
            CreateMap<WeatherForecastDTO, Temperature>();
        }
    }
}
