namespace Service.Services.Contracts;

public interface IWeatherForecast
{
    public IEnumerable<WeatherForecast> GetAll();
    public void Create(WeatherForecast weatherForecast);
    public void Edit(int? id, WeatherForecast weatherForecast);
    public void Delete(int? id);

}
