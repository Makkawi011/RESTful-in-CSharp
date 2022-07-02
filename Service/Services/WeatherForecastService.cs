using Service.Data;
using Service.Services.Contracts;

namespace Service.Services
{
    public class WeatherForecastService : IWeatherForecast
    {
        private readonly Context _context;

        public WeatherForecastService(Context context)
        {
            _context = context;
        }

        public void Create(WeatherForecast weatherForecast)
        {

            _context.Add(weatherForecast);
            _context.SaveChanges();

        }

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

        public void Edit(int? id, WeatherForecast weatherForecast)
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

        public IEnumerable<WeatherForecast> GetAll()
        {
            return _context.WeatherForecast.ToList();
        }
    }
}
