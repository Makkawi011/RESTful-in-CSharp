namespace WebApplication1.Models
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureId { get; set; }

        public string? Summary { get; set; }
    }
}