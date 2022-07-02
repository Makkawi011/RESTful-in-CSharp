namespace AutoMapper.Entities
{
    public class WeatherForecastDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureId { get; set; }

        public string? Summary { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
